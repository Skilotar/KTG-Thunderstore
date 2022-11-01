using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using Dungeonator;
using ItemAPI;
using Gungeon;


namespace Knives
{
    public class Umbra_FormController : MonoBehaviour
    {
        public Umbra_FormController()
        {
            this.basestate = Umbra_main.BaseID;
            //this.secondstate = Umbra_Shoot.SecondID;
            this.thirdstate = Umbra_Phwoomp.ThirdID;
        }

        private void Awake()
        {
            this.m_gun = base.GetComponent<Gun>();
        }

        private void Update()
        {





            if (Dungeon.IsGenerating || Dungeon.ShouldAttemptToLoadFromMidgameSave)
            {
                return;
            }
            PlayerController player = this.m_gun.CurrentOwner as PlayerController;
            if (this.m_gun && this.m_gun.CurrentOwner is PlayerController)
            {

                if (!this.m_gun.enabled)
                {
                    return;
                }
                if (Umbra_main.BeShield = true && !this.m_transformed)
                {
                    this.m_transformed = true;
                    this.m_gun.TransformToTargetGun(PickupObjectDatabase.GetById(this.thirdstate) as Gun);

                    if (this.ShouldResetAmmoAfterTransformation)
                    {
                        this.m_gun.ammo = this.ResetAmmoCount;
                    }
                }
                else if (Umbra_main.BeShield = false && this.m_transformed)
                {
                    this.m_transformed = false;
                    this.m_gun.TransformToTargetGun(PickupObjectDatabase.GetById(this.basestate) as Gun);
                    if (this.ShouldResetAmmoAfterTransformation)
                    {
                        this.m_gun.ammo = this.ResetAmmoCount;
                    }
                }
            }
            else if (this.m_gun && !this.m_gun.CurrentOwner && this.m_transformed)
            {
                this.m_transformed = false;
                this.m_gun.TransformToTargetGun(PickupObjectDatabase.GetById(this.basestate) as Gun);
                if (this.ShouldResetAmmoAfterTransformation)
                {
                    this.m_gun.ammo = this.ResetAmmoCount;
                }
            }
            this.ShouldResetAmmoAfterTransformation = false;



        }

       
        // 1 slash
       
        // 3 shield
        public PlayerController player;

        public string SynergyToCheck;
        public int basestate;
        public int secondstate;
        public int thirdstate;
        private Gun m_gun;
        private bool m_transformed;
        public bool ShouldResetAmmoAfterTransformation;
        public int ResetAmmoCount;
    }
}