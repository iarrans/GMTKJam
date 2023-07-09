using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LineElementBehaviour : MonoBehaviour
{
    public LineElementCanvasBehaviour canvasBehaviour;

    public LineElementType currentType;

    public LineBehaviour lineBehaviour;

    private void Awake()
    {
        canvasBehaviour.DeactivateAll();
        currentType = LineElementType.TURN_OFF;
    }

    public void ChangeLineType(LineElementType newType)
    {
        DesactivateCanvasElements(currentType);
        ActivateCanvasElements(newType);
        currentType = newType;
    }

    private void DesactivateCanvasElements(LineElementType type)
    {
        switch(type)
        {
            case LineElementType.LOBBY:
                canvasBehaviour.SetLobbyActive(false);
                break;
            case LineElementType.NORMAL:
                canvasBehaviour.SetDangerActive(false);
                break;
            case LineElementType.END:
                canvasBehaviour.SetEndBackgrounActive(false);
                break;
            case LineElementType.PENDING:
                canvasBehaviour.SetPendingBackgroundActive(false);
                break;
            case LineElementType.TURN_OFF:
                canvasBehaviour.SetEmptyBackgroundActive(false);
                break;
        }
    }

    private void ActivateCanvasElements(LineElementType type)
    {
        switch (type)
        {
            case LineElementType.LOBBY:
                canvasBehaviour.SetLobbyActive(true);
                canvasBehaviour.SetMapBackgroundActive(true);
                break;
            case LineElementType.NORMAL:
                canvasBehaviour.SetMapBackgroundActive(true);
                break;
            case LineElementType.END:
                canvasBehaviour.SetEndBackgrounActive(true);
                break;
            case LineElementType.PENDING:
                canvasBehaviour.SetPendingBackgroundActive(true);
                break;
        }
    }

    public void SetLineElementActive(bool isActive, LineElementType type)
    {
        if(!isActive)
        {
            canvasBehaviour.DeactivateAll();
        } else
        {
            ChangeLineType(type);
        }
    }
}
