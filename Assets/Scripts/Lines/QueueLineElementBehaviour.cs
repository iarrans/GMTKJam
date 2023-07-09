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
        canvasBehaviour.SetLobbyActive(otherQueue.canvasBehaviour.lobby.gameObject.activeSelf);
        canvasBehaviour.SetDangerActive(otherQueue.canvasBehaviour.danger.gameObject.activeSelf);
        canvasBehaviour.SetNormalPlayerActive(otherQueue.canvasBehaviour.normalPlayer.gameObject.activeSelf);
        canvasBehaviour.SetSpeedRunnerPlayerActive(otherQueue.canvasBehaviour.speedrunnerPlayer.gameObject.activeSelf);
        canvasBehaviour.SetTimerActive(otherQueue.canvasBehaviour.timer.gameObject.activeSelf);
        canvasBehaviour.SetEndBackgrounActive(otherQueue.canvasBehaviour.endBackground.gameObject.activeSelf);
        canvasBehaviour.SetMapBackgroundActive(otherQueue.canvasBehaviour.mapBackground.gameObject.activeSelf);
        canvasBehaviour.SetPendingBackgroundActive(otherQueue.canvasBehaviour.pendingBackground.gameObject.activeSelf);
        canvasBehaviour.SetEmptyBackgroundActive(otherQueue.canvasBehaviour.emptyBackground.gameObject.activeSelf);
        canvasBehaviour.ChangeTimerValue(otherQueue.canvasBehaviour.timer.value);

        timer = otherQueue.timer;
        limitTime = otherQueue.limitTime;
        isPlayerHere = otherQueue.isPlayerHere;
        currentType = otherQueue.currentType;
    }

    public void OnMapCompleted()
    {
        canvasBehaviour.DeactivateAll();
        canvasBehaviour.SetEmptyBackgroundActive(false);
        canvasBehaviour.SetMapBackgroundActive(true);
        currentType = LineElementType.NORMAL;
        OnPlayerExit();
    }
}
