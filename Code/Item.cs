using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item",menuName ="Item/New Item/Create")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;

    public ItemType itemtype;

    public enum ItemType{
        heath,
        mana,
        shield,
        shoe,
        book,
        weapon,
    }
}
