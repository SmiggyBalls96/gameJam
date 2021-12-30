using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    public GameObject inventoryGUI;

    private int count = 1;  // For using character 'E' to bring up gui
    private bool hotbar = false; // Check to see if an item is already in hotbar

    public GameObject myPrefab; //Delete this, make it so that myprefab is the item that is clicked on
    private void Awake()
    {

        inventory = new Inventory(UseItem);
        uiInventory.SetPlayer(this);
        uiInventory.SetInventory(inventory);    //pass inventory object into inventory script

        ItemWorld.SpawnItemWorld(new Vector3(-22, 0), new Item { itemType = Item.ItemType.RecallPotion, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(-23, 0), new Item { itemType = Item.ItemType.Sword, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(-24, 0), new Item { itemType = Item.ItemType.Axe, amount = 1 });
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

    private void UseItem(Item item)
    {

        if (!hotbar)
        {
            switch (item.itemType)
            {
                case Item.ItemType.RecallPotion:
                    //Move item to hotbar
                    Instantiate(myPrefab, new Vector3(-20, 4), Quaternion.identity);   //Delete this, make it so that myprefab is the item that is clicked on 

                    inventory.RemoveItem(item);
                    hotbar = true;      //Makes it so another item can't be equiped into hotbar until the previous one is removed
                    break;
                case Item.ItemType.Sword:
                    //Move item to hotbar
                    inventory.RemoveItem(item);
                    hotbar = true;
                    break;
                case Item.ItemType.Axe:
                    //Move item to hotbar
                    inventory.RemoveItem(item);
                    hotbar = true;
                    break;
            }
        }
        
    }

    private void Start()
    {
        inventoryGUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true && count == 0)   // if press e, open inventory, else don't
        {
            inventoryGUI.SetActive(true); ;
            count++;
        }
        else if (Input.GetKeyDown(KeyCode.E) == true && count == 1)
        {
            inventoryGUI.SetActive(false);
            count--;
        }


    }
}
