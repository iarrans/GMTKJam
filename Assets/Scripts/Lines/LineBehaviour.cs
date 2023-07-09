using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehaviour : MonoBehaviour
{

    public List<QueueLineElementBehaviour> lineElements;
    public TopLineElementBehaviour topElement;
    public MapController mapController;
    public bool isPlayerHere = false;
    public int counter = 0;

    public void OnMapCompleted()
    {
        lineElements[2].Copy(lineElements[1]);
        lineElements[1].Copy(lineElements[0]);
        lineElements[0].OnMapCompleted();
        counter++;
        if (counter < 2)
        {
            topElement.map = mapController.mapGenerator.GenerateMap();
            mapController.ChangeMap(topElement.map, this);
        }
        else
        {
            Debug.Log("COUNTER FINISHED!");
            topElement.map = null;
            topElement.ChangeLineType(LineElementType.END);
            mapController.ChangeMap(null, null);
        }
    }

    public void OnElementTimerFinished(int position)
    {
        if (position == 0)
        {
            if (topElement.canvasBehaviour.endBackground.gameObject.activeSelf)
            {
                OnDeactivateLine();
            }
            else
            {
                Debug.Log("Game Over");
            }       
        }
        else
        {
            lineElements[position].OnPlayerExit();
            lineElements[position - 1].OnPlayerEnter(PlayerType.NORMAL);
        }       
    }

    public void OnActiveLine(float limitTime)
    {
        isPlayerHere = true;
        lineElements.ForEach(line => line.limitTime = limitTime);
        lineElements[0].OnPlayerEnter(PlayerType.NORMAL);
        lineElements[0].ChangeLineType(LineElementType.LOBBY);
        topElement.ChangeLineType(LineElementType.PENDING);
        topElement.map = mapController.mapGenerator.GenerateMap();
        counter = 0;
    }

    public void OnDeactivateLine()
    {
        isPlayerHere = false;
        lineElements[0].OnPlayerExit();
        lineElements.ForEach(line => line.canvasBehaviour.DeactivateAll());
        topElement.ChangeLineType(LineElementType.TURN_OFF);
    }

}
