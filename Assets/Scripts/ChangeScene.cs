using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    float timer = 0f;

    public void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1f && Input.GetMouseButtonDown(0) && Input.anyKeyDown)
        {
            SceneManager.LoadScene("Test Scene");
        }
    }
}
