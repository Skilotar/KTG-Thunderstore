using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knives
{
	// Token: 0x020000AF RID: 175
	internal class SynergyFormInitialiser
	{
		public static void AddSynergyForms()
		{
			
			AdvancedTransformGunSynergyProcessor advancedTransformGunSynergyProcessor = (PickupObjectDatabase.GetById(MonkeyBarrel.mbID) as Gun).gameObject.AddComponent<AdvancedTransformGunSynergyProcessor>();
			advancedTransformGunSynergyProcessor.NonSynergyGunId = MonkeyBarrel.mbID;
			advancedTransformGunSynergyProcessor.SynergyGunId = MBSynergyForm.mbakID;
			advancedTransformGunSynergyProcessor.SynergyToCheck = "Apex Predator";

			AdvancedTransformGunSynergyProcessor lance = (PickupObjectDatabase.GetById(Lance.lnc) as Gun).gameObject.AddComponent<AdvancedTransformGunSynergyProcessor>();
			lance.NonSynergyGunId = Lance.lnc;
			lance.SynergyGunId = Lance2.lncplusID;
			lance.SynergyToCheck = "Upgraded";

			FirstImpress_FormController first = PickupObjectDatabase.GetById(FirstImpression.StandardID).gameObject.AddComponent<FirstImpress_FormController>();
			Steamy_FormController steam = PickupObjectDatabase.GetById(Steam_rifle.StandardID).gameObject.AddComponent<Steamy_FormController>();
			Watchman_FormController charge = PickupObjectDatabase.GetById(Watch_Standard.StandardID).gameObject.AddComponent<Watchman_FormController>();
			//Umbra_FormController Umbra = PickupObjectDatabase.GetByEncounterName("Umbra").gameObject.AddComponent<Umbra_FormController>();
		}
	}
}