using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButtonBehaviour : ButtonBehaviour
{
    public DungeonItem item;

    /// <summary>
    /// Change cursor on click
    /// </summary>
    public override void OnClick()
    {
        Cursor.SetCursor(item.cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
