using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using SaveAPI;
using BepInEx;

namespace Knives
{
	public class Commands : BaseUnityPlugin
	{
		// Token: 0x06000516 RID: 1302 RVA: 0x000301ED File Offset: 0x0002E3ED


		// Token: 0x06000517 RID: 1303 RVA: 0x000301F0 File Offset: 0x0002E3F0
		public void Start()
		{
			


		}

		// Token: 0x06000518 RID: 1304 RVA: 0x000301F4 File Offset: 0x0002E3F4
		public static void Init()
		{



			ETGModConsole.Commands.AddGroup("rage_quit", delegate (string[] args)
			{
				ETGModConsole.Log("Goodbye :) ", false);
				Application.Quit();
			});


			ETGModConsole.Commands.AddGroup("ski", delegate (string[] args)
			{
				ETGModConsole.Log("<size=100><color=#5deba4>Please specify a command. Type 'ski help' for a list of commands.</color></size>", false);
			});

			ETGModConsole.Commands.GetGroup("ski").AddUnit("help", delegate (string[] args)
			{
				ETGModConsole.Log("<size=100><color=#5deba4>List of Commands</color></size>", false);

				ETGModConsole.Log("<size=100><color=#5deba4>zoom_in zooms in with 60% intervals</color></size>", false);
				ETGModConsole.Log("<size=100><color=#5deba4>zoom_out zooms out in 60% intervals</color></size>", false);

				ETGModConsole.Log("<size=100><color=#5deba4>unlock_all unlocks all current KTG unlockables</color></size>", false);
				ETGModConsole.Log("<size=100><color=#5deba4>lock_all relocks all current KTG unlockables that are unlocked</color></size>", false);
				ETGModConsole.Log("<size=100><color=#5deba4>list_unlocks lists all the unlockable items and their current statuses</color></size>", false);

			});

			ETGModConsole.Commands.GetGroup("ski").AddUnit("zoom_in", delegate (string[] args)
			{
				GameManager.Instance.MainCameraController.OverrideZoomScale /= 0.66f;
				ETGModConsole.Log("Zooming In");

			});
			
			ETGModConsole.Commands.GetGroup("ski").AddUnit("zoom_out", delegate (string[] args)
			{
				GameManager.Instance.MainCameraController.OverrideZoomScale *= 0.66f;
				ETGModConsole.Log("Zooming Out");
			});

			ETGModConsole.Commands.GetGroup("ski").AddUnit("unlock_all", delegate (string[] args)
			{
				AdvancedGameStatsManager.Instance.SetFlag(CustomDungeonFlags.BEAT_DRAGUN_WITH_MANIC, true);
				AdvancedGameStatsManager.Instance.SetFlag(CustomDungeonFlags.AMMO_STARVED, true);
				AdvancedGameStatsManager.Instance.SetFlag(CustomDungeonFlags.FIRST_IMPRESS, true);
				AdvancedGameStatsManager.Instance.SetFlag(CustomDungeonFlags.FLATLINED, true);
				AdvancedGameStatsManager.Instance.SetFlag(CustomDungeonFlags.HEXLINDED, true);
				AdvancedGameStatsManager.Instance.SetFlag(CustomDungeonFlags.HEX_MANIAC,true);
				ETGModConsole.Log("Unlocked all locked items.\nIts like Christmas mornin'");

			});

			ETGModConsole.Commands.GetGroup("ski").AddUnit("lock_all", delegate (string[] args)
			{
				AdvancedGameStatsManager.Instance.SetFlag(CustomDungeonFlags.BEAT_DRAGUN_WITH_MANIC, false);
				AdvancedGameStatsManager.Instance.SetFlag(CustomDungeonFlags.AMMO_STARVED, false);
				AdvancedGameStatsManager.Instance.SetFlag(CustomDungeonFlags.FIRST_IMPRESS, false);
				AdvancedGameStatsManager.Instance.SetFlag(CustomDungeonFlags.FLATLINED, false);
				AdvancedGameStatsManager.Instance.SetFlag(CustomDungeonFlags.HEXLINDED, false);
				AdvancedGameStatsManager.Instance.SetFlag(CustomDungeonFlags.HEX_MANIAC, false);
				ETGModConsole.Log("Re-Locked all unlocked items.");
			});

			ETGModConsole.Commands.GetGroup("ski").AddUnit("list_unlocks", delegate (string[] args)
			{
				
				List<String> tasks = new List<string>
				{
					AdvancedGameStatsManager.Instance.GetFlag(CustomDungeonFlags.BEAT_DRAGUN_WITH_MANIC) ? "--- Completed! Earned Mask Twins!\n" : "-- Defeat the Dragun during the Manic Theatre Challenge\n",
					AdvancedGameStatsManager.Instance.GetFlag(CustomDungeonFlags.AMMO_STARVED) ? "--- Completed! Earned Hipp0!\n" : "-- Have two of your guns run out of ammo at once\n",
					AdvancedGameStatsManager.Instance.GetFlag(CustomDungeonFlags.FIRST_IMPRESS) ? "--- Completed! Earned First Impression!\n" : "-- Complete the tutorial in 2:15\n",
					AdvancedGameStatsManager.Instance.GetFlag(CustomDungeonFlags.FLATLINED) ? "--- Completed! Earned FlatLine!\n" : "-- Die to a floor Boss\n",
					AdvancedGameStatsManager.Instance.GetFlag(CustomDungeonFlags.HEXLINDED) ? "--- Completed! Earned Witch Watch!\n" : "-- Die to Hex\n",
					AdvancedGameStatsManager.Instance.GetFlag(CustomDungeonFlags.HEX_MANIAC) ? "--- Completed! Earned Hex Eater!\n"  : "-- Kill Lich with Hex\n"
				};
				ETGModConsole.Log("<size=100><color=#5deba4>Knife to a gunfight Unlock tasks list-</color></size>");
				foreach (String task in tasks)
                {
					ETGModConsole.Log(task);
                }
				
			});

		}
		
		
	}

	

}
