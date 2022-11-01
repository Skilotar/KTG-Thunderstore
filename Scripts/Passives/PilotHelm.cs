using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;
using ItemAPI;

using Dungeonator;


namespace Knives
{
    class Pilots_Helmet : PassiveItem
    {
        private bool rollFly;

        public static void Register()
        {
            //The name of the item
            string itemName = "Pilot's Helmet";

            //Refers to an embedded png in the project. Make sure to embed your resources! Google it
            string resourceName = "Knives/Resources/Cooper_helmet";

            //Create new GameObject
            GameObject obj = new GameObject(itemName);

            //Add a PassiveItem component to the object
            var item = obj.AddComponent<Pilots_Helmet>();

            //Adds a sprite component to the object and adds your texture to the item sprite collection
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);

            //Ammonomicon entry variables
            string shortDesc = "Speed Is Life";
            string longDesc =
                "Allows user to wallride and trigger jump booster over pits." +
                "\n\n\n - Knife_to_a_Gunfight";

            //Adds the item to the gungeon item list, the ammonomicon, the loot table, etc.
            //Do this after ItemBuilder.AddSpriteToObject!
            ItemBuilder.SetupItem(item, shortDesc, longDesc, "ski");

            

            item.quality = PickupObject.ItemQuality.B;
        }

        public override void Pickup(PlayerController player)
        {
            PassiveItem.IncrementFlag(player, typeof(PegasusBootsItem));
            player.OnIsRolling += Player_OnIsRolling;
            base.Pickup(player);
        }


        private void Player_OnIsRolling(PlayerController obj)
        {
            obj.SetIsFlying(true, "JumpPack");
            rollFly = true;
        }

        public override DebrisObject Drop(PlayerController player)
        {
            PassiveItem.DecrementFlag(player, typeof(PegasusBootsItem));
            player.OnIsRolling -= Player_OnIsRolling;
            return base.Drop(player);
        }
        public float CoyoteTime = .25f;
        public override void  Update()
        {
            if(this.Owner != null)
            {
                PlayerController user = this.Owner;
                RoomHandler room;
                room = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector2Extensions.ToIntVector2(user.CenterPosition, VectorConversions.Round));
                CellData cellaim = room.GetNearestCellToPosition(user.CenterPosition);
                CellData cellaimmunis = room.GetNearestCellToPosition(user.CenterPosition - new Vector2(0, 1.2f));

                //wallride state
                if (cellaim.HasWallNeighbor(true, true) != false && cellaimmunis.HasWallNeighbor(true, true) != false)
                {
                    if (user.Velocity.magnitude >= 0)
                    {
                        user.FallingProhibited = true;
                        CoyoteTime = .25f;
                        user.knockbackDoer.ApplyKnockback(user.NonZeroLastCommandedDirection, .5f);
                    }
                   
                }
                else
                {
                    if(CoyoteTime < 0)
                    {
                        user.FallingProhibited = false;
                    }
                    CoyoteTime -= Time.deltaTime;
                }

                if (rollFly)
                {
                    rollFly = false;
                    this.Owner.SetIsFlying(false, "JumpPack");
                }
            }
            base.Update();
        }


    }
}