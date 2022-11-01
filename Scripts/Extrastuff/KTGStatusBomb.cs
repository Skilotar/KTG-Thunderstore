using System;
using ItemAPI;
using UnityEngine;
using SaveAPI;
using System.Collections;
using System.Collections.Generic;
using Dungeonator;

namespace Knives
{
	public class KTGStatusBomb : MonoBehaviour
	{

		public KTGStatusBomb()
		{
			

		}


		private void Start()
		{

			proxy = this.gameObject.GetComponent<ProximityMine>();
			StartCoroutine(onPreDet());
			
		}
		public Vector2 centerPosition;
		private IEnumerator onPreDet()
        {
			
			yield return new WaitForSeconds(proxy.explosionDelay - .01f);

			centerPosition = this.gameObject.GetComponent<tk2dSprite>().sprite.WorldCenter;
			PlayerController Owner = GameManager.Instance.GetPlayerClosestToPoint(centerPosition);

			List<AIActor> activeEnemies = Owner.CurrentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All);

			foreach (AIActor aiactor in activeEnemies)
			{

				bool flag3 = Vector2.Distance(aiactor.CenterPosition, centerPosition) < 3f && aiactor.healthHaver.GetMaxHealth() > 0f && aiactor != null && aiactor.specRigidbody != null && Owner != null;

				if (flag3)
				{
                    if (DoesBlast)
                    {
						BlastBlightedStatusController blast = aiactor.gameObject.GetOrAddComponent<BlastBlightedStatusController>();
						blast.statused = true;
					}

                    if (DoesHex)
                    {
						HexStatusEffectController hex = aiactor.gameObject.GetOrAddComponent<HexStatusEffectController>();
						hex.statused = true;
					}
				}

			}


		}

		private void Update()
		{
			
		}


		public ProximityMine proxy;

		public bool DoesHex = false;
		public bool DoesBlast = false;

		
	}
}