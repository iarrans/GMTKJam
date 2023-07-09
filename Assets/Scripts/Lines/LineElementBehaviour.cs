using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LineElementBehaviour : MonoBehaviour
{
    // public CanvasBehaviour canvasBehaviour;

    public LineElementType currentType;

    // private LineBehaviour lineBehaviour;

    private void Awake()
    {
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
                // canvasBehaviour.setLobbyActive(false);
                break;
            case LineElementType.NORMAL:
                // canvasBehaviour.setDangerActive(false);
                break;
            case LineElementType.END:
                // canvasBehaviour.setEndBackgroundActive(false);
                break;
            case LineElementType.PENDING:
                // canvasBehaviour.setPendingBackgroundActive(false);
                break;
            case LineElementType.TURN_OFF:
                // canvasBehaviour.setEmptyBackgroundActive(false);
                break;
        }
    }

    private void ActivateCanvasElements(LineElementType type)
    {
        switch (type)
        {
            case LineElementType.LOBBY:
                // canvasBehaviour.setLobbyActive(true);
            case LineElementType.NORMAL:
                // canvasBehaviour.setMapBackground(true);
                break;
            case LineElementType.END:
                // canvasBehaviour.setEndBackgroundActive(true);
                break;
            case LineElementType.PENDING:
                // canvasBehaviour.setPendingBackgroundActive(true);
                break;
        }
    }

    public void SetLineElementActive(bool isActive, LineElementType type)
    {
        if(!isActive)
        {
            // canvasBehaviour.deactivateAll();
        } else
        {
            ChangeLineType(type);
        }
    }
}
