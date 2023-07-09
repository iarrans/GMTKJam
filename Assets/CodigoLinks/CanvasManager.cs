using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject settingCanvas;
    public GameObject creditCanvas;
    public GameObject pauseCanvas;
    public GameObject tutoCanvas;

    public void settingCanvasTRUE()
    {
        settingCanvas.SetActive(true);
    }

    public void creditCanvasTRUE()
    {
        creditCanvas.SetActive(true);
    }

    public void pauseCanvasTRUE()
    {
        pauseCanvas.SetActive(true);
    }

    public void tutoCanvasTRUE()
    {
       tutoCanvas.SetActive(true);
    }

    public void menuCanvasTRUE()
    {
        menuCanvas.SetActive(true);
    }

    //------

    public void settingCanvasFALSE()
    {
        settingCanvas.SetActive(false);
    }

    public void creditCanvasFALSE()
    {
        creditCanvas.SetActive(false);
    }

    public void pauseCanvasFALSE()
    {
        pauseCanvas.SetActive(false);
    }

    public void tutoCanvasFALSE()
    {
        tutoCanvas.SetActive(false);
    }

    public void menuCanvasFALSE()
    {
        menuCanvas.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void WindowMode()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void cambioEscena()
    {
        SceneManager.LoadScene("intro");
    }

    

}
