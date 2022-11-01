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
	class Thumper : AdvancedGunBehaviour
	{

		public static void Add()
		{

			Gun gun = ETGMod.Databases.Items.NewGun("Thumper", "Thumper");
			Game.Items.Rename("outdated_gun_mods:thumper", "ski:thumper");
			gun.gameObject.AddComponent<Thumper>();
			gun.SetShortDescription("Short Fuse");
			gun.SetLongDescription("Press to fire, release to detonate. A decendant of the ancient flare gun used to detonate flares into space to flag down planetary" +
				" rescue teams. \n\n- Knife_to_a_gunfight");

			
			gun.SetupSprite(null, "Thumper_idle_001", 1);
			gun.SetAnimationFPS(gun.shootAnimation, 9);
			gun.SetAnimationFPS(gun.reloadAnimation, 7);

			gun.AddProjectileModuleFrom(PickupObjectDatabase.GetById(275) as Gun, true, false);
			

			gun.gunHandedness = GunHandedness.OneHanded;
			gun.DefaultModule.ammoCost = 1;
			gun.DefaultModule.angleVariance = 0f;
			gun.DefaultModule.shootStyle = ProjectileModule.ShootStyle.SemiAutomatic;
			gun.DefaultModule.sequenceStyle = ProjectileModule.ProjectileSequenceStyle.Random;
			
			
			gun.DefaultModule.cooldownTime = .75f;
			
			gun.DefaultModule.numberOfShotsInClip = 1;
			
			gun.reloadTime = .75f;
			gun.SetBaseMaxAmmo(200);
			gun.CurrentAmmo = 200;
			gun.muzzleFlashEffects = (PickupObjectDatabase.GetById(275) as Gun).muzzleFlashEffects;
			gun.quality = PickupObject.ItemQuality.B;
			
			gun.gunClass = GunClass.FIRE;

			Projectile projectile = UnityEngine.Object.Instantiate<Projectile>(gun.DefaultModule.projectiles[0]);

			projectile.gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(projectile.gameObject);
			UnityEngine.Object.DontDestroyOnLoad(projectile);
			gun.DefaultModule.projectiles[0] = projectile;
			
			projectile.baseData.damage = 5f;
			projectile.baseData.speed *= .7f;
			projectile.baseData.range = 20f;
			

			ETGMod.Databases.Items.Add(gun, null, "ANY");


		}

		public System.Random rand = new System.Random();
		public override void PostProcessProjectile(Projectile projectile)
		{
			pressDetProjModifier press = projectile.gameObject.GetOrAddComponent<pressDetProjModifier>();
			press.isThumperRocket = true;
			AkSoundEngine.PostEvent("Play_Thumper_fire_001", base.gameObject);
			
		}


		public override void OnReload(PlayerController player, Gun gun)
		{
			
			base.OnReload(player, gun);
			
		}


	
		public override void  Update()
		{
			base.Update();
			if (this.Owner != null)
			{

			}

		}


	}
}
