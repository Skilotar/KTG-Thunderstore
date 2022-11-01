using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemAPI;
using UnityEngine;
using Dungeonator;

namespace Knives
{
    class BlobuCrownController :MonoBehaviour
    {
		public static GameObject BlobuCrown;
		public static GameActorDecorationEffect BlobDummyEffect;
		public static void Initialise()
		{
			BlobuCrown = SpriteBuilder.SpriteFromResource("Knives/Resources/lord.png", new GameObject("BlightIcon"));
			BlobuCrown.SetActive(false);
			tk2dBaseSprite vfxSprite = BlobuCrown.GetComponent<tk2dBaseSprite>();
			vfxSprite.GetCurrentSpriteDef().ConstructOffsetsFromAnchor(tk2dBaseSprite.Anchor.MiddleCenter, vfxSprite.GetCurrentSpriteDef().position3);
			FakePrefab.MarkAsFakePrefab(BlobuCrown);
			UnityEngine.Object.DontDestroyOnLoad(BlobuCrown);

			BlobDummyEffect = new GameActorDecorationEffect()
			{
				AffectsEnemies = true,
				OverheadVFX = BlobuCrown,
				AffectsPlayers = false,
				AppliesTint = false,
				AppliesDeathTint = false,
				AppliesOutlineTint = false,
				duration = float.MaxValue,
				effectIdentifier = "Lord's Crown",
				resistanceType = EffectResistanceType.None,
				PlaysVFXOnActor = false,
				stackMode = GameActorEffect.EffectStackingMode.Ignore,
			};
		}
		private void Start()
		{
			this.player = base.GetComponent<PlayerController>();
			player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(this.OnEnteredCombat));
		}

        private void OnEnteredCombat()
        {
			RoomHandler currentRoom = player.CurrentRoom;
			foreach (AIActor aiactor in currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All))
			{
				if (aiactor.EnemyGuid == "1b5810fafbec445d89921a4efb4e42b7" && aiactor.healthHaver.GetCurrentHealthPercentage() == 1 && !aiactor.gameObject.GetComponent<SkilotarSplitBehave>())
				{
					if (rng.Next(1, 9) == 1)
					{
						aiactor.ApplyEffect(BlobDummyEffect);
						aiactor.OverrideDisplayName = "Skilotar_";
						aiactor.LocalTimeScale = 1.1f;
						aiactor.gameObject.GetOrAddComponent<SkilotarSplitBehave>();
					}
				}
			}
		}

        System.Random rng = new System.Random();
		private void Update()
		{
			
		}
		public bool hasHat = false;
		public PlayerController player;
	}
}
