using ItemAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Knives
{
    class EasyGoopDefinitions
    {
        //Basegame Goops
        public static GoopDefinition FireDef;
        public static GoopDefinition OilDef;
        public static GoopDefinition PoisonDef;
        public static GoopDefinition BlobulonGoopDef;
        public static GoopDefinition WebGoop;
        public static GoopDefinition WaterGoop;
        public static GoopDefinition CharmGoopDef = PickupObjectDatabase.GetById(310)?.GetComponent<WingsItem>()?.RollGoop;
        public static GoopDefinition GreenFireDef = (PickupObjectDatabase.GetById(698) as Gun).DefaultModule.projectiles[0].GetComponent<GoopModifier>().goopDefinition;
        public static GoopDefinition CheeseDef = (PickupObjectDatabase.GetById(808) as Gun).DefaultModule.projectiles[0].GetComponent<GoopModifier>().goopDefinition;

        
        
        public static GoopDefinition EnemyFriendlyFireGoop;
        
        public static GoopDefinition PlayerFriendlyFireGoop;
        
        public static void DefineDefaultGoops()
        {
            //Sets up the goops that have to be extracted from asset bundles
            AssetBundle assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
            EasyGoopDefinitions.goopDefs = new List<GoopDefinition>();
            foreach (string text in EasyGoopDefinitions.goops)
            {
                GoopDefinition goopDefinition;
                try
                {
                    GameObject gameObject = assetBundle.LoadAsset(text) as GameObject;
                    goopDefinition = gameObject.GetComponent<GoopDefinition>();
                }
                catch
                {
                    goopDefinition = (assetBundle.LoadAsset(text) as GoopDefinition);
                }
                goopDefinition.name = text.Replace("assets/data/goops/", "").Replace(".asset", "");
                EasyGoopDefinitions.goopDefs.Add(goopDefinition);
            }
            List<GoopDefinition> list = EasyGoopDefinitions.goopDefs;

            //Define the asset bundle goops
            FireDef = EasyGoopDefinitions.goopDefs[0];
            OilDef = EasyGoopDefinitions.goopDefs[1];
            PoisonDef = EasyGoopDefinitions.goopDefs[2];
            BlobulonGoopDef = EasyGoopDefinitions.goopDefs[3];
            WebGoop = EasyGoopDefinitions.goopDefs[4];
            WaterGoop = EasyGoopDefinitions.goopDefs[5];


            //ENEMYFRIENDLY FIRE - Fire that doesn't hurt enemies
            #region EnemyFriendlyFireGoop
            GoopDefinition midInitFire = UnityEngine.Object.Instantiate<GoopDefinition>(FireDef);
            midInitFire.damagesEnemies = false;
            midInitFire.damagePerSecondtoEnemies = 0;
            midInitFire.fireBurnsEnemies = false;
            midInitFire.AppliesDamageOverTime = false;
            midInitFire.fireDamagePerSecondToEnemies = 0;
            EnemyFriendlyFireGoop = midInitFire;
            #endregion


            //ENEMYFRIENDLY FIRE - Fire that doesn't hurt enemies
            #region PlayerFriendlyFireGoop
            GoopDefinition midInitFrenFire = UnityEngine.Object.Instantiate<GoopDefinition>(FireDef);
            midInitFrenFire.damagesPlayers = false;
            midInitFrenFire.fireDamageToPlayer = 0;
            PlayerFriendlyFireGoop = midInitFrenFire;
            #endregion
        }
        public static GoopDefinition GenerateBloodGoop(float dps, Color Color, float lifeSpan = 20)
        {
            GoopDefinition Blood = ScriptableObject.CreateInstance<GoopDefinition>();
            Blood.CanBeIgnited = false;
            Blood.damagesEnemies = true;
            Blood.damagesPlayers = false;
            Blood.baseColor32 = Color;
            Blood.goopTexture = PoisonDef.goopTexture;
            Blood.lifespan = lifeSpan;
            Blood.usesLifespan = true;
            Blood.damagePerSecondtoEnemies = dps;
            Blood.CanBeElectrified = true;
            Blood.electrifiedTime = 1;
            Blood.electrifiedDamagePerSecondToEnemies = 20;
            Blood.electrifiedDamageToPlayer = 0.5f;
            Blood.goopDamageTypeInteractions = new List<GoopDefinition.GoopDamageTypeInteraction> { new GoopDefinition.GoopDamageTypeInteraction { damageType = CoreDamageTypes.Electric, electrifiesGoop = true } };
            return Blood;
        }
        private static string[] goops = new string[]
        {
            "assets/data/goops/napalmgoopthatworks.asset",
            "assets/data/goops/oil goop.asset",
            "assets/data/goops/poison goop.asset",
            "assets/data/goops/blobulongoop.asset",
            "assets/data/goops/phasewebgoop.asset",
            "assets/data/goops/water goop.asset",
        };
        private static List<GoopDefinition> goopDefs;
    }

}