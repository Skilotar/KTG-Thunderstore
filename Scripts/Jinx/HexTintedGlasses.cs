using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ItemAPI;

namespace Knives
{
    class HexGlasses : PassiveItem
    {
        public static void Register()
        {

            string itemName = "Hex Tinted Glasses";


            string resourceName = "Knives/Resources/HexGlasses";


            GameObject obj = new GameObject(itemName);


            var item = obj.AddComponent<HexGlasses>();


            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);

            //Ammonomicon entry variables
            string shortDesc = "Gamble Your Life";
            string longDesc = "Greatly Increases damage upon being Hexed. Taking damage hexes user. Creatures afflicted with [Hex] may be damaged upon attacking.\n\n\n - Knife_to_a_Gunfight";

            //Adds the item to the gungeon item list, the ammonomicon, the loot table, etc.
            //Do this after ItemBuilder.AddSpriteToObject!
            ItemBuilder.SetupItem(item, shortDesc, longDesc, "ski");

            //Adds the actual passive effect to the item




            item.CanBeDropped = false;
            item.PersistsOnDeath = true;
            item.quality = PickupObject.ItemQuality.B;
            itemID = item.PickupObjectId;
            Remove_from_lootpool.RemovePickupFromLootTables(item);

            JinxItemDisplayStorageClass text = item.gameObject.GetOrAddComponent<JinxItemDisplayStorageClass>();
            text.jinxItemDisplayText = "Grants crits while aflicted by Hex";

        }

        public static int itemID;
        public override void Pickup(PlayerController player)
        {
            player.healthHaver.OnDamaged += HealthHaver_OnDamaged;

            base.Pickup(player);
        }
        public override DebrisObject Drop(PlayerController player)
        {
            player.healthHaver.OnDamaged -= HealthHaver_OnDamaged;

            return base.Drop(player);
        }

        private void HealthHaver_OnDamaged(float resultValue, float maxValue, CoreDamageTypes damageTypes, DamageCategory damageCategory, Vector2 damageDirection)
        {
            HexStatusEffectController hexen = this.Owner.gameObject.GetOrAddComponent<HexStatusEffectController>();
            hexen.statused = true;

            AkSoundEngine.PostEvent("Play_Hex_laugh_001", base.gameObject);
        }

        public override void  Update()
        {
            base.Update();
            if (this.Owner.gameObject.GetComponent<HexStatusEffectController>())
            {
                if (this.Owner.gameObject.GetComponent<HexStatusEffectController>().statused)
                {

                    
                    RemoveStat(PlayerStats.StatType.Damage);
                    AddStat(PlayerStats.StatType.Damage, 2f);
                    

                    this.Owner.stats.RecalculateStats(Owner, true);
                }
                if (!this.Owner.gameObject.GetComponent<HexStatusEffectController>().statused)
                {

                   
                    RemoveStat(PlayerStats.StatType.Damage);
                    AddStat(PlayerStats.StatType.Damage, 0f);
                    

                    this.Owner.stats.RecalculateStats(Owner, true);
                }
            }

        }
        private void AddStat(PlayerStats.StatType statType, float amount, StatModifier.ModifyMethod method = StatModifier.ModifyMethod.ADDITIVE)
        {
            StatModifier modifier = new StatModifier();
            modifier.amount = amount;
            modifier.statToBoost = statType;
            modifier.modifyType = method;

            foreach (var m in passiveStatModifiers)
            {
                if (m.statToBoost == statType) return; //don't add duplicates
            }

            if (this.passiveStatModifiers == null)
                this.passiveStatModifiers = new StatModifier[] { modifier };
            else
                this.passiveStatModifiers = this.passiveStatModifiers.Concat(new StatModifier[] { modifier }).ToArray();
        }


        //Removes a stat
        private void RemoveStat(PlayerStats.StatType statType)
        {
            var newModifiers = new List<StatModifier>();
            for (int i = 0; i < passiveStatModifiers.Length; i++)
            {
                if (passiveStatModifiers[i].statToBoost != statType)
                    newModifiers.Add(passiveStatModifiers[i]);
            }
            this.passiveStatModifiers = newModifiers.ToArray();
        }
    }
}
