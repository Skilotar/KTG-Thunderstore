using System;
using ItemAPI;
using UnityEngine;
using SaveAPI;
using Dungeonator;
using NpcApi;
using System.Collections;

using HutongGames.PlayMaker;

namespace Knives
{
	public class JinxItemDisplay : MonoBehaviour
	{

		public JinxItemDisplay()
		{


		}


		private void Start()
		{

			player = base.GetComponent<PlayerController>();
			//ETGModConsole.Log("JinxDisplayAdded");

		}

		public int pickupID = -1;
		private CustomShopController m_shop;
		private GameObject m_morgun;
		private bool doingtalk = false;
		private int last_spoken_pickup = -1;
		public void Update()
		{
			if (player != null && GameManager.Instance.IsLoadingLevel == false)
			{
				RoomHandler room = player.GetAbsoluteParentRoom();


				if (room != null)
				{
					IPlayerInteractable nearestInteractable = room.GetNearestInteractable(player.sprite.WorldCenter, 1f, player);
					if (nearestInteractable != null)
					{
						PickupObject foundItem = null;


						if (nearestInteractable is CustomShopItemController)
						{
							//ETGModConsole.Log("getting interact");
							pickupID = (nearestInteractable as CustomShopItemController).item.PickupObjectId; // THIS WORKS DONT TOUCH IT!!!!!!!
							m_shop = (nearestInteractable as CustomShopItemController).GetShopController();
							m_morgun = m_shop.shopkeepFSM.Fsm.GameObject;
							foundItem = PickupObjectDatabase.GetById(pickupID);
						}


						if (foundItem != null)
						{
							if (last_spoken_pickup != foundItem.PickupObjectId)
							{
								if (foundItem.gameObject.GetComponent<JinxItemDisplayStorageClass>() != null) // the found item nearest item in 1 meters has the jinx storage class
								{

									if (m_morgun != null)
									{

										if (last_spoken_pickup != -1 && last_spoken_pickup != foundItem.PickupObjectId)//currently standing on NEW item 
										{
											killandCool();
										}

										TalkDoerLite speaker = m_morgun.GetComponent<TalkDoerLite>();
										if (speaker != null)
										{
											if (doingtalk != true)
											{
												last_spoken_pickup = foundItem.PickupObjectId;
												doingtalk = true;
												speaker.PreventInteraction = true;
												speaker.CloseTextBox(true);
												speaker.ForceTimedSpeech(foundItem.gameObject.GetComponent<JinxItemDisplayStorageClass>().jinxItemDisplayText, .1f, -1f, TextBoxManager.BoxSlideOrientation.NO_ADJUSTMENT);

											}
										}
										else
										{
											ETGModConsole.Log("Talker is null?");
										}



									}
									else
									{
										ETGModConsole.Log("NPC is null??????");
									}
								}


							}
							else
							{

							}
						}



					}
					else
					{
						if (last_spoken_pickup != -1)
						{
							killandCool();
						}
					}
				}
			}
			

		}

		private void killandCool()
        {
			TalkDoerLite speaker = m_morgun.GetComponent<TalkDoerLite>();
			speaker.CloseTextBox(true);
			speaker.PreventInteraction = false;
			last_spoken_pickup = -1;
			pickupID = -1;
			StartCoroutine(TalkCooldown());

		}

		private IEnumerator TalkCooldown()
        {
			yield return new WaitForSeconds(.25f);
			doingtalk = false;
			
        }

        public GameObject nearItem;
		public PlayerController player;
	}
}
