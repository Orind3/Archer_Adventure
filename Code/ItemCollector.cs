using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{


    public Item item;
    void pickUp(){
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    private void OnMouseDown() {
        pickUp();
    }

    private void OnTriggerEnter2D(Collider2D other) {
                InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }
}
