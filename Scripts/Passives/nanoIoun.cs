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
    public class nanostone : IounStoneOrbitalItem
    {
        public static void Register()
        {
            string name = "nanostone";
            string resourcePath = "Knives/Resources/Nano_ioun_stone";
            GameObject gameObject = new GameObject();
            nanostone rock = gameObject.AddComponent<nanostone>();
            ItemBuilder.AddSpriteToObject(name, resourcePath, gameObject);
            string shortDesc = "Autoimmune Response";
            string longDesc = "Drones used to monitor people currently going through an overdose of nanite based cereal." +
                "\n\n\n - Knife_to_a_Gunfight";
            rock.SetupItem(shortDesc, longDesc, "ski");
            rock.quality = PickupObject.ItemQuality.EXCLUDED;
            nanostone.BuildPrefab();

            rock.OrbitalPrefab = nanostone.orbitalPrefab;

            rock.Identifier = IounStoneOrbitalItem.IounStoneIdentifier.CLEAR;

            ID = rock.PickupObjectId;
        }

        public static int ID;


        public static void BuildPrefab()
        {
            bool flag = nanostone.orbitalPrefab != null;
            if (!flag)
            {
                GameObject gameObject = SpriteBuilder.SpriteFromResource("Knives/Resources/Nano_ioun_stone", null);
                gameObject.name = "nano";
                SpeculativeRigidbody speculativeRigidbody = gameObject.GetComponent<tk2dSprite>().SetUpSpeculativeRigidbody(IntVector2.Zero, new IntVector2(14, 14));
                speculativeRigidbody.CollideWithTileMap = false;
                speculativeRigidbody.CollideWithOthers = true;

                speculativeRigidbody.PrimaryPixelCollider.CollisionLayer = CollisionLayer.EnemyBulletBlocker;
                nanostone.orbitalPrefab = gameObject.AddComponent<PlayerOrbital>();
                nanostone.orbitalPrefab.motionStyle = PlayerOrbital.OrbitalMotionStyle.ORBIT_PLAYER_ALWAYS;
                nanostone.orbitalPrefab.orbitDegreesPerSecond = 90f;
                nanostone.orbitalPrefab.shouldRotate = false;
                nanostone.orbitalPrefab.orbitRadius = 2.8f;
                GlassBoi.orbitalPrefab.SetOrbitalTier(0);
                UnityEngine.Object.DontDestroyOnLoad(gameObject);
                FakePrefab.MarkAsFakePrefab(gameObject);
                gameObject.SetActive(false);


            }
        }


        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);

            Stopda.guonHook = new Hook(typeof(PlayerOrbital).GetMethod("Initialize"), typeof(Stopda).GetMethod("GuonInit"));
            bool flag = player.gameObject.GetComponent<nanostone.BaBoom>() != null;
            bool flag2 = flag;
            bool flag3 = flag2;
            bool flag4 = flag3;
            if (flag4)
            {
                player.gameObject.GetComponent<nanostone.BaBoom>().Destroy();
            }
            player.gameObject.AddComponent<nanostone.BaBoom>();
            GameManager.Instance.OnNewLevelFullyLoaded += this.FixGuon;
            bool flag5 = this.m_extantOrbital != null;
            bool flag6 = flag5;
            bool flag7 = flag6;
            if (flag7)
            {
                
            }


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
            nanostone.speedUp = false;
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
