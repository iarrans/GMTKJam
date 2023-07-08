using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintSquareButtonBehaviour : ButtonBehaviour
{
    //position of the Matrix that this button represents
    public int row;
    public int column;

    public GameObject activeItem;//3DObject created on top if this button
    public Transform itemPosition;

    /// <summary>
    /// Checks if the active Object is eraser or other DungeonItem and creates said object or deletes the active one.
    /// </summary>
    /// <param name="mouseController"></param>
    public override void OnClick(MouseController mouseController)
    {
        DungeonItem mouseItem = mouseController.item;
        if (mouseItem.itemType == ItemType.ERASER) {
            Debug.Log("Erase activeItem, in pos row column");
            //BlueprintController blueprintController = GameObject.Find("BlueprintController");
            //DeleteDungeonItem(row, column, activeItem);
        }
        else
        {
            Debug.Log("Add item " + mouseItem.id + " in position " + row + "," + column);
            //BlueprintController blueprintController = GameObject.F
            //BlueprintController blueprintController = GameObject.Find("BlueprintController");
            //AddDungeonItem(mouseItem, activeItem, itemPosition row, column);
        }
    }

}
