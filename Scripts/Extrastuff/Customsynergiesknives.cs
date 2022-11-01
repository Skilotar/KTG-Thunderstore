using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ItemAPI;
using MultiplayerBasicExample;
using JetBrains.Annotations;

namespace Knives
{
    class Customsynergiesknives
    {
        public class Daft_Punk : AdvancedSynergyEntry
        {

            public Daft_Punk()
            {
                this.NameKey = "Harder! Better! Faster! Stronger!";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                    {
                    daft_helm.ID,
                    punk_helm.ID
                    };
                this.IgnoreLichEyeBullets = true;
                this.statModifiers = new List<StatModifier>(0)
                {
                StatModifier.Create(PlayerStats.StatType.MovementSpeed,StatModifier.ModifyMethod.ADDITIVE, 2f),
                StatModifier.Create(PlayerStats.StatType.KnockbackMultiplier,StatModifier.ModifyMethod.ADDITIVE, .3f),
                StatModifier.Create(PlayerStats.StatType.Damage,StatModifier.ModifyMethod.ADDITIVE, .4f),
                StatModifier.Create(PlayerStats.StatType.Accuracy,StatModifier.ModifyMethod.ADDITIVE, -.2f),
                StatModifier.Create(PlayerStats.StatType.RateOfFire,StatModifier.ModifyMethod.ADDITIVE, .2f)
                };

                this.bonusSynergies = new List<CustomSynergyType>();
                
            }

        }


        /*
        public class Super_Duper_Fly : AdvancedSynergyEntry
        {

            public Super_Duper_Fly()
            {
                this.NameKey = "Super Duper Fly";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                    ETGMod.Databases.Items["Fly Friend"].PickupObjectId,
                    ETGMod.Databases.Items["Super Fly"].PickupObjectId,

                };
                this.IgnoreLichEyeBullets = true;
                this.statModifiers = new List<StatModifier>(0)
                {
                StatModifier.Create(PlayerStats.StatType.Coolness,StatModifier.ModifyMethod.ADDITIVE, 4f),
                 StatModifier.Create(PlayerStats.StatType.Accuracy,StatModifier.ModifyMethod.ADDITIVE, .2f),

                };

                this.bonusSynergies = new List<CustomSynergyType>();
            }

        }
        */
        public class tomislav : AdvancedSynergyEntry
        {

            public tomislav()
            {
                this.NameKey = "Tomislav";
                this.MandatoryGunIDs = new List<int>
                {
                    84
                };
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                    sandvich.ID

                };
                this.IgnoreLichEyeBullets = true;
                this.statModifiers = new List<StatModifier>(0)
                {
                StatModifier.Create(PlayerStats.StatType.KnockbackMultiplier,StatModifier.ModifyMethod.ADDITIVE, -.80f),
                StatModifier.Create(PlayerStats.StatType.Accuracy,StatModifier.ModifyMethod.ADDITIVE, -.80f),
                 StatModifier.Create(PlayerStats.StatType.RateOfFire,StatModifier.ModifyMethod.ADDITIVE, -.1f),
                };

                this.bonusSynergies = new List<CustomSynergyType>();
            }

        }

        public class split : AdvancedSynergyEntry
        {

            public split()
            {
                this.NameKey = "Split personality";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                    bad_attitude.ID,
                    187

                };
                this.IgnoreLichEyeBullets = true;
                this.statModifiers = new List<StatModifier>(0)
                {

                    StatModifier.Create(PlayerStats.StatType.GlobalPriceMultiplier,StatModifier.ModifyMethod.ADDITIVE, -.1f),
                    StatModifier.Create(PlayerStats.StatType.MoneyMultiplierFromEnemies,StatModifier.ModifyMethod.ADDITIVE, 2f)
                };

                this.bonusSynergies = new List<CustomSynergyType>();
            }


        }
        public class flurry_of_blows : AdvancedSynergyEntry
        {

            public flurry_of_blows()
            {
                this.NameKey = "Flurry rush";
                this.MandatoryGunIDs = new List<int>
                {
                   hail_2_u.ID
                };
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                     

                };
                this.OptionalItemIDs = new List<int>
                {
                   stardust.ID,
                Fates_blessing.ID
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                    StatModifier.Create(PlayerStats.StatType.RateOfFire,StatModifier.ModifyMethod.ADDITIVE, 8f),
                    StatModifier.Create(PlayerStats.StatType.Damage,StatModifier.ModifyMethod.ADDITIVE, -.7f),
                    StatModifier.Create(PlayerStats.StatType.DamageToBosses,StatModifier.ModifyMethod.ADDITIVE, -.7f),
                    StatModifier.Create(PlayerStats.StatType.AdditionalClipCapacityMultiplier,StatModifier.ModifyMethod.ADDITIVE, 8f),
                    StatModifier.Create(PlayerStats.StatType.AdditionalGunCapacity,StatModifier.ModifyMethod.ADDITIVE, 1f),

                };

                this.bonusSynergies = new List<CustomSynergyType>();
            }
        }

        public class BEEES : AdvancedSynergyEntry
        {

            public BEEES()
            {
                this.NameKey = "Biolgical Warfare";
                this.MandatoryGunIDs = new List<int>
                {

                };
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                   Rocket_boots.Item_ID

                };
                this.OptionalItemIDs = new List<int>
                {
                    92,14,630,138,
                };
                this.IgnoreLichEyeBullets = true;
                this.statModifiers = new List<StatModifier>(0)
                {


                };

                this.bonusSynergies = new List<CustomSynergyType>();
            }
        }

        /*
        public class nano : AdvancedSynergyEntry
        {

            public nano()
            {
                this.NameKey = "You're powered up!";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                    ETGMod.Databases.Items["nano boost"].PickupObjectId,
                    ETGMod.Databases.Items["nanostone"].PickupObjectId,
                };
                this.IgnoreLichEyeBullets = true;
                this.statModifiers = new List<StatModifier>(0)
                {


                };

                this.bonusSynergies = new List<CustomSynergyType>();
            }
        }*/
        public class Big_problem : AdvancedSynergyEntry
        {

            public Big_problem()
            {
                this.NameKey = "A really big problem";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                    dog.ID,
                    301

                };
                this.IgnoreLichEyeBullets = true;
                this.statModifiers = new List<StatModifier>(0)
                {

                    
                };

                this.bonusSynergies = new List<CustomSynergyType>();
            }


        }
        public class lich : AdvancedSynergyEntry
        {

            public lich()
            {
                this.NameKey = "Whole again";
                this.MandatoryGunIDs = new List<int>
                {
                    Za_hando.ID
                };
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                     213,

                };
                this.OptionalItemIDs = new List<int>
                {

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                    StatModifier.Create(PlayerStats.StatType.ReloadSpeed,StatModifier.ModifyMethod.ADDITIVE, -.3f),

                    StatModifier.Create(PlayerStats.StatType.RateOfFire,StatModifier.ModifyMethod.ADDITIVE, .2f),


                };

                this.bonusSynergies = new List<CustomSynergyType>();
            }
        }
        public class Chariot : AdvancedSynergyEntry
        {

            public Chariot()
            {
                this.NameKey = "Droppable Armor";
                this.MandatoryGunIDs = new List<int>
                {
                    NewNewCopperChariot.ID
                };
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                     545,

                };
                this.OptionalItemIDs = new List<int>
                {

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                  


                };

                this.bonusSynergies = new List<CustomSynergyType>();
            }
        }
        public class the_World_revolving : AdvancedSynergyEntry
        {

            public the_World_revolving()
            {
                this.NameKey = "Chaos Chaos CHAOS!";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                    {
                     ChamberofChambers.ID,
                     SpeedyChamber.ID
                    };
                this.IgnoreLichEyeBullets = true;
                this.statModifiers = new List<StatModifier>(0)
                {
               
                StatModifier.Create(PlayerStats.StatType.ReloadSpeed,StatModifier.ModifyMethod.ADDITIVE, -3f),
                
                StatModifier.Create(PlayerStats.StatType.RateOfFire,StatModifier.ModifyMethod.ADDITIVE, .5f)
                };

                this.bonusSynergies = new List<CustomSynergyType>();
            }

        }

        public class doubleStandard : AdvancedSynergyEntry
        {

            public doubleStandard()
            {
                this.NameKey = "Double Standards";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                    PeaceStandard.ID,
                    529

                };
                this.IgnoreLichEyeBullets = true;
                this.statModifiers = new List<StatModifier>(0)
                {


                };

                this.bonusSynergies = new List<CustomSynergyType>();
            }
        }

        public class Mozam_hammer : AdvancedSynergyEntry
        {

            public Mozam_hammer()
            {
                this.NameKey = "Hop-up: Hammer Point Rounds";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                    {
                     Mozam.ID

                    };
                this.OptionalItemIDs = new List<int>
                    {
                     


                     111,//heavy bullets
                     
                     256,// heavy boots
                     457,//spiked armor
                     271//riddle of lead

                    };
                this.OptionalGunIDs = new List<int>
                {
                     390,//cobalt hammer
                     91,//the hammer
                     610,//woodbeam
                     393,//anvilain,
                     157,// big iron
                     545,//ac15
                     601,//big shotgun
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }
        }
        public class Mozam_fools : AdvancedSynergyEntry
        {
            public Mozam_fools()
            {
                this.NameKey = "Hop-up: April Fools";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                    Mozam.ID
                };
                this.OptionalItemIDs = new List<int>
                {
                    241,// skatter
                    //PickupObjectDatabase.GetByEncounterName("Table Tech Dizzy").PickupObjectId,
                    //PickupObjectDatabase.GetByEncounterName("Slide Tech Slide").PickupObjectId,
                    PickupObjectDatabase.GetByEncounterName("Tiger Eye").PickupObjectId,
                    //409,//tv
                    216 // box

                };
                this.OptionalGunIDs = new List<int>
                {
                    539, // boxing glove
                    340, //lower r
                    10,  //watergun
                    503, //bullet
                    512 // shell
                      
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }

        }

        public class Mozam_Throw : AdvancedSynergyEntry
        {
            public Mozam_Throw()
            {
                this.NameKey = "Hop-up: Throw Away Joke";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                    Mozam.ID
                };
                this.OptionalItemIDs = new List<int>
                {
                   500, // hip holdster
                  


                };
                this.OptionalGunIDs = new List<int>
                {
                  PickupObjectDatabase.GetByEncounterName("Jk-47").PickupObjectId,
                   126, // shotbow
                   8,   // bow
                   31,  // klobbe

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {
                    StatModifier.Create(PlayerStats.StatType.ThrownGunDamage,StatModifier.ModifyMethod.ADDITIVE, 20f),
                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }

        }
        /*
        public class Mozam_Shatter : AdvancedSynergyEntry
        {
            public Mozam_Shatter()
            {
                this.NameKey = "Hop-up: Shattering Tier Lists";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                    PickupObjectDatabase.GetByEncounterName("Mozambique").PickupObjectId,
                    PickupObjectDatabase.GetByEncounterName("World Shatter").PickupObjectId

                };
                this.OptionalItemIDs = new List<int>
                {
                  
                  


                };
                this.OptionalGunIDs = new List<int>
                {
                
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {
                   
                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }

        }
        */
        public class Mozam_mazoM : AdvancedSynergyEntry
        {
            public Mozam_mazoM()
            {
                this.NameKey = "Hop-up: Double Up";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                    Mozam.ID

                };
                this.OptionalItemIDs = new List<int>
                {

                };
                this.OptionalGunIDs = new List<int>
                {
                    93,
                    329,
                    122,
                    51
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }

        }

        public class MonsterHunter : AdvancedSynergyEntry
        {
            public MonsterHunter()
            {
                this.NameKey = "Dragun Slayer";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                   Lance.lnc,
                   Rage_shield.ID

                };
                this.OptionalItemIDs = new List<int>
                {




                };
                this.OptionalGunIDs = new List<int>
                {

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }

        }

        public class DC : AdvancedSynergyEntry
        {
            public DC()
            {
                this.NameKey = "Old Chimes";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                    Hells_bells.ID

                };
                this.OptionalItemIDs = new List<int>
                {
                    237

                };
                this.OptionalGunIDs = new List<int>
                {
                     506
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }

        }
        public class AC : AdvancedSynergyEntry
        {
            public AC()
            {
                this.NameKey = "New Waves";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                   Hells_bells.ID

                };
                this.OptionalItemIDs = new List<int>
                {

                    469,471,468,470,467


                };
                this.OptionalGunIDs = new List<int>
                {
                     149,
                     230,
                     602,

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }

        }
        public class Mas_Queso : AdvancedSynergyEntry
        {
            public Mas_Queso()
            {
                this.NameKey = "Mas Queso";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                   Sheila.ID
                };
                this.OptionalItemIDs = new List<int>
                {
                     667,
                     663,
                     662,
                     



                };
                this.OptionalGunIDs = new List<int>
                {
                     626
                     

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }

        }
        public class Iron_grip : AdvancedSynergyEntry
        {
            public Iron_grip()
            {
                this.NameKey = "Iron Grip";
                this.MandatoryItemIDs = new List<int> //Look in the items ID map in the gungeon code for the ids.
                {
                    punt.ID

                };
                this.OptionalItemIDs = new List<int>
                {
                     
                     256




                };
                this.OptionalGunIDs = new List<int>
                {
                    


                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }
            

        }
       
        public class Banana : AdvancedSynergyEntry
        {
            public Banana()
            {
                this.NameKey = "Bananarmaments";
                this.MandatoryItemIDs = new List<int>
                {
                    MonkeyBarrel.mbID


                };
                this.OptionalItemIDs = new List<int>
                {

                    


                };
                this.OptionalGunIDs = new List<int>
                {
                    478

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }

        public class BarrelBros : AdvancedSynergyEntry
        {
            public BarrelBros()
            {
                this.NameKey = "Barrel Bros";
                this.MandatoryItemIDs = new List<int>
                {
                    


                };
                this.OptionalItemIDs = new List<int>
                {




                };
                this.OptionalGunIDs = new List<int>
                {
                   7,
                    MonkeyBarrel.mbID,
                    MBSynergyForm.mbakID

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }
        /*
        public class Apex : AdvancedSynergyEntry
        {
            public Apex()
            {
                this.NameKey = "Apex Predator";
                this.MandatoryItemIDs = new List<int>
                {
                     PickupObjectDatabase.GetByEncounterName("Ak-47").PickupObjectId,

                     PickupObjectDatabase.GetByEncounterName("Monkey Barrel").PickupObjectId,


                };
                this.OptionalItemIDs = new List<int>
                {




                };
                this.OptionalGunIDs = new List<int>
                {
                     
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }
        */
        public class JumpShark : AdvancedSynergyEntry
        {
            public JumpShark()
            {
                this.NameKey = "Jump The Shark";
                this.MandatoryItemIDs = new List<int>
                {
                    FishBones.ID


                };
                this.OptionalItemIDs = new List<int>
                {




                };
                this.OptionalGunIDs = new List<int>
                {
                    359,


                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }
        
        /*
        public class Noir : AdvancedSynergyEntry
        {
            public Noir()
            {
                this.NameKey = "Stormy Nights";
                this.MandatoryItemIDs = new List<int>
                {
                    PickupObjectDatabase.GetByEncounterName("Chicago Typewriter").PickupObjectId,


                };
                this.OptionalItemIDs = new List<int>
                {
                    PickupObjectDatabase.GetByEncounterName("Cigarlet").PickupObjectId,



                };
                this.OptionalGunIDs = new List<int>
                {
                     PickupObjectDatabase.GetByEncounterName("Baba Yaga").PickupObjectId,

                     PickupObjectDatabase.GetByEncounterName("Le'Voleur").PickupObjectId,
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }

        */



        public class Tempered_dodo : AdvancedSynergyEntry
        {
            public Tempered_dodo()
            {
                this.NameKey = "Tempered Dodogama";
                this.MandatoryItemIDs = new List<int>
                {
                    BabyGoodDodoGama.ID


                };
                this.OptionalItemIDs = new List<int>
                {
                    Rage_shield.ID,

                    403,

                };
                this.OptionalGunIDs = new List<int>
                {
                     GunLance.ID,

                     Lance.lnc
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }
        public class Strike_first : AdvancedSynergyEntry
        {
            public Strike_first()
            {
                this.NameKey = "Strike First";
                this.MandatoryItemIDs = new List<int>
                {
                    FirstImpression.StandardID

                };
                this.OptionalItemIDs = new List<int>
                {
                   373
                };
                this.OptionalGunIDs = new List<int>
                {
                   
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }
        public class Mr_Grinch : AdvancedSynergyEntry
        {
            public Mr_Grinch()
            {
                this.NameKey = "Mr. Grinch";
                this.MandatoryItemIDs = new List<int>
                {
                    Present.ID

                };
                this.OptionalItemIDs = new List<int>
                {
                   663,// rat sack
                   364,//ice heart

                };
                this.OptionalGunIDs = new List<int>
                {

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }

        }

        public class Second_Impression : AdvancedSynergyEntry
        {
            public Second_Impression()
            {
                this.NameKey = "Second Impression";
                this.MandatoryItemIDs = new List<int>
                {
                    FirstImpression.StandardID,
                    EjectButton.ID

                };
                this.OptionalItemIDs = new List<int>
                {
                   
                };
                this.OptionalGunIDs = new List<int>
                {

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }
        public class Scuffed_shoes : AdvancedSynergyEntry
        {
            public Scuffed_shoes()
            {
                this.NameKey = "Scuffed Soles";
                this.MandatoryItemIDs = new List<int>
                {
                    Mares_Leg.ID

                };
                this.OptionalItemIDs = new List<int>
                {
                    315,
                    Rocket_boots.Item_ID,
                    Long_roll_boots.ID,
                    526,
                    667,
                };
                this.OptionalGunIDs = new List<int>
                {

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }
        /*
        public class Bandit_extraordinaire : AdvancedSynergyEntry
        {
            public Bandit_extraordinaire()
            {
                this.NameKey = "Bandit Extraordinaire";
                this.MandatoryItemIDs = new List<int>
                {
                    PickupObjectDatabase.GetByEncounterName("Mares Leg").PickupObjectId,
                    PickupObjectDatabase.GetByEncounterName("StarBurst").PickupObjectId,
                    PickupObjectDatabase.GetByEncounterName("LoneStar").PickupObjectId,


                };
                this.OptionalItemIDs = new List<int>
                {
                   
                };
                this.OptionalGunIDs = new List<int>
                {

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {
                    StatModifier.Create(PlayerStats.StatType.ReloadSpeed,StatModifier.ModifyMethod.ADDITIVE, -.5f),
                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }
        */
       
        public class DualLoader : AdvancedSynergyEntry
        {
            public DualLoader()
            {
                this.NameKey = "Dual Loader";
                this.MandatoryItemIDs = new List<int>
                {


                    Lone.ID

                };
                this.OptionalItemIDs = new List<int>
                {
                    213,
                    396,
                    168
                };
                this.OptionalGunIDs = new List<int>
                {
                    9,
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }
        public class Boomers : AdvancedSynergyEntry
        {
            public Boomers()
            {
                this.NameKey = "Boomers";
                this.MandatoryItemIDs = new List<int>
                {
                    Express.ID,
                    Queen.ID

                };
                this.OptionalItemIDs = new List<int>
                {
                   
                };
                this.OptionalGunIDs = new List<int>
                {
                   
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {
                    StatModifier.Create(PlayerStats.StatType.ReloadSpeed,StatModifier.ModifyMethod.ADDITIVE, -.1f),
                    StatModifier.Create(PlayerStats.StatType.RateOfFire,StatModifier.ModifyMethod.ADDITIVE, -.2f),

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }

        public class PinkLemonade : AdvancedSynergyEntry
        {
            public PinkLemonade()
            {
                this.NameKey = "Pink Lemonade";
                this.MandatoryItemIDs = new List<int>
                {


                    Lemonade.ID

                };
                this.OptionalItemIDs = new List<int>
                {
                    527,

                };
                this.OptionalGunIDs = new List<int>
                {
                   379,
                   200,
                   Bad_Name.ID

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }

        public class Walkies : AdvancedSynergyEntry
        {
            public Walkies()
            {
                this.NameKey = "Walk The Dog";
                this.MandatoryItemIDs = new List<int>
                {


                    GoYo.ID

                };
                this.OptionalItemIDs = new List<int>
                {
                    //300, dog
                    492, // angry dog
                    dog.ID


                };
                this.OptionalGunIDs = new List<int>
                {
                  

                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }

        public class AngryMama : AdvancedSynergyEntry
        {
            public AngryMama()
            {
                this.NameKey = "Angry Mama";
                this.MandatoryItemIDs = new List<int>
                {


                    Bombushka.ID

                };
                this.OptionalItemIDs = new List<int>
                {
                    323,
                    bad_attitude.ID,
                    Rage_shield.ID

                };
                this.OptionalGunIDs = new List<int>
                {
                     Bab.ID
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {

                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }
        public class Prepare_for_TitanFall : AdvancedSynergyEntry
        {
            public Prepare_for_TitanFall()
            {
                this.NameKey = "Prepare for Titanfall";
                this.MandatoryItemIDs = new List<int>
                {
                   P2020_item.ID
                };
                this.OptionalItemIDs = new List<int>
                {

                    
                     Spark.ID

                };
                this.OptionalGunIDs = new List<int>
                {
                    Mozam.ID,
                    ChargeRifle.ID,
                    Watch_Standard.StandardID,
                    Watch_Charged.Charged,
                    Rampage.ID
                    
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {
                    StatModifier.Create(PlayerStats.StatType.MovementSpeed,StatModifier.ModifyMethod.ADDITIVE, .5f),
                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }
        public class Rainbow_in_The_Dark : AdvancedSynergyEntry
        {
            public Rainbow_in_The_Dark()
            {
                this.NameKey = "Rainbow In The Dark";
                this.MandatoryItemIDs = new List<int>
                {
                    SIND.ID
                };
                this.OptionalItemIDs = new List<int>
                {

                };
                this.OptionalGunIDs = new List<int>
                {
                    100
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {
                    StatModifier.Create(PlayerStats.StatType.MovementSpeed,StatModifier.ModifyMethod.ADDITIVE, .5f),
                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }

        public class PaintTheTown : AdvancedSynergyEntry
        {
            public PaintTheTown()
            {
                this.NameKey = "Paint The Town RED";
                this.MandatoryItemIDs = new List<int>
                {
                   Rampage.ID
                };
                this.OptionalItemIDs = new List<int>
                {
                    253,
                    242,
                };
                this.OptionalGunIDs = new List<int>
                {
                    384,
                    125,
                };
                this.IgnoreLichEyeBullets = false;
                this.statModifiers = new List<StatModifier>(0)
                {
                    StatModifier.Create(PlayerStats.StatType.MovementSpeed,StatModifier.ModifyMethod.ADDITIVE, .5f),
                };

                this.bonusSynergies = new List<CustomSynergyType>();

            }


        }
        //
    }
    }
       





