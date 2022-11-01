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
using MonoMod;

namespace Knives
{
	class Coiler : AdvancedGunBehaviour
	{

		public static void Add()
		{

			Gun gun = ETGMod.Databases.Items.NewGun("Coiler", "Coiler");
			Game.Items.Rename("outdated_gun_mods:coiler", "ski:coiler");
			gun.gameObject.AddComponent<Coiler>();
			gun.SetShortDescription("OverCharged");
			gun.SetLongDescription("An attempt by the Sp4rk company to create a recharging station for their burst batteries.\n\n" +
				"Enemies hit with this coiling shot will detonate an electric pulse after 2 seconds." +
				"" +
				"\n\n- Knife_to_a_gunfight");


			gun.SetupSprite(null, "Coiler_idle_001", 1);
			gun.SetAnimationFPS(gun.shootAnimation, 4);
			gun.SetAnimationFPS(gun.reloadAnimation, 7);

			gun.AddProjectileModuleFrom(PickupObjectDatabase.GetById(15) as Gun, true, false);


			gun.gunHandedness = GunHandedness.OneHanded;
			gun.DefaultModule.ammoCost = 1;
			gun.DefaultModule.angleVariance = 0f;
			gun.DefaultModule.shootStyle = ProjectileModule.ShootStyle.SemiAutomatic;
			gun.DefaultModule.sequenceStyle = ProjectileModule.ProjectileSequenceStyle.Random;
			gun.DefaultModule.cooldownTime = .6f;
			gun.DefaultModule.numberOfShotsInClip = 2;
			gun.reloadTime = 1f;
			gun.SetBaseMaxAmmo(200);
			gun.CurrentAmmo = 200;

			gun.quality = PickupObject.ItemQuality.B;

			gun.gunClass = GunClass.PISTOL;

			Projectile projectile = UnityEngine.Object.Instantiate<Projectile>(gun.DefaultModule.projectiles[0]);

			projectile.gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(projectile.gameObject);
			UnityEngine.Object.DontDestroyOnLoad(projectile);
			gun.DefaultModule.projectiles[0] = projectile;

			projectile.baseData.damage = 1f;
			projectile.baseData.speed *= 1;
			projectile.baseData.range = 20f;

			LightningProjectileComp shocking = projectile.gameObject.GetOrAddComponent<LightningProjectileComp>();
			PierceProjModifier stabby = projectile.gameObject.GetOrAddComponent<PierceProjModifier>();
			stabby.penetration = 0;

			ETGMod.Databases.Items.Add(gun, null, "ANY");


		}

		public System.Random rng = new System.Random();
		public override void PostProcessProjectile(Projectile projectile)
		{
			int sound = rng.Next(1, 4);
			switch (sound)
			{
				case 1:
					AkSoundEngine.PostEvent("Play_neon_001", base.gameObject);

					break;
				case 2:
					AkSoundEngine.PostEvent("Play_neon_002", base.gameObject);

					break;
				case 3:
					AkSoundEngine.PostEvent("Play_neon_003", base.gameObject);

					break;
				default: // case 4
					AkSoundEngine.PostEvent("Play_neon_004", base.gameObject);

					break;
			}
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}

		private void OnHitEnemy(Projectile arg1, SpeculativeRigidbody arg2, bool arg3)
		{
			StartCoroutine(BurstDelay(arg2.aiActor));
		}

        private IEnumerator BurstDelay(AIActor aiactor)
        {
			yield return new WaitForSeconds(2);
			PlayerController player = (PlayerController)this.gun.CurrentOwner;
			for (int i = 0; i < 5; i++)
			{
				Projectile projectile2 = ((Gun)ETGMod.Databases.Items[15]).DefaultModule.projectiles[0];
				GameObject gameObject = SpawnManager.SpawnProjectile(projectile2.gameObject, aiactor.sprite.WorldCenter, Quaternion.Euler(0f, 0f, (player.CurrentGun == null) ? 0f : player.CurrentGun.CurrentAngle + (i * 10)), true);
				Projectile component = gameObject.GetComponent<Projectile>();
				bool flag = component != null;
				if (flag)
				{

					component.gameObject.GetOrAddComponent<LightningProjectileComp>();
					PierceProjModifier stabby = component.gameObject.GetOrAddComponent<PierceProjModifier>();
					stabby.penetration = 1;
					component.Owner = player;
					component.Shooter = player.specRigidbody;
					component.baseData.damage = 4f;
					component.DefaultTintColor = UnityEngine.Color.yellow;
					component.HasDefaultTint = true;

				}
			}
		}

        public override void OnReload(PlayerController player, Gun gun)
        {
			
			AkSoundEngine.PostEvent("Stop_WPN_All", base.gameObject);

			
			base.OnReload(player, gun);
        }
        
		public bool HasReloaded = false;


		public override void  Update()
		{
			base.Update();
			if (gun.CurrentOwner != null)
			{

				if (!gun.PreventNormalFireAudio)
				{
					this.gun.PreventNormalFireAudio = true;
				}
				if (!gun.IsReloading && !HasReloaded)
				{
					this.HasReloaded = true;
				}


			}


		}
	}
}