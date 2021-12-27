using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);    //pass inventory object into inventory script

        ItemWorld.SpawnItemWorld(new Vector3(5, 5), new Item { itemType = Item.ItemType.RecallPotion, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(-5, 5), new Item { itemType = Item.ItemType.Sword, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(0, 5), new Item { itemType = Item.ItemType.Axe, amount = 1 });
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            //Touching Item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}
