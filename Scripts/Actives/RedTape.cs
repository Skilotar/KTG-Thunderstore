﻿using ItemAPI;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

using Dungeonator;
using Gungeon;


namespace Knives
{
    class RedTape : SpawnObjectPlayerItem
    {
        public static void Init()
        {
            string itemName = "Cover-up Cassette";

            string resourceName = "Knives/Resources/Tape/Red_tape_001";

            GameObject obj = new GameObject(itemName);

            var item = obj.AddComponent<RedTape>();

            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);

            string shortDesc = "Let's Make Some Noise";
            string longDesc = "A busted cassette recorder that is stuck repeating an undo command indefinitely. Delevels enemies caught in its radius." +
                "\n\n\n - Knife_to_a_Gunfight";


            ItemBuilder.SetupItem(item, shortDesc, longDesc, "ski");
            ItemBuilder.SetCooldownType(item, ItemBuilder.CooldownType.Damage, 230);
            item.consumable = false;

            item.objectToSpawn = BuildPrefab();

            item.tossForce = 6;
            item.canBounce = true;

            item.IsCigarettes = false;
            item.RequireEnemiesInRoom = true;


            item.AudioEvent = "Play_OBJ_bomb_fuse_01";
            item.IsKageBunshinItem = false;

            item.quality = PickupObject.ItemQuality.C;
        }


        public static GameObject BuildPrefab()
        {

            var bomb = SpriteBuilder.SpriteFromResource("Knives/Resources/Tape/Red_tape_001", new GameObject("RedTape"));
            bomb.SetActive(false);
            FakePrefab.MarkAsFakePrefab(bomb);

            var animator = bomb.AddComponent<tk2dSpriteAnimator>();
            var collection = (PickupObjectDatabase.GetById(108) as SpawnObjectPlayerItem).objectToSpawn.GetComponent<tk2dSpriteAnimator>().Library.clips[0].frames[0].spriteCollection;

            var deployAnimation = SpriteBuilder.AddAnimation(animator, collection, new List<int>
            {

                SpriteBuilder.AddSpriteToCollection("Knives/Resources/Tape/Red_tape_001", collection),
                SpriteBuilder.AddSpriteToCollection("Knives/Resources/Tape/Red_tape_002", collection),
                SpriteBuilder.AddSpriteToCollection("Knives/Resources/Tape/Red_tape_003", collection),
                SpriteBuilder.AddSpriteToCollection("Knives/Resources/Tape/Red_tape_004", collection),
                SpriteBuilder.AddSpriteToCollection("Knives/Resources/Tape/Red_tape_005", collection),
                SpriteBuilder.AddSpriteToCollection("Knives/Resources/Tape/Red_tape_006", collection),
                SpriteBuilder.AddSpriteToCollection("Knives/Resources/Tape/Red_tape_007", collection),
                SpriteBuilder.AddSpriteToCollection("Knives/Resources/Tape/Red_tape_008", collection),

            }, "RedTapeDeploy", tk2dSpriteAnimationClip.WrapMode.Once);
            deployAnimation.fps = 12;
            foreach (var frame in deployAnimation.frames)
            {
                frame.eventLerpEmissiveTime = 0.5f;
                frame.eventLerpEmissivePower = 30f;
            }

            var explodeAnimation = SpriteBuilder.AddAnimation(animator, collection, new List<int>
            {

                SpriteBuilder.AddSpriteToCollection("Knives/Resources/Tape/Red_tape_001", collection),


                
            }, "RedTapeExplode", tk2dSpriteAnimationClip.WrapMode.Once);
            explodeAnimation.fps = 30;
            foreach (var frame in explodeAnimation.frames)
            {
                frame.eventLerpEmissiveTime = 0.5f;
                frame.eventLerpEmissivePower = 30f;
            }

            var armedAnimation = SpriteBuilder.AddAnimation(animator, collection, new List<int>
            {

                SpriteBuilder.AddSpriteToCollection("Knives/Resources/Tape/Red_tape_009", collection),
                SpriteBuilder.AddSpriteToCollection("Knives/Resources/Tape/Red_tape_010", collection),
                SpriteBuilder.AddSpriteToCollection("Knives/Resources/Tape/Red_tape_011", collection),
                SpriteBuilder.AddSpriteToCollection("Knives/Resources/Tape/Red_tape_012", collection),


            }, "RedTapeArmed", tk2dSpriteAnimationClip.WrapMode.LoopSection);
            armedAnimation.fps = 10.0f;
            
            foreach (var frame in armedAnimation.frames)
            {
                frame.eventLerpEmissiveTime = 0.5f;
                frame.eventLerpEmissivePower = 30f;
            }

            var audioListener = bomb.AddComponent<AudioAnimatorListener>();
            audioListener.animationAudioEvents = new ActorAudioEvent[]
            {
                new ActorAudioEvent
                {
                    eventName = "Play_OBJ_mine_beep_01",
                    eventTag = "beep"
                }
            };

            ProximityMine proximityMine = new ProximityMine
            {
                explosionData = new ExplosionData
                {
                    useDefaultExplosion = false,
                    doDamage = true,
                    forceUseThisRadius = false,
                    damageRadius = 4.5f,
                    damageToPlayer = 0,
                    damage = 31.5f, // exactly enough to always kill the arrowkin it makes unless they are jammed or buffed
                    breakSecretWalls = true,
                    secretWallsRadius = 3.5f,
                    forcePreventSecretWallDamage = false,
                    doDestroyProjectiles = true,
                    doForce = true,
                    pushRadius = 6,
                    force = 25,
                    debrisForce = 12.5f,
                    preventPlayerForce = false,
                    explosionDelay = 0.1f,
                    usesComprehensiveDelay = false,
                    comprehensiveDelay = 0,
                    playDefaultSFX = true,

                    doScreenShake = true,
                    ss = new ScreenShakeSettings
                    {
                        magnitude = 2,
                        speed = 6.5f,
                        time = 0.22f,
                        falloff = 0,
                        direction = new Vector2(0, 0),
                        vibrationType = ScreenShakeSettings.VibrationType.Auto,
                        simpleVibrationStrength = Vibration.Strength.Medium,
                        simpleVibrationTime = Vibration.Time.Normal
                    },
                    doStickyFriction = false,
                    doExplosionRing = true,
                    isFreezeExplosion = false,
                    freezeRadius = 5,
                    IsChandelierExplosion = false,
                    rotateEffectToNormal = false,
                    ignoreList = new List<SpeculativeRigidbody>(),
                    overrideRangeIndicatorEffect = null,
                    effect = (PickupObjectDatabase.GetById(108) as SpawnObjectPlayerItem).objectToSpawn.GetComponent<ProximityMine>().explosionData.effect,
                    freezeEffect = null,
                },
                explosionStyle = ProximityMine.ExplosiveStyle.TIMED,
                detectRadius = 3.5f,
                explosionDelay = 4f,
                usesCustomExplosionDelay = false,
                customExplosionDelay = 0.1f,
                deployAnimName = "RedTapeDeploy",
                explodeAnimName = "RedTapeExplode",
                idleAnimName = "RedTapeArmed",




            };

            var boom = bomb.AddComponent<ProximityMine>(proximityMine);


            return bomb;
        }

        public Vector2 centerPosition;
        public bool vangaurd;
 
        public override void Update()
        {
            if (this.LastOwner != null)
            {
               
                PlayerController Owner = this.LastOwner;
                if (this.spawnedPlayerObject != null)
                {
                    centerPosition = this.spawnedPlayerObject.GetComponent<tk2dSprite>().sprite.WorldCenter;
                    
                    List<AIActor> activeEnemies = Owner.CurrentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All);

                    foreach (AIActor aiactor in activeEnemies)
                    {
                        
                        bool flag3 = Vector2.Distance(aiactor.CenterPosition, centerPosition) < 4.5f && aiactor.healthHaver.GetMaxHealth() > 0f && aiactor != null && aiactor.specRigidbody != null && Owner != null;
                        bool flag4 = flag3;
                        aiactor.gameObject.GetOrAddComponent<AiactorSpecialStates>();
                        if (flag4 && !aiactor.gameObject.GetComponent<AiactorSpecialStates>().RedTaped)
                        {
                            
                            StartCoroutine(DeLevel(aiactor,Owner));
                            aiactor.gameObject.GetComponent<AiactorSpecialStates>().RedTaped = true;
                        }
                    }

                    
                    if (vangaurd)
                    {
                        HandleRadialIndicator();
                        StartCoroutine(bombPreDet());
                        vangaurd = false;
                    }


                }

                if (this.spawnedPlayerObject == null)
                {
                    centerPosition = new Vector2(0, 0);
                    if (!vangaurd)
                    {
                       
                        vangaurd = true;
                    }

                }

            }


            base.Update();
        }
        public System.Random rng = new System.Random();
        public IEnumerator bombPreDet()
        {
            yield return new WaitForSecondsRealtime(.25f);
            int random = rng.Next(1, 5);
            switch (random)
            {
                case 1: AkSoundEngine.PostEvent("Play_tape_01", base.gameObject);
                    break;

                case 2: AkSoundEngine.PostEvent("Play_tape_02", base.gameObject);
                    break;

                case 3: AkSoundEngine.PostEvent("Play_tape_03", base.gameObject);
                    break;

                case 4: AkSoundEngine.PostEvent("Play_tape_04", base.gameObject);
                    break;

                case 5: AkSoundEngine.PostEvent("Play_tape_05", base.gameObject);
                    break;

            }
            yield return new WaitForSecondsRealtime(3.5f);
            UnhandleRadialIndicator();
        }
        public IEnumerator DeLevel(AIActor aiactor, PlayerController Owner)
        {
            

            yield return new WaitForSeconds(1.9f);
            if(aiactor != null && aiactor.healthHaver != null && aiactor.specRigidbody != null && Owner != null)
            {
                if(aiactor.healthHaver.IsAlive)
                {
                    if (Vector2.Distance(aiactor.CenterPosition, centerPosition) <= 4.5f)
                    {

                        aiactor.healthHaver.SuppressDeathSounds = true;

                        aiactor.Transmogrify(EnemyDatabase.GetOrLoadByGuid("05891b158cd542b1a5f3df30fb67a7ff"), BlinkpoofVfx);
                        yield return new WaitForSeconds(.01f);
                        aiactor.healthHaver.SuppressDeathSounds = false;

                    }
                    else
                    {
                        aiactor.gameObject.GetComponent<AiactorSpecialStates>().RedTaped = false;
                    }

                }


            }



        }
        private void HandleRadialIndicator()
        {
            
            bool flag = !this.m_indicator;
            if (flag)
            {
                
                this.m_indicator = ((GameObject)UnityEngine.Object.Instantiate(ResourceCache.Acquire("Global VFX/HeatIndicator"), centerPosition, Quaternion.identity, this.spawnedPlayerObject.transform)).GetComponent<HeatIndicatorController>();
                this.m_indicator.CurrentRadius = 4.5f;
                this.m_indicator.IsFire = false;
                this.m_indicator.CurrentColor = new Color(0.46f, 0.59f, 0.13f);
            }
        }

        private void UnhandleRadialIndicator()
        {
            bool flag = this.m_indicator;
            if (flag)
            {
                this.m_indicator.EndEffect();
                this.m_indicator = null;
            }
        }
        public static BlinkPassiveItem m_BlinkPassive = PickupObjectDatabase.GetById(436).GetComponent<BlinkPassiveItem>();
        public GameObject BlinkpoofVfx = m_BlinkPassive.BlinkpoofVfx;
        public HeatIndicatorController m_indicator;
    }
}
