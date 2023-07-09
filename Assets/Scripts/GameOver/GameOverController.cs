using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    public void Retry()
    {
        SceneManager.LoadScene("Test Scene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
