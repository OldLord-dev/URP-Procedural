using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(fileName = "itemData", menuName = "Item Data", order = 50)]
public class ItemData : ScriptableObject
{
    //[SerializeField]
   // private SpriteSet asteroidsSpriteSet;
    [SerializeField]
    private string itemName;

    [SerializeField]
    private ItemType itemType;



    public enum ItemType { Collectable, Tree };
    public string ItemName { get { return itemName; } }
    //public float AsteroidSpeed { get { return asteroidSpeed; } }
    public ItemType GetItemType { get { return itemType; } }
    //public SpriteSet AsteroidsSpriteSet { get { return asteroidsSpriteSet; } }
}
