
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// using Alexandria.ItemAPI;    -- add me back
using UnityEngine;
using static AkMIDIEvent;
using ItemAPI; // -- remove me
using System.Collections;

namespace Knives
{
    class VultureAde : PassiveItem
    {
        

        public static void Init()
        {
            string ItemName = "Vulture Ade";

            string SpriteDirectory = "Knives/Resources/rubberbandman"; // repair spritepath to original
            GameObject obj = new GameObject(ItemName);

            var item = obj.AddComponent<VultureAde>();

            ItemBuilder.AddSpriteToObject(ItemName, SpriteDirectory, obj);

            string shortDesc = "Everything comes easy";

            string longDesc = "A brew made by group 935 to increase everything else. \n\n" +
            "Enough to survive the apocalypse on your own\n\n";


            ItemBuilder.SetupItem(item, shortDesc, longDesc, "dls");


            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.AmmoCapacityMultiplier, 1.25f, StatModifier.ModifyMethod.MULTIPLICATIVE);

            item.quality = PickupObject.ItemQuality.B;
        }


        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            player.OnAnyEnemyReceivedDamage += OnPlayerkills;
            
        }
        public override DebrisObject Drop(PlayerController player)
        {
            player.OnAnyEnemyReceivedDamage -= OnPlayerkills;
            BreakStealth(this.Owner);
            UnhandleRadialIndicator();
            return base.Drop(player);
        }

        public override void  Update()
        {

            if(this.Owner != null)
            {
                if (m_indicator != null)
                {
                    if (Vector2.Distance(this.Owner.CenterPosition, m_indicator.transform.position) <= Radius)
                    {
                        if(ToggleEffect == false)// entered radius do stealth once
                        {
                            
                            DoStealthyBits(this.Owner);
                            ToggleEffect = true;
                        }
                    }
                    else 
                    {
                        if (ToggleEffect == true)// was in radius now leaving remove stealth 
                        {
                            
                            BreakStealth(this.Owner);
                            ToggleEffect = false;
                        }
                    }
                }

            }
            base.Update();
        }
        public void OnPlayerkills(float damage, bool enemykilled, HealthHaver enemy)
        {
            if (enemykilled && m_indicator == null && internalCooldown == false)
            {
                if (UnityEngine.Random.Range(1, 11) == 1) // 1 in 10 chance
                {
                    Vector2 position = enemy.gameActor.CenterPosition;
                    HandleRadialIndicator(position);
                    StartCoroutine(CircleTimer());
                    internalCooldown = true;
                }
            }
        }

        private void DoStealthyBits(PlayerController player)
        {
            
            player.ChangeSpecialShaderFlag(1, 1f);
            player.SetIsStealthed(true, "Vulture Ade");
            player.SetCapableOfStealing(true, "Vulture Ade", null);
        }

        private void BreakStealth(PlayerController obj)
        {
            obj.ChangeSpecialShaderFlag(1, 0f);
            obj.SetIsStealthed(false, "Vulture Ade");
            obj.SetCapableOfStealing(false, "Vulture Ade", null);

        }

        private IEnumerator CircleTimer()
        {
            yield return new WaitForSeconds(4);
            BreakStealth(this.Owner);
            UnhandleRadialIndicator();
            yield return new WaitForSeconds(16);
            internalCooldown = false;
        }

        
       
        public float Radius = 3f;
        public bool ToggleEffect = false;
        public bool internalCooldown = false;
        private void HandleRadialIndicator(Vector2 centerPosition)
        {

            bool flag = !this.m_indicator;
            if (flag)
            {

                this.m_indicator = ((GameObject)UnityEngine.Object.Instantiate(ResourceCache.Acquire("Global VFX/HeatIndicator"), centerPosition, Quaternion.identity)).GetComponent<HeatIndicatorController>();
                this.m_indicator.CurrentColor = Color.magenta.WithAlpha(1f);
                this.m_indicator.CurrentRadius = Radius;
                this.m_indicator.IsFire = false;
                
            }
        }

        private void UnhandleRadialIndicator()
        {
            bool flag = this.m_indicator;
            if (flag)
            {
                this.m_indicator.EndEffect();
                this.m_indicator = null;
                
            }
        }
        public HeatIndicatorController m_indicator;
    }
}