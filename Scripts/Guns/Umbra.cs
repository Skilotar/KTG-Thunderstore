
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
    class Umbra_main : AdvancedGunBehaviour
    {


        public static void Add()
        {
            // Get yourself a new gun "base" first.
            // Let's just call it "Basic Gun", and use "jpxfrd" for all sprites and as "codename" All sprites must begin with the same word as the codename. For example, your firing sprite would be named "jpxfrd_fire_001".
            Gun gun = ETGMod.Databases.Items.NewGun("Umbra", "Umbra_swing");
            // "kp:basic_gun determines how you spawn in your gun through the console. You can change this command to whatever you want, as long as it follows the "name:itemname" template.
            Game.Items.Rename("outdated_gun_mods:umbra", "ski:umbra");
            gun.gameObject.AddComponent<Umbra_main>();
            //These two lines determines the description of your gun, ".SetShortDescription" being the description that appears when you pick up the gun and ".SetLongDescription" being the description in the Ammonomicon entry. 
            gun.SetShortDescription("GunBrella");
            gun.SetLongDescription("A single shot rifle consealed in plain sight by a small sheet of high flexability kevlar. This weapon was used to assassinate the ruthless Queen Elizabeth the LXI on a particularly rainy day in new new england." +
                "Fortunately for the resistance spy the gaurds did not find it suspitious that the shadowy figure lurking through the crowd was deciding to get soaked rather then use the umbrella he was carrying." +
                "\n\n" +
                "--------------------------------------" +
                "3 strike combo! Attack rapidly to slash, shoot, and block. Hold 3rd hit for extended blocking." +
                                   "\n\n\n - Knife_to_a_Gunfight"); ;


            gun.SetupSprite(null, "Umbra_swing_idle_001", 8);


            gun.SetAnimationFPS(gun.shootAnimation, 17);
            gun.SetAnimationFPS(gun.reloadAnimation, 17);

            gun.AddProjectileModuleFrom(PickupObjectDatabase.GetByEncounterName("Hegemony Rifle") as Gun, true, false);



            gun.DefaultModule.ammoCost = 1;
            gun.DefaultModule.angleVariance = 0;
            gun.gunClass = GunClass.SILLY;
            gun.gunHandedness = GunHandedness.TwoHanded;

            gun.DefaultModule.shootStyle = ProjectileModule.ShootStyle.SemiAutomatic;
            gun.DefaultModule.sequenceStyle = ProjectileModule.ProjectileSequenceStyle.Random;

            gun.reloadTime = 1.4f;
            gun.DefaultModule.numberOfShotsInClip = 8;
            gun.DefaultModule.cooldownTime = .5f;


            gun.SetBaseMaxAmmo(300);
            gun.ammo = 300;
            gun.quality = PickupObject.ItemQuality.B;


            //swipe
            Projectile projectile = UnityEngine.Object.Instantiate<Projectile>(gun.DefaultModule.projectiles[0]);
            gun.barrelOffset.transform.localPosition = new Vector3(0f, 0f, 0f);
            projectile.gameObject.SetActive(false);
            FakePrefab.MarkAsFakePrefab(projectile.gameObject);
            UnityEngine.Object.DontDestroyOnLoad(projectile);
            gun.DefaultModule.projectiles[0] = projectile;
            projectile.baseData.damage = 0f;
            projectile.baseData.speed = 1f;
            projectile.baseData.range = 0f;
            projectile.baseData.force = 0;
            projectile.AdditionalScaleMultiplier = .000001f;
            projectile.SuppressHitEffects = true;
            projectile.sprite.renderer.enabled = false;
            projectile.hitEffects.suppressMidairDeathVfx = true;
            gun.muzzleFlashEffects = new VFXPool { type = VFXPoolType.None, effects = new VFXComplex[0] };

            //offsets
            tk2dSpriteAnimationClip fireClip2 = gun.sprite.spriteAnimator.GetClipByName("Umbra_swing_idle");
            float[] offsetsX = new float[] { 0.6250f };
            float[] offsetsY = new float[] { 0.0000f };
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
            tk2dSpriteAnimationClip fireClip = gun.sprite.spriteAnimator.GetClipByName("Umbra_swing_fire");
            float universalX = 1f;
            float[] offsetsX2 = new float[] { -2f +universalX, -2.2000f + universalX, -1.3125f + universalX, -1.00f + universalX, -1f + universalX, -1f + universalX, -0.8500f + universalX };
            float[] offsetsY2 = new float[] { 0.2f, -0.0825f, 0.0625f, -0.5375f, -2.3500f, -2.3500f, -2.3500f };
            
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
            tk2dSpriteAnimationClip fireClip3 = gun.sprite.spriteAnimator.GetClipByName("Umbra_swing_reload");
            float[] offsetsX3 = new float[] { 0.6250f };
            float[] offsetsY3 = new float[] { 0.0000f };
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

            Umbra_main.BaseID = gun.PickupObjectId;
        }

        public static int BaseID;


        public System.Random rng = new System.Random();
        public int ShouldBeGunstate = 1;
        public static bool BeSlash = true;
        public static bool BeGun = false;
        public static bool BeShield = false;

        public static bool DoTransform = false;


        private IEnumerator delayHandler()
        {
            yield return new WaitForSeconds(1f);
            if(ShouldBeGunstate == 1)
            {
                BeSlash = true;
                BeShield = false;
                ShouldBeGunstate = 2;
            }
            if (ShouldBeGunstate == 2)
            {
                BeSlash = true;
                BeShield = false;
                ShouldBeGunstate = 1;
            }

        }

        public override void OnFinishAttack(PlayerController player, Gun gun)
        {
            StartCoroutine(delayHandler());
            ETGModConsole.Log(ShouldBeGunstate.ToString());
            gun.PreventNormalFireAudio = true;
            base.OnFinishAttack(player, gun);
        }

        public override void PostProcessProjectile(Projectile projectile)
        {
            StartCoroutine(slightslashdelay());

           
            base.PostProcessProjectile(projectile);
        }
        public IEnumerator slightslashdelay()
        {
            yield return new WaitForSeconds(.1f);
            Projectile projectile1 = ((Gun)ETGMod.Databases.Items[15]).DefaultModule.projectiles[0];
            GameObject gameObject = SpawnManager.SpawnProjectile(projectile1.gameObject, this.gun.CurrentOwner.transform.position, Quaternion.Euler(0f, 0f, (this.gun.CurrentOwner.CurrentGun == null) ? 0f : this.gun.CurrentAngle), true);
            Projectile component = gameObject.GetComponent<Projectile>();
            component.AdditionalScaleMultiplier = .001f;
            component.Owner = this.gun.CurrentOwner;
            component.baseData.damage = 25;
            ProjectileSlashingBehaviour slashy = component.gameObject.GetOrAddComponent<ProjectileSlashingBehaviour>();
            slashy.SlashRange = 4f;
            slashy.DoSound = true;
            slashy.SlashDamage = 25f;
            slashy.SlashDimensions = 90;
            slashy.SlashVFX.type = VFXPoolType.None;

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