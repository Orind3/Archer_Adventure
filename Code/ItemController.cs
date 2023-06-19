using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;

    public void RemoveItem(){
            InventoryManager.Instance.Remove(item);
            Destroy(gameObject);
    }

    public void AddItem(Item newItem){
        this.item = newItem;
    }

        public void useItem(){
            switch(item.itemtype){
                case Item.ItemType.heath: 
                    Player.Instance.increaseHealth(item.value);
                break;
                case Item.ItemType.mana:
                    Player.Instance.increaseMana(item.value);
                break;
                case Item.ItemType.shield:
                break;
                case Item.ItemType.shoe:
                break;
                case Item.ItemType.weapon:
                break;
            }
        RemoveItem();
    }


}
