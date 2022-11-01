using System;
using ItemAPI;
using UnityEngine;

namespace Knives
{
	public class projectileStates : MonoBehaviour
	{

		public projectileStates()
		{
			boostedbyHarlight = false;
			isloneStarStar = false;
			isloneStarLone = false;
			hitbomb = false;
			boostedbyshotgate = false;
			isfocusshot = false;
		}


		private void Start()
		{
			

		}


		private void Update()
		{

		}

		public bool isfocusshot;
		public bool boostedbyHarlight;
		public bool boostedbyshotgate;
		public bool isloneStarStar;
		public bool isloneStarLone;
		public bool hitbomb;

		private Projectile projectile;
	}
}

