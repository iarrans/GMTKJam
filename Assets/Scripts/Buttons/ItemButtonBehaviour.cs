using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButtonBehaviour : ButtonBehaviour
{
    public DungeonItem item;

    /// <summary>
    /// Change cursor on click
    /// </summary>
    public override void OnClick(MouseController mouseController)
    {
        audioSource.Play();
        // Because the cursor texture size is 200x200, the offset must be 100x100 to center the click
        Cursor.SetCursor(item.cursorTexture, new(100f, 100f), CursorMode.Auto);
        mouseController.item = item;
    }
}
