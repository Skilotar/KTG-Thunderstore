using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using ItemAPI;
using Dungeonator;
using System.Collections.Generic;

namespace Knives
{
    class Book_of_misspelled_spells : PassiveItem
    {
        public static void Register()
        {
            //The name of the item
            string itemName = "Book of Mispells";

            //Refers to an embedded png in the project. Make sure to embed your resources! Google it
            string resourceName = "Knives/Resources/Book_o_mispells";

            //Create new GameObject
            GameObject obj = new GameObject(itemName);

            //Add a PassiveItem component to the object
            var item = obj.AddComponent<Book_of_misspelled_spells>();

            //Adds a sprite component to the object and adds your texture to the item sprite collection
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);

            //Ammonomicon entry variables
            string shortDesc = "Ah Braka Dabrah";
            string longDesc =

                "Wizard Enemies Randomize. Eh buk riten bie eh Whizurd thet ded naut pess literatur scool." +
                "\n\n\n - Knife_to_a_Gunfight";

            //Adds the item to the gungeon item list, the ammonomicon, the loot table, etc.
            //Do this after ItemBuilder.AddSpriteToObject!
            ItemBuilder.SetupItem(item, shortDesc, longDesc, "ski");

            //Adds the actual passive effect to the item
            //PlayerController owner = item.LastOwner as PlayerController;



            //Set the rarity of the item

            item.CanBeDropped = false;
            item.PersistsOnDeath = true;
            item.quality = PickupObject.ItemQuality.B;
            itemID = item.PickupObjectId;
            Remove_from_lootpool.RemovePickupFromLootTables(item);
            JinxItemDisplayStorageClass text = item.gameObject.GetOrAddComponent<JinxItemDisplayStorageClass>();
            text.jinxItemDisplayText = "Randomizes magic enemies.";
        }
        public static int itemID;

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }

        public override DebrisObject Drop(PlayerController player)
        {
           
            return base.Drop(player);
        }

        public override void Update()
        {
            try
            {
                if (this.Owner != null)
                {
                    RoomHandler currentRoom = this.Owner.CurrentRoom;
                    foreach (AIActor aiactor in currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All))
                    {
                        if (aiactor.isActiveAndEnabled)
                        {
                            for (int i = 0; i < this.Wizurds.Count; i++)
                            {
                                bool isin = aiactor.EnemyGuid == this.Wizurds[i];

                                if (isin && aiactor.IsTransmogrified == false)
                                {
                                    StartCoroutine(delayTransmog(aiactor));
                                }
                            }
                        }
                    }
                }

            }
            catch
            {

            }

            base.Update();
        }

        private IEnumerator delayTransmog(AIActor aiactor)
        {
            yield return new WaitForSeconds(1);
            int lineitem = UnityEngine.Random.Range(0, this.Wizurds.Count);
            string guid = Wizurds[lineitem];
            aiactor.Transmogrify(EnemyDatabase.GetOrLoadByGuid(guid), null);
        }

        public List<string> Wizurds = new List<string>
        {
            "844657ad68894a4facb1b8e1aef1abf9",//confirmed
            "c0ff3744760c4a2eb0bb52ac162056e6",//redbook
            "6f22935656c54ccfb89fca30ad663a64",//bluebook
            "a400523e535f41ac80a43ff6b06dc0bf",//greenbook
            "206405acad4d4c33aac6717d184dc8d4",//lil gunjurer
            "c4fba8def15e47b297865b18e36cbef8",//gunjurer
            "9b2cf2949a894599917d4d391a0b7394",//high gunjurer
            "56fb939a434140308b8f257f0f447829",//lore gunjurer
            
        };



    }
}

