using System;
using System.Collections;
using Gungeon;
using MonoMod;
using UnityEngine;
using ItemAPI;
using MultiplayerBasicExample;

namespace Knives
{

    public class Rampage : AdvancedGunBehaviour
    {
        public static void Add()
        {
            // Get yourself a new gun "base" first.
            // Let's just call it "Basic Gun", and use "jpxfrd" for all sprites and as "codename" All sprites must begin with the same word as the codename. For example, your firing sprite would be named "jpxfrd_fire_001".
            Gun gun = ETGMod.Databases.Items.NewGun("Rampage", "Rampage");
            // "kp:basic_gun determines how you spawn in your gun through the console. You can change this command to whatever you want, as long as it follows the "name:itemname" template.
            Game.Items.Rename("outdated_gun_mods:rampage", "ski:rampage");
            gun.gameObject.AddComponent<Rampage>();
            //These two lines determines the description of your gun, ".SetShortDescription" being the description that appears when you pick up the gun and ".SetLongDescription" being the description in the Ammonomicon entry. 
            gun.SetShortDescription("Heat Sink");
            gun.SetLongDescription("The Internal mechanisms of this LMG Function much better when heated. " +
                "Forged by one of the childern of the sun it would use the heat from their flaming bodies to loosen the firing pin. " +
                "Light yourself ablaze or reload at full clip to cram a thermite canister into the barrel. \n\n" +
                "Safety messures have been added for non plasma based lifeforms. Reloading will flush all fire from the system to allow for emergency extingushes. " +
                "\n\n\n - Knife_to_a_Gunfight");


            gun.SetupSprite(null, "Rampage_idle_001", 8);
            // ETGMod automatically checks which animations are available.
            // The numbers next to "shootAnimation" determine the animation fps. You can also tweak the animation fps of the reload animation and idle animation using this method.
            gun.SetAnimationFPS(gun.shootAnimation, 17);
            gun.SetAnimationFPS(gun.introAnimation, 12);
            gun.SetAnimationFPS(gun.criticalFireAnimation, 10);
            gun.SetAnimationFPS(gun.reloadAnimation, 6);
            // Every modded gun has base projectile it works with that is borrowed from other guns in the game. 
            // The gun names are the names from the JSON dump! While most are the same, some guns named completely different things. If you need help finding gun names, ask a modder on the Gungeon discord.
            gun.AddProjectileModuleFrom(PickupObjectDatabase.GetById(182) as Gun, true, false);
            // Here we just take the default projectile module and change its settings how we want it to be.
            gun.DefaultModule.ammoCost = 1;
            gun.DefaultModule.angleVariance = 6f;
            gun.DefaultModule.shootStyle = ProjectileModule.ShootStyle.Automatic;
            gun.DefaultModule.sequenceStyle = ProjectileModule.ProjectileSequenceStyle.Random;
            gun.reloadTime = 1f;
            gun.DefaultModule.cooldownTime = .27f;
            gun.DefaultModule.numberOfShotsInClip = 20;
            gun.SetBaseMaxAmmo(600);
            // Here we just set the quality of the gun and the "EncounterGuid", which is used by Gungeon to identify the gun.
            gun.quality = PickupObject.ItemQuality.C;

            //This block of code helps clone our projectile. Basically it makes it so things like Shadow Clone and Hip Holster keep the stats/sprite of your custom gun's projectiles.
            Projectile projectile = UnityEngine.Object.Instantiate<Projectile>(gun.DefaultModule.projectiles[0]);
            projectile.gameObject.SetActive(false);
            gun.barrelOffset.transform.localPosition = new Vector3(1.6f, .5f, 0f);
            FakePrefab.MarkAsFakePrefab(projectile.gameObject);
            UnityEngine.Object.DontDestroyOnLoad(projectile);
            gun.DefaultModule.projectiles[0] = projectile;
            projectile.AdditionalScaleMultiplier *= .6f;
            projectile.baseData.damage = 10f;
            projectile.baseData.speed *= 1f;
            gun.PreventOutlines = true;
            gun.shellsToLaunchOnFire = 1;
            Gun gun2 = PickupObjectDatabase.GetById(84) as Gun;
            gun.shellCasing = gun2.shellCasing;

            projectile.transform.parent = gun.barrelOffset;
            gun.gunClass = GunClass.RIFLE;
            ETGMod.Databases.Items.Add(gun, null, "ANY");
            ID = gun.PickupObjectId;
        }

        public static int ID;
        public override void OnPostFired(PlayerController player, Gun gun)
        {
            AkSoundEngine.PostEvent("Play_WPN_smileyrevolver_shot_01", base.gameObject);

        }
        public override void PostProcessProjectile(Projectile projectile)
        {
            PlayerController player = (gun.CurrentOwner as PlayerController);
            if ((gun.CurrentOwner as PlayerController).IsOnFire)
            {
               
                player.CurrentFireMeterValue = player.CurrentFireMeterValue - .15f;

                if (player.CurrentFireMeterValue <= .05f)
                {
                    player.IsOnFire = false;
                    
                }

                if (player.PlayerHasActiveSynergy("Paint The Town RED"))
                {
                    projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(this.HandleHitEnemy));
                    projectile.OnDestruction += Projectile_OnDestruction;
                }

            }


            base.PostProcessProjectile(projectile);
        }

        private void Projectile_OnDestruction(Projectile obj)
        {
            if (obj != null)
            {
                
                DeadlyDeadlyGoopManager goop = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(PickupObjectDatabase.GetById(242).GetComponent<DirectionalAttackActiveItem>().goopDefinition);
                goop.TimedAddGoopCircle(obj.sprite.WorldCenter, 1f, 0.5f, true);
            }
        }

       
        private void HandleHitEnemy(Projectile arg1, SpeculativeRigidbody arg2, bool arg3)
        {
            try
            {
                if (arg2 != null)
                {
                    DeadlyDeadlyGoopManager goop = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(PickupObjectDatabase.GetById(242).GetComponent<DirectionalAttackActiveItem>().goopDefinition);
                    if (arg3 != true)
                    {

                        goop.TimedAddGoopCircle(arg2.sprite.WorldCenter, 1f, 0.5f, true);
                    }
                    else
                    {
                        
                        goop.TimedAddGoopCircle(arg2.sprite.WorldCenter, 1.5f, 1f, true);
                    }

                }

            }
            catch(Exception e)
            {
                ETGModConsole.Log(e.ToString());
            }


        }

        private bool HasReloaded;
        public bool WasrecentlyStealthed = false;
        public bool doingCoroutine;
        public bool doingstealthtimer = false;
        //This block of code allows us to change the reload sounds.
        public override void  Update()
        {
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
                if((gun.CurrentOwner as PlayerController).IsOnFire)
                {
                    gun.DefaultModule.cooldownTime = .18f;
                }
                else
                {
                    gun.DefaultModule.cooldownTime = .35f;
                }

               
            }
                
        }
        
        public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
        {
            if (gun.ClipCapacity == gun.ClipShotsRemaining && !player.IsOnFire)
            {
                StartCoroutine(DoFireUpAnimation());

                
            }

            if (gun.IsReloading && this.HasReloaded)
            {
                HasReloaded = false;
                AkSoundEngine.PostEvent("Stop_WPN_All", base.gameObject);
                base.OnReloadPressed(player, gun, bSOMETHING);
                AkSoundEngine.PostEvent("Play_WPN_yarirocketlauncher_reload_01", base.gameObject);
                if (player.IsOnFire)
                {
                    player.CurrentFireMeterValue = player.CurrentFireMeterValue -1f;
                    player.IsOnFire = false;
                    
                }
                
            }

        }

        private IEnumerator DoFireUpAnimation()
        {
            PlayerController player = (gun.CurrentOwner as PlayerController);
            gun.spriteAnimator.Play("Rampage_critical_fire");

            yield return new WaitForSeconds(1.25f);
            gun.LoseAmmo(10);
            player.IsOnFire = true;
            player.IncreaseFire(.30f);
            AkSoundEngine.PostEvent("Play_OverheatUp", base.gameObject);
        }
    }
}
