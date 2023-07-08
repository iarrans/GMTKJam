using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDungeonItem", menuName = "Dungeon Item")]
public class DungeonItem : ScriptableObject
{

    public int id;

    public Sprite itemIcon;

    public GameObject prefab3DModel;

    public enum ItemType{
        LOOT = 0,//0
        ENEMY = 1,//1
        ARCHITECTURE = 2//2
    }

    public ItemType itemType;

}
