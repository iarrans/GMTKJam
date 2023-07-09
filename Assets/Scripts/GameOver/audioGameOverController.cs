using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioGameOverController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip gameOverSong;
    private float timer;
    private bool hasStartedSong;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (!hasStartedSong && timer>5)
        {
            hasStartedSong = true;
            audioSource.clip = gameOverSong;
            audioSource.Play();
            audioSource.loop = true;
        }
    }

}
