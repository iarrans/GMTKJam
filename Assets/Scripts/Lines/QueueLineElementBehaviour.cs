using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueLineElementBehaviour : LineElementBehaviour
{
    public float limitTime;
    public float timer;
    public int position;

    private bool isPlayerHere;
    public void OnPlayerEnter(PlayerType playerType)
    {
        if (playerType == PlayerType.NORMAL) canvasBehaviour.SetNormalPlayerActive(true);
        if (playerType == PlayerType.SPEEDRUNNER) canvasBehaviour.SetSpeedRunnerPlayerActive(true);
        canvasBehaviour.SetTimerActive(true);
        timer = 0;
        limitTime = 5;
        isPlayerHere = true;
    }

    public void OnPlayerExit()
    {
        canvasBehaviour.SetNormalPlayerActive(false);
        canvasBehaviour.SetSpeedRunnerPlayerActive(false);
        canvasBehaviour.SetTimerActive(false);
        timer = 0;
        isPlayerHere = false;
    }

    private void Update()
    {
        if (!isPlayerHere) return;
        timer += Time.deltaTime;

        float timePercentage = timer / limitTime;
        if (timePercentage >= 1) lineBehaviour.OnElementTimerFinished(position);
        canvasBehaviour.ChangeTimerValue(timePercentage);
    }

    public void Copy(QueueLineElementBehaviour otherQueue)
    {
        canvasBehaviour.SetLobbyActive(otherQueue.canvasBehaviour.lobby);
        canvasBehaviour.SetDangerActive(otherQueue.canvasBehaviour.danger);
        canvasBehaviour.SetNormalPlayerActive(otherQueue.canvasBehaviour.normalPlayer);
        canvasBehaviour.SetSpeedRunnerPlayerActive(otherQueue.canvasBehaviour.speedrunnerPlayer);
        canvasBehaviour.SetTimerActive(otherQueue.canvasBehaviour.timer);
        canvasBehaviour.SetEndBackgrounActive(otherQueue.canvasBehaviour.endBackground);
        canvasBehaviour.SetMapBackgroundActive(otherQueue.canvasBehaviour.mapBackground);
        canvasBehaviour.SetPendingBackgroundActive(otherQueue.canvasBehaviour.pendingBackground);
        canvasBehaviour.ChangeTimerValue(otherQueue.canvasBehaviour.timer.value);

        timer = otherQueue.timer;
        limitTime = otherQueue.limitTime;
        isPlayerHere = otherQueue.isPlayerHere;
        currentType = otherQueue.currentType;
    }

    public void OnMapCompleted()
    {
        canvasBehaviour.DeactivateAll();
        canvasBehaviour.SetMapBackgroundActive(true);
        currentType = LineElementType.NORMAL;
    }
}
