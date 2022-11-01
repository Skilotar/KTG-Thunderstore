using System;
using System.Collections;
using System.Reflection;
using System.Linq;
using System.Text;
using UnityEngine;
using ItemAPI;
using MonoMod;
using Gungeon;
using Dungeonator;


namespace Knives
{
    public class LifeInsure : PassiveItem
    {
        public static void Register()
        {
            string itemName = "Life Insurance";

            string resourceName = "Knives/Resources/lifeInsureance";

            GameObject obj = new GameObject(itemName);

            var item = obj.AddComponent<LifeInsure>();

            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);

            //Ammonomicon entry variables
            string shortDesc = "Do You Need It?";
            string longDesc = "Protects from death once. Costs per floor. " +
                "\n\n\n -Knife_to_a_Gunfight";

            //Adds the item to the gungeon item list, the ammonomicon, the loot table, etc.
            //Do this after ItemBuilder.AddSpriteToObject!
            ItemBuilder.SetupItem(item, shortDesc, longDesc, "ski");

            //Adds the actual passive effect to the item
            item.quality = PickupObject.ItemQuality.A;
            item.PersistsOnDeath = true;
            item.CanBeDropped = false;
            Remove_from_lootpool.RemovePickupFromLootTables(item);
            itemID = item.PickupObjectId;
            JinxItemDisplayStorageClass text = item.gameObject.GetOrAddComponent<JinxItemDisplayStorageClass>();
            text.jinxItemDisplayText = "Saves you from death once, But charges you every floor";
        }

        public static int itemID;
        public override void Pickup(PlayerController player)
        {
            player.healthHaver.ModifyDamage = (Action<HealthHaver, HealthHaver.ModifyDamageEventArgs>)Delegate.Combine(player.healthHaver.ModifyDamage, new Action<HealthHaver, HealthHaver.ModifyDamageEventArgs>(this.ModifyIncomingDamage));
            player.OnNewFloorLoaded += this.OnLoadedFloor;
            base.Pickup(player);


        }
        bool CanBlockDeath = true;
        private void ModifyIncomingDamage(HealthHaver arg1, HealthHaver.ModifyDamageEventArgs arg2)
        {
            if (arg2.ModifiedDamage >= this.Owner.healthHaver.GetCurrentHealth() && this.Owner.healthHaver.Armor < 1) // if is fatal
            {
                if (CanBlockDeath == true)
                {
                    this.Owner.BloopItemAboveHead(base.sprite, "Knives/Resources/lifeInsureance");
                    arg2.ModifiedDamage = 0;
                    arg1.ApplyHealing(1);
                    CanBlockDeath = false;
                }
            }
            if(this.Owner.healthHaver.Armor == 1)
            {
                if (this.Owner.healthHaver.GetCurrentHealth() == 0) //fatal but on armor this time
                {
                    if (CanBlockDeath == true)
                    {
                        this.Owner.BloopItemAboveHead(base.sprite, "Knives/Resources/lifeInsureance");
                        arg2.ModifiedDamage = 0;
                        arg1.Armor = arg1.Armor + 1;
                        CanBlockDeath = false;
                    }
                }
                
            }
        }

       
        bool half_toggle = false;
        public void OnLoadedFloor(PlayerController player)
        {

            if (half_toggle)
            {
                if (CanBlockDeath == true)
                {
                    player.carriedConsumables.Currency = player.carriedConsumables.Currency - 30;
                }
                half_toggle = false;
            }
            else
            {
                half_toggle = true;
            }


        }

        public override DebrisObject Drop(PlayerController player)
        {

            player.OnNewFloorLoaded -= this.OnLoadedFloor;
            return base.Drop(player);
        }

    }
}
