
using System;
using ItemAPI;
using Dungeonator;
using Gungeon;
using SaveAPI;

using Object = UnityEngine.Object;
using System.Collections;
using UnityEngine;

namespace Knives
{
    class Umbra_Shoot : AdvancedGunBehaviour
    {


        public static void Add()
        {
            // Get yourself a new gun "base" first.
            // Let's just call it "Basic Gun", and use "jpxfrd" for all sprites and as "codename" All sprites must begin with the same word as the codename. For example, your firing sprite would be named "jpxfrd_fire_001".
            Gun gun = ETGMod.Databases.Items.NewGun("Umbra_shoot", "Umbra_Shoot");
            // "kp:basic_gun determines how you spawn in your gun through the console. You can change this command to whatever you want, as long as it follows the "name:itemname" template.
            Game.Items.Rename("outdated_gun_mods:umbra_shoot", "ski:umbra_shoot");
            gun.gameObject.AddComponent<Umbra_Shoot>();
            //These two lines determines the description of your gun, ".SetShortDescription" being the description that appears when you pick up the gun and ".SetLongDescription" being the description in the Ammonomicon entry. 
            gun.SetShortDescription("GunBrella");
            gun.SetLongDescription("A single shot rifle consealed in plain sight by a small sheet of high flexability kevlar. This weapon was used to assassinate the ruthless Queen Elizabeth the LXI on a particularly rainy day in new new england." +
                "Fortunately for the resistance spy the gaurds did not find it suspitious that the shadowy figure lurking through the crowd was deciding to get soaked rather then use the umbrella he was carrying." +
                "\n\n" +
                "--------------------------------------" +
                "3 strike combo! Attack rapidly to slash, shoot, and block. Hold 3rd hit for extended blocking." +
                                   "\n\n\n - Knife_to_a_Gunfight"); ;


            gun.SetupSprite(null, "Umbra_Shoot_idle_001", 8);


            gun.SetAnimationFPS(gun.shootAnimation, 17);
            gun.SetAnimationFPS(gun.reloadAnimation, 17);

            gun.AddProjectileModuleFrom(PickupObjectDatabase.GetByEncounterName("M1") as Gun, true, false);



            gun.DefaultModule.ammoCost = 1;
            gun.DefaultModule.angleVariance = 0;
            gun.gunClass = GunClass.SILLY;
            gun.gunHandedness = GunHandedness.TwoHanded;

            gun.DefaultModule.shootStyle = ProjectileModule.ShootStyle.SemiAutomatic;
            gun.DefaultModule.sequenceStyle = ProjectileModule.ProjectileSequenceStyle.Random;

            gun.reloadTime = 1.4f;
            gun.DefaultModule.numberOfShotsInClip = 2;
            gun.DefaultModule.cooldownTime = .5f;



            gun.InfiniteAmmo = true;
            gun.quality = PickupObject.ItemQuality.EXCLUDED;


            //swipe
            Projectile projectile = UnityEngine.Object.Instantiate<Projectile>(gun.DefaultModule.projectiles[0]);
            gun.barrelOffset.transform.localPosition = new Vector3(0f, 0f, 0f);
            projectile.gameObject.SetActive(false);
            FakePrefab.MarkAsFakePrefab(projectile.gameObject);
            UnityEngine.Object.DontDestroyOnLoad(projectile);
            gun.DefaultModule.projectiles[0] = projectile;
            projectile.baseData.damage = 20f;
            projectile.baseData.speed *= 1f;
            projectile.baseData.range = 20f;
            projectile.baseData.force = 15;
            projectile.AdditionalScaleMultiplier = 1.1f;
            gun.SetBaseMaxAmmo(300);
            gun.ammo = 300;
            gun.muzzleFlashEffects = new VFXPool { type = VFXPoolType.None, effects = new VFXComplex[0] };

            //offsets
            tk2dSpriteAnimationClip fireClip2 = gun.sprite.spriteAnimator.GetClipByName("Umbra_Shoot_idle");
            float[] offsetsX = new float[] { -0.1f };
            float[] offsetsY = new float[] { -0.100f };
            for (int i = 0; i < offsetsX.Length && i < offsetsY.Length && i < fireClip2.frames.Length; i++)
            {
                int id = fireClip2.frames[i].spriteId;
                fireClip2.frames[i].spriteCollection.spriteDefinitions[id].position0.x += offsetsX[i];
                fireClip2.frames[i].spriteCollection.spriteDefinitions[id].position0.y += offsetsY[i];
                fireClip2.frames[i].spriteCollection.spriteDefinitions[id].position1.x += offsetsX[i];
                fireClip2.frames[i].spriteCollection.spriteDefinitions[id].position1.y += offsetsY[i];
                fireClip2.frames[i].spriteCollection.spriteDefinitions[id].position2.x += offsetsX[i];
                fireClip2.frames[i].spriteCollection.spriteDefinitions[id].position2.y += offsetsY[i];
                fireClip2.frames[i].spriteCollection.spriteDefinitions[id].position3.x += offsetsX[i];
                fireClip2.frames[i].spriteCollection.spriteDefinitions[id].position3.y += offsetsY[i];
            }
            tk2dSpriteAnimationClip fireClip = gun.sprite.spriteAnimator.GetClipByName("Umbra_Shoot_fire");
            float universalX = -.1f;
            float universaly = -.1f;
            float[] offsetsX2 = new float[] { 0.0625f +universalX, 0.0625f + universalX, 0.1875f + universalX };
            float[] offsetsY2 = new float[] { -0.0625f +universaly, -0.0625f + universaly, 0.0000f + universaly };
            for (int i = 0; i < offsetsX2.Length && i < offsetsY2.Length && i < fireClip.frames.Length; i++)
            {
                int id = fireClip.frames[i].spriteId;
                fireClip.frames[i].spriteCollection.spriteDefinitions[id].position0.x += offsetsX2[i];
                fireClip.frames[i].spriteCollection.spriteDefinitions[id].position0.y += offsetsY2[i];
                fireClip.frames[i].spriteCollection.spriteDefinitions[id].position1.x += offsetsX2[i];
                fireClip.frames[i].spriteCollection.spriteDefinitions[id].position1.y += offsetsY2[i];
                fireClip.frames[i].spriteCollection.spriteDefinitions[id].position2.x += offsetsX2[i];
                fireClip.frames[i].spriteCollection.spriteDefinitions[id].position2.y += offsetsY2[i];
                fireClip.frames[i].spriteCollection.spriteDefinitions[id].position3.x += offsetsX2[i];
                fireClip.frames[i].spriteCollection.spriteDefinitions[id].position3.y += offsetsY2[i];
            }
            tk2dSpriteAnimationClip fireClip3 = gun.sprite.spriteAnimator.GetClipByName("Umbra_Shoot_reload");
            float[] offsetsX3 = new float[] { 0.0250f };
            float[] offsetsY3 = new float[] { -0.1000f };
            for (int i = 0; i < offsetsX.Length && i < offsetsY.Length && i < fireClip2.frames.Length; i++)
            {
                int id = fireClip3.frames[i].spriteId;
                fireClip3.frames[i].spriteCollection.spriteDefinitions[id].position0.x += offsetsX3[i];
                fireClip3.frames[i].spriteCollection.spriteDefinitions[id].position0.y += offsetsY3[i];
                fireClip3.frames[i].spriteCollection.spriteDefinitions[id].position1.x += offsetsX3[i];
                fireClip3.frames[i].spriteCollection.spriteDefinitions[id].position1.y += offsetsY3[i];
                fireClip3.frames[i].spriteCollection.spriteDefinitions[id].position2.x += offsetsX3[i];
                fireClip3.frames[i].spriteCollection.spriteDefinitions[id].position2.y += offsetsY3[i];
                fireClip3.frames[i].spriteCollection.spriteDefinitions[id].position3.x += offsetsX3[i];
                fireClip3.frames[i].spriteCollection.spriteDefinitions[id].position3.y += offsetsY3[i];
            }




            projectile.transform.parent = gun.barrelOffset;
            ETGMod.Databases.Items.Add(gun, null, "ANY");

            Umbra_Shoot.SecondID = gun.PickupObjectId;
        }


        public static int SecondID;

        public System.Random rng = new System.Random();



        public override void OnPostFired(PlayerController player, Gun gun)
        {

            gun.PreventNormalFireAudio = true;
        }

        public override void PostProcessProjectile(Projectile projectile)
        {
            
            base.PostProcessProjectile(projectile);
        }
        
        private bool HasReloaded;

        public override void  Update()
        {
            PlayerController player = this.gun.CurrentOwner as PlayerController;
            if (gun.CurrentOwner)
            {

                if (!gun.PreventNormalFireAudio)
                {
                    this.gun.PreventNormalFireAudio = true;
                }
                if (!gun.IsReloading && !HasReloaded)
                {
                    this.HasReloaded = true;
                }
                //if (this.gun.CurrentOwner.healthHaver.GetCurrentHealthPercentage() == 0)
                {
                    //UnityEngine.GameObject.Destroy(this);
                }


            }




        }


        public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
        {
            if (gun.IsReloading && this.HasReloaded)
            {


                HasReloaded = false;
                AkSoundEngine.PostEvent("Stop_WPN_All", base.gameObject);

                base.OnReloadPressed(player, gun, bSOMETHING);


            }

        }



    }
}
