using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintSquareButtonBehaviour : ButtonBehaviour
{
    //position of the Matrix that this button represents
    public int row;
    public int column;

    public Transform itemPosition;
    public BlueprintController blueprintController;

    /// <summary>
    /// Checks if the active Object is eraser or other DungeonItem and creates said object or deletes the active one.
    /// </summary>
    /// <param name="mouseController">Active mouseController</param>
    public override void OnClick(MouseController mouseController)
    {
        if (mouseController.item == null) return;

        DungeonItem mouseItem = mouseController.item;
        if (mouseItem.itemType == ItemType.ERASER) {
            Debug.Log("Erase activeItem, in pos row column");
            blueprintController.DeleteDungeonItem(row, column);
        }
        else
        {
            Debug.Log("Add item " + mouseItem.id + " in position " + row + "," + column);
            blueprintController.AddDungeonItem(mouseController.item, itemPosition.transform.position, row, column);
        }
    }

}
