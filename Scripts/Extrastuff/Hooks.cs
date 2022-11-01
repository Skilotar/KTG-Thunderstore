using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GungeonAPI;
using MonoMod.RuntimeDetour;
using UnityEngine;
using Dungeonator;
using SaveAPI;

namespace Knives
{
    // Token: 0x02000018 RID: 24
    public static class Hooks
    {
        // Token: 0x060000B7 RID: 183 RVA: 0x00008CE4 File Offset: 0x00006EE4
        public static void Init()
        {
            try
            {
                Hook SetupUnlockTrackerComponent = new Hook(typeof(PlayerController).GetMethod("DoSpinfallSpawn", BindingFlags.Instance | BindingFlags.Public), typeof(Module).GetMethod("RunStartHook"));

                Hook togglemanichook = new Hook(typeof(PlayerController).GetMethod("DoSpinfallSpawn", BindingFlags.Instance | BindingFlags.Public), typeof(TheatreModeToggle).GetMethod("startmanic"));
                //used for unlock
                Hook impressHook = new Hook(typeof(PlayerController).GetMethod("BraveOnLevelWasLoaded", BindingFlags.Instance | BindingFlags.Public), typeof(Module).GetMethod("SpecialTutorialHook"));

              
            }
            catch (Exception e)
            {
                ItemAPI.Tools.PrintException(e, "FF0000");
            }
        }
    }
}
