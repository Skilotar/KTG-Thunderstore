using System;
using ItemAPI;
using UnityEngine;

namespace Knives
{
	public class AiactorSpecialStates : MonoBehaviour
	{

		public AiactorSpecialStates()
		{

			isbeingcheckedbyOccams = false;
			LootedByBaba = false;
			hitbyovercharger = false;
			RedTaped = false;
			transmogedbyBookofMispells = false;
			Snared = false;
			Coilered = false;
			smelledChechPerf = false;
		}


	private void Start()
		{
			this.aIActor = base.GetComponent<AIActor>();
			
		}


		private void Update()
		{
			
		}

		public bool LootedByBaba = false;
		public bool hitbyovercharger = false;
		public bool RedTaped = false;
		public bool isbeingcheckedbyOccams = false;
		public bool transmogedbyBookofMispells = false;
		public bool Snared = false;
		public bool Coilered = false;
		public bool smelledChechPerf = false;
		private AIActor aIActor;
	}
}
