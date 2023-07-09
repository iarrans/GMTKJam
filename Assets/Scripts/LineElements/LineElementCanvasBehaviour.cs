using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineElementCanvasBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Image lobby;
    public Image danger;

    public Image normalPlayer;
    public Image speedrunnerPlayer;

    public Image endBackground;
    public Image pendingBackground;
    public Image mapBackground;
    public Image emptyBackground;


    public Slider timer;

    //Warnings
    public void SetLobbyActive(bool entry)
    {
        lobby.gameObject.SetActive(entry);
    }

    public void SetDangerActive(bool entry)
    {
        danger.gameObject.SetActive(entry);
    }


    //Players
    public void SetNormalPlayerActive(bool entry)
    {
        normalPlayer.gameObject.SetActive(entry);
    }

    public void SetSpeedRunnerPlayerActive(bool entry)
    {
        speedrunnerPlayer.gameObject.SetActive(entry);
    }

    public void SetTimerActive(bool entry)
    {
        timer.enabled = entry;
    }


    //Backgrounds
    public void SetMapBackgroundActive(bool entry)
    {
        mapBackground.gameObject.SetActive(entry);
    }

    public void SetEndBackgrounActive(bool entry)
    {
        endBackground.gameObject.SetActive(entry);
    }

    public void SetPendingBackgroundActive(bool entry)
    {
        pendingBackground.gameObject.SetActive(entry);
    }

    public void SetEmptyBackgroundActive(bool entry)
    {
       emptyBackground.gameObject.SetActive(entry);
    }


    //Slider indicating time
    public void ChangeTimerValue(float value) {
        timer.value = value;
    }

    //Slider indicating time
    public void DeactivateAll()
    {
        lobby.gameObject.SetActive(false);
        danger.gameObject.SetActive(false);
        normalPlayer.gameObject.SetActive(false);
        speedrunnerPlayer.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        mapBackground.gameObject.SetActive(false);
        endBackground.gameObject.SetActive(false);
        pendingBackground.gameObject.SetActive(false);
        emptyBackground.gameObject.SetActive(true);
    }

}
