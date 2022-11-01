
using ItemAPI;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using Brave;
using UnityEngine;
using Dungeonator;

namespace Knives
{
    class IllnessStatusEffectSetup
    {
    

        public static void Init()
        {

            GameActorillnessEffect Standill = StatusEffectHelper.GenerateillnessEffect(2, 1, true, new Color(0.46f, 0.59f, 0.13f), true, new Color(0.46f, 0.59f, 0.13f));
            StaticStatusEffects.StandardillnessEffect = Standill;
        }

     
    }
    public class GameActorillnessEffect : GameActorHealthEffect
    {
        public override void OnDarkSoulsAccumulate(GameActor actor, RuntimeGameActorEffectData effectData, float partialAmount = 1, Projectile sourceProjectile = null)
        {
            
            base.OnDarkSoulsAccumulate(actor, effectData, partialAmount, sourceProjectile);
        }
        public GameActorillnessEffect()
        {
            this.DamagePerSecondToEnemies = 5f;
            TintColor = new Color(0.46f, 0.59f, 0.13f);
            DeathTintColor = new Color(0.46f, 0.59f, 0.13f);
            this.AppliesTint = true;
            this.AppliesDeathTint = true;
            effectIdentifier = "illness";
            duration = 10;
            stackMode = EffectStackingMode.DarkSoulsAccumulate;
            
        }
        public float rampPerSecond = 10f;
        public float currentramp = 0;
       
    }
}
