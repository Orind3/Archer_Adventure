using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Transform itemContent;
    public GameObject inventoryItem;
    public ItemController[] itemController;
    public List<Item> Items = new List<Item>();
    private void Awake() {
        Instance = this;    
    }
    public void Add(Item item){
        Items.Add(item);
    }
    public void Remove(Item item){
        Items.Remove(item);
    }

    public void ListItem(){ 
        
        foreach(Transform item in itemContent){
            Destroy(item.gameObject);
        }

        foreach(var item in Items){
            GameObject obj = Instantiate(inventoryItem,itemContent);
            var itemName = obj.transform.Find("Item_name").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("Item_icon").GetComponent<Image>();
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
        
        setItemController();
    }

    public void setItemController(){
        this.itemController = itemContent.GetComponentsInChildren<ItemController>();
        for(int i = 0; i < Items.Count; i++){
            itemController[i].AddItem(Items[i]);
        }
    }
}
