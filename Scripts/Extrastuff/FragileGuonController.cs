using System;
using System.Collections.Generic;
using ItemAPI;
using UnityEngine;

namespace Knives
{
	public class FragileGuonController : MonoBehaviour
	{

		public FragileGuonController()
		{


		}

		public int clayHP = 3;
		private void Start()
		{
			this.Orbital = base.GetComponent<GameObject>();
			//this.playerOrbital = base.GetComponent<PlayerOrbital>();
			//this.parentOwner = playerOrbital.Owner;
			this.specbod = base.GetComponent<SpeculativeRigidbody>();
			specbod.OnPreRigidbodyCollision = (SpeculativeRigidbody.OnPreRigidbodyCollisionDelegate)Delegate.Combine(specbod.OnPreRigidbodyCollision, new SpeculativeRigidbody.OnPreRigidbodyCollisionDelegate(this.OnPreCollison));
			
		}

        private void OnPreCollison(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
        {
			if (otherRigidbody != null && myRigidbody != null)
			{
				
				if (otherRigidbody.projectile)
				{
					if (clayHP <= 0)
					{
						DoSafeExplosion(myRigidbody.UnitCenter);
						UnityEngine.GameObject.Destroy(myRigidbody.gameObject);
						AkSoundEngine.PostEvent("Play_OBJ_pot_shatter_01", base.gameObject);
						AkSoundEngine.PostEvent("Play_OBJ_pot_shatter_01", base.gameObject);
					}
					else
					{
						
						clayHP--;

					}
					if (clayHP == 2)//orange
					{
						myRigidbody.sprite.color = new Color(.70f, .40f, .24f);

					}
					if (clayHP == 1)//red
					{
						myRigidbody.sprite.color = new Color(.33f, .07f, .04f);

					}
				}

			}

        }
		public void DoSafeExplosion(Vector3 position)
		{

			ExplosionData defaultSmallExplosionData2 = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData;
			this.smallPlayerSafeExplosion.effect = EasyVFXDatabase.WhiteCircleVFX;
			this.smallPlayerSafeExplosion.ignoreList = defaultSmallExplosionData2.ignoreList;
			this.smallPlayerSafeExplosion.ss = defaultSmallExplosionData2.ss;
			Exploder.Explode(position, this.smallPlayerSafeExplosion, Vector2.zero, null, false, CoreDamageTypes.None, false);

		}
		private ExplosionData smallPlayerSafeExplosion = new ExplosionData
		{
			damageRadius = 2f,
			damageToPlayer = 0f,
			doDamage = false,
			damage = 0f,
			doDestroyProjectiles = true,
			doForce = false,
			debrisForce = 0f,
			preventPlayerForce = true,
			explosionDelay = 0f,
			usesComprehensiveDelay = false,
			doScreenShake = false,
			playDefaultSFX = false,
			
		};

		private void Update()
		{
			
		}
		
		public GameObject Orbital;
		public PlayerOrbital playerOrbital;
		public SpeculativeRigidbody specbod;
		private PlayerController parentOwner;

	

	
	}
}
