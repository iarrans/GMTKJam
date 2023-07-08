using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDungeonItem", menuName = "Dungeon Item")]
public class DungeonItem : ScriptableObject
{

    public int id;

    public Sprite sprite;

    public Texture2D cursorTexture;

    public GameObject prefab3DModel;

    public ItemType itemType;

    public override string ToString()
    {
        return id.ToString();
    }
}
