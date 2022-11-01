using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using ItemAPI;
using MonoMod;
using System.Reflection;
using Gungeon;
using System.Collections.Generic;

namespace Knives
{
    class Riot_Drill : PlayerItem
    {
        public static void Register()
        {
            string itemName = "Riot Drill";

            string resourceName = "Knives/Resources/RiotDrill";

            GameObject obj = new GameObject(itemName);

            var item = obj.AddComponent<Riot_Drill>();

            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);

            //Ammonomicon entry variables
            string shortDesc = "You Know The Drill";
            string longDesc = "A launchable thermite grinder designed for pushing enemies out from behind cover. "

                 +
                "\n\n\n - Knife_to_a_Gunfight";

            //Adds the item to the gungeon item list, the ammonomicon, the loot table, etc.
            //Do this after ItemBuilder.AddSpriteToObject!
            ItemBuilder.SetupItem(item, shortDesc, longDesc, "ski");

            //Adds the actual passive effect to the item

            ItemBuilder.SetCooldownType(item, ItemBuilder.CooldownType.Damage, 200f);

            List<string> BeamAnimPaths = new List<string>()
            {
                "Knives/Resources/BeamSprites/Flatbeam_mid_001",
                "Knives/Resources/BeamSprites/Flatbeam_mid_002",
                "Knives/Resources/BeamSprites/Flatbeam_mid_003",
                "Knives/Resources/BeamSprites/Flatbeam_mid_004",
                "Knives/Resources/BeamSprites/Flatbeam_mid_005",
                "Knives/Resources/BeamSprites/Flatbeam_mid_006",
                "Knives/Resources/BeamSprites/Flatbeam_mid_007",
                "Knives/Resources/BeamSprites/Flatbeam_mid_008",
                "Knives/Resources/BeamSprites/Flatbeam_mid_009",
                "Knives/Resources/BeamSprites/Flatbeam_mid_010",
                "Knives/Resources/BeamSprites/Flatbeam_mid_011",
                "Knives/Resources/BeamSprites/Flatbeam_mid_012",

            };
            List<string> BeamEndPaths = new List<string>()
            {
               "Knives/Resources/BeamSprites/Flatbeam_end_001",

            };
            List<string> BeamStartPaths = new List<string>()
            {
                "Knives/Resources/BeamSprites/Flatbeam_start_001",
            };

            Projectile projectile = UnityEngine.Object.Instantiate<Projectile>((PickupObjectDatabase.GetById(86) as Gun).DefaultModule.projectiles[0]);
            BasicBeamController beamComp = projectile.GenerateBeamPrefab(
              "Knives/Resources/BeamSprites/Flatbeam_mid_001",
               new Vector2(12, 9),
               new Vector2(0, 1),
               BeamAnimPaths,
               9,
               //Impact
               null,
               -1,
               null,
               null,
               //End
               BeamEndPaths,
               1,
               new Vector2(8, 9),
               new Vector2(0, 1),
               //Beginning
               BeamStartPaths,
               1,
               new Vector2(8, 9),
               new Vector2(0, 1)
               );

            projectile.gameObject.SetActive(false);
            projectile.baseData.damage *= 4;
            projectile.baseData.range *= 2;
            projectile.baseData.speed *= 4;
            projectile.PenetratesInternalWalls = true;
            
            FakePrefab.MarkAsFakePrefab(projectile.gameObject);
            UnityEngine.Object.DontDestroyOnLoad(projectile);
            beamComp.boneType = BasicBeamController.BeamBoneType.Straight;
            beamComp.interpolateStretchedBones = false;
            beamComp.PenetratesCover = true;
            
            beamComp.ContinueBeamArtToWall = true;
            DrillBeam = projectile;
            item.quality = PickupObject.ItemQuality.B;
        }
        public static bool shouldBeFlipped = false;
        public static Projectile DrillBeam;
        public override void Pickup(PlayerController player)
        {

          
            base.Pickup(player);
        }

       
        public override void  OnPreDrop(PlayerController player)
        {

            
            base.OnPreDrop(player);
        }
        public override void  DoEffect(PlayerController player)
        {
            
           
            Projectile projectile = ((Gun)ETGMod.Databases.Items[83]).DefaultModule.projectiles[0];
            GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, player.CurrentGun.sprite.WorldCenter, Quaternion.Euler(0f, 0f, (player.CurrentGun == null) ? 0f : player.CurrentGun.CurrentAngle), true);
            Projectile component = gameObject.GetComponent<Projectile>();
            bool flag2 = component != null;
            if (flag2)
            {
                component.Owner = player;
                component.Shooter = player.specRigidbody;
                component.baseData.damage = 2f;
                DrillSticksInWall drill = component.gameObject.GetOrAddComponent<DrillSticksInWall>();
                drill.Drill = DrillBeam; // Drill 
            }


        }

        
       
    }
    public class DrillSticksInWall : MonoBehaviour
    {
        public DrillSticksInWall()
        {
           
        }
        public Projectile Drill;
        private void Start()
        {
            this.m_projectile = base.GetComponent<Projectile>();
            if (this.m_projectile.Owner is PlayerController)
            {
                this.projOwner = this.m_projectile.Owner as PlayerController;
            }
            SpeculativeRigidbody specRigidBody = this.m_projectile.specRigidbody;
            this.m_projectile.BulletScriptSettings.surviveTileCollisions = true;
            this.m_projectile.BulletScriptSettings.surviveRigidbodyCollisions = true;
            this.m_projectile.pierceMinorBreakables = true;
            specRigidBody.OnCollision += this.OnCollision;
            m_projectile.specRigidbody.OnPreRigidbodyCollision = (SpeculativeRigidbody.OnPreRigidbodyCollisionDelegate)Delegate.Combine(m_projectile.specRigidbody.OnPreRigidbodyCollision, new SpeculativeRigidbody.OnPreRigidbodyCollisionDelegate(this.OnPreCollison));

        }

        private void OnPreCollison(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)//Non Wall Collision
        {
            if (otherRigidbody.aiActor)
            {

            }
            else
            {
                if (!otherRigidbody.minorBreakable)
                {
                    DoStop();
                }
            }
            
        }

        private void OnCollision(CollisionData tileCollision) //tile collision
        {
            DoStop();
        }

        public void DoStop()
        {
            this.m_projectile.baseData.speed *= 0.0001f;
            this.m_projectile.UpdateSpeed();

            PhysicsEngine.PostSliceVelocity = new Vector2?(default(Vector2));
            SpeculativeRigidbody specRigidbody = this.m_projectile.specRigidbody;
            specRigidbody.OnCollision -= this.OnCollision;
            StartCoroutine(FireDrill());
            StartCoroutine(DeathTimer());
        }
        
        private IEnumerator FireDrill()
        {
            yield return new WaitForSeconds(.01f);
            
            BeamBulletsBehaviour beambullets = m_projectile.gameObject.GetOrAddComponent<BeamBulletsBehaviour>();
            beambullets.beamToFire = Drill;
            beambullets.firetype = BeamBulletsBehaviour.FireType.FORWARDS;
            BasicBeamController beam = beambullets.beamToFire.gameObject.GetComponent<BasicBeamController>();
            beam.specRigidbody.OnPreRigidbodyCollision = (SpeculativeRigidbody.OnPreRigidbodyCollisionDelegate)Delegate.Combine(m_projectile.specRigidbody.OnPreRigidbodyCollision, new SpeculativeRigidbody.OnPreRigidbodyCollisionDelegate(this.OnPreCollisonBeam));

            //https://github.com/Nevernamed22/OnceMoreIntoTheBreach/blob/master/MakingAnItem/Stuff%20Items/Misc%20Passives/LaserBullets.cs

        }

        private void OnPreCollisonBeam(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherbody, PixelCollider otherPixelCollider)
        {
            if (otherbody != null && otherbody.aiActor != null)
            {
               
                
            }

            if (otherbody != null && otherbody.aiActor == null)
            {
                PhysicsEngine.SkipCollision = true;
            }



        }

        private IEnumerator DeathTimer()
        {
            yield return new WaitForSeconds(5f);
            this.m_projectile.DieInAir();
        }

        private Projectile m_projectile;
        private float m_hitNormal;
        private PlayerController projOwner;
        
    }
}


