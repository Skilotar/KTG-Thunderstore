using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using UnityEngine;
using ItemAPI;
using Dungeonator;
using GungeonAPI;

namespace Knives
{
    class P2020_item : PlayerItem
    {
        public static void Register()
        {
            //The name of the item
            string itemName = "Emergency Pistol";

            //Refers to an embedded png in the project. Make sure to embed your resources! Google it
            string resourceName = "Knives/Resources/EmergencyPistol";

            //Create new GameObject
            GameObject obj = new GameObject(itemName);

            //Add a PassiveItem component to the object
            var item = obj.AddComponent<P2020_item>();

            //Adds a sprite component to the object and adds your texture to the item sprite collection
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);

            //Ammonomicon entry variables
            string shortDesc = "Always Faster Than Reloading";
            string longDesc = "A common-use pistol for Hegemony infantry. These pistols are so reliable that they were often saved for emergency situations." +
                " A well timed swap can save your life and help you get your primary back in action" +
                "\n\n\n - Knife_to_a_Gunfight";

            //Adds the item to the gungeon item list, the ammonomicon, the loot table, etc.
            //Do this after ItemBuilder.AddSpriteToObject!
            ItemBuilder.SetupItem(item, shortDesc, longDesc, "ski");

            //Adds the actual passive effect to the item


            ItemBuilder.SetCooldownType(item, ItemBuilder.CooldownType.Damage, 150);
          
           

            item.quality = PickupObject.ItemQuality.C;
            ID = item.PickupObjectId;
        }
        public static int ID;
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }
        public Gun p2020;
        public bool IsP2020Active = false;
        public Gun PreviousGun;
        public override void  DoEffect(PlayerController user)
        {
            if (user.IsGunLocked == false) //not gunlocked
            {
                user.CurrentGun.MoveBulletsIntoClip(10);
                PreviousGun = user.CurrentGun;
                Gun emergency_gun = user.inventory.AddGunToInventory(PickupObjectDatabase.GetById(P2020.ID) as Gun, true);
                p2020 = emergency_gun;
                p2020.CanBeDropped = false;
                p2020.CanBeSold = false;
                user.inventory.GunLocked.SetOverride("Emergency_pistol", true, null);
                this.CanBeDropped = false;
                AkSoundEngine.PostEvent("Play_OBJ_item_pickup_01", base.gameObject);
                AkSoundEngine.PostEvent("Play_OBJ_item_pickup_01", base.gameObject);
                AkSoundEngine.PostEvent("Play_OBJ_item_pickup_01", base.gameObject);
                this.IsP2020Active = true;

            }
            else
            {
                FieldInfo remainingTimeCooldown = typeof(PlayerItem).GetField("remainingDamageCooldown", BindingFlags.NonPublic | BindingFlags.Instance);
                remainingTimeCooldown.SetValue(this.gameObject, 0);

            }
        }

        public override void Update()
        {
            if (this.LastOwner != null)
            {
                if (IsP2020Active)
                {
                    
                    if (this.LastOwner.CurrentGun.ClipShotsRemaining == 0)
                    {
                        
                        this.LastOwner.inventory.GunLocked.RemoveOverride("Emergency_pistol");
                        this.LastOwner.inventory.DestroyGun(p2020);
                        
                        this.IsP2020Active = false;
                        this.CanBeDropped = true;
                    }
                }
                if(this.LastOwner.PlayerHasActiveSynergy("Prepare for Titanfall"))
                {
                    ItemBuilder.SetCooldownType(this, ItemBuilder.CooldownType.Damage, 100);
                }
                else
                {
                    ItemBuilder.SetCooldownType(this, ItemBuilder.CooldownType.Damage, 150);
                }
            }

            base.Update();
        }


      
        public override void  OnPreDrop(PlayerController user)
        {
            if (IsP2020Active)
            {
                this.LastOwner.inventory.GunLocked.RemoveOverride("Emergency_pistol");
                this.LastOwner.inventory.DestroyGun(p2020);
                this.IsP2020Active = false;
 
            }

            base.OnPreDrop(user);
        }


     
    }
}
