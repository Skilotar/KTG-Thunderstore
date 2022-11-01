using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using ItemAPI;
using Dungeonator;
using System.Reflection;
using Random = System.Random;
using FullSerializer;
using System.Collections;
using Gungeon;
using MonoMod.RuntimeDetour;



namespace Knives
{
    public class terracottaIoun : IounStoneOrbitalItem
    {
        public static void Register()
        {
            string name = "clayshield";
            string resourcePath = "Knives/Resources/clay_shields";
            GameObject gameObject = new GameObject();
            terracottaIoun rock = gameObject.AddComponent<terracottaIoun>();
            ItemBuilder.AddSpriteToObject(name, resourcePath, gameObject);
            string shortDesc = "Fragile Bastion";
            string longDesc = "A dusty shield made of clay.\n\n" +
                "" +
                "\n\n\n - Knife_to_a_Gunfight";
            rock.SetupItem(shortDesc, longDesc, "ski");
            rock.quality = PickupObject.ItemQuality.EXCLUDED;
            terracottaIoun.BuildPrefab();

            rock.OrbitalPrefab = terracottaIoun.orbitalPrefab;
            rock.BreaksUponContact = true;
            rock.Identifier = IounStoneOrbitalItem.IounStoneIdentifier.CLEAR;
            rock.suppressPickupVFX = true;
            Clay = rock;
            
        }
        public static IounStoneOrbitalItem Clay;

        public static void BuildPrefab()
        {
            bool flag = terracottaIoun.orbitalPrefab != null;
            if (!flag)
            {
                GameObject gameObject = SpriteBuilder.SpriteFromResource("Knives/Resources/clay_shields", null);
                gameObject.name = "ClayShield";
                SpeculativeRigidbody speculativeRigidbody = gameObject.GetComponent<tk2dSprite>().SetUpSpeculativeRigidbody(new IntVector2(6, 7), new IntVector2(13, 14));
                speculativeRigidbody.CollideWithTileMap = false;
                speculativeRigidbody.CollideWithOthers = true;
                
                speculativeRigidbody.PrimaryPixelCollider.CollisionLayer = CollisionLayer.EnemyBulletBlocker;
                terracottaIoun.orbitalPrefab = gameObject.AddComponent<PlayerOrbital>();
                
                terracottaIoun.orbitalPrefab.motionStyle = PlayerOrbital.OrbitalMotionStyle.ORBIT_PLAYER_ALWAYS;
                terracottaIoun.orbitalPrefab.orbitDegreesPerSecond = 90f;
                terracottaIoun.orbitalPrefab.shouldRotate = false;
                terracottaIoun.orbitalPrefab.orbitRadius = 2f;
                terracottaIoun.orbitalPrefab.SetOrbitalTier(40);
                terracottaIoun.orbitalPrefab.PreventOutline = true;
                terracottaIoun.orbitalPrefab.gameObject.GetOrAddComponent<FragileGuonController>();
                
                UnityEngine.Object.DontDestroyOnLoad(gameObject);
                FakePrefab.MarkAsFakePrefab(gameObject);
                gameObject.SetActive(false);
                
                

            }
        }
       

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);

            terracottaIoun.guonHook = new Hook(typeof(PlayerOrbital).GetMethod("Initialize"), typeof(terracottaIoun).GetMethod("GuonInit"));
            bool flag = player.gameObject.GetComponent<terracottaIoun.BaBoom>() != null;
            bool flag2 = flag;
            bool flag3 = flag2;
            bool flag4 = flag3;
            if (flag4)
            {
                player.gameObject.GetComponent<terracottaIoun.BaBoom>().Destroy();
            }
            player.gameObject.AddComponent<terracottaIoun.BaBoom>();
            GameManager.Instance.OnNewLevelFullyLoaded += this.FixGuon;

            


        }


        public static void GuonInit(Action<PlayerOrbital, PlayerController> orig, PlayerOrbital self, PlayerController player)
        {
            orig(self, player);
        }
        private void FixGuon()
        {

        }


        public override void  Update()
        {




            base.Update();
        }

        public override void  OnDestroy()
        {
            terracottaIoun.speedUp = false;
            base.OnDestroy();
        }

        public static bool speedUp = false;
        public static PlayerOrbital orbitalPrefab;
        public List<IPlayerOrbital> orbitals = new List<IPlayerOrbital>();
        public static Hook guonHook;

        

        private class BaBoom : BraveBehaviour
        {
            // Token: 0x06000B0A RID: 2826 RVA: 0x0005EB58 File Offset: 0x0005CD58
            private void Start()
            {
                this.owner = base.GetComponent<PlayerController>();
            }

            // Token: 0x06000B0B RID: 2827 RVA: 0x0005EB67 File Offset: 0x0005CD67
            public void Destroy()
            {
                UnityEngine.Object.Destroy(this);
            }

            // Token: 0x040005BC RID: 1468
            private PlayerController owner;
        }
    }

}
