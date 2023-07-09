using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    public List<LineBehaviour> lines;
    public float initialSpawnDelay = 0.5f;
    public Vector2 creationRateLimits;
    public Vector2 playerLimitTime;

    private void Start()
    {

        StartCoroutine(RepeatSpawnPlayer());
    }
    IEnumerator RepeatSpawnPlayer()
    {
        yield return new WaitForSeconds(initialSpawnDelay);
        while (true)
        {
            float limitTime = Random.Range(playerLimitTime.x, playerLimitTime.y);
            CreateNewPlayer(limitTime);
            float waitForSpawn = Random.Range(creationRateLimits.x, creationRateLimits.y);
            yield return new WaitForSeconds(waitForSpawn);
        }
    }

    public void CreateNewPlayer(float limitTime)
    {
        LineBehaviour firstEmptyLine = lines.Find(line => !line.isPlayerHere);
        if(firstEmptyLine == null) return;
        firstEmptyLine.OnActiveLine(limitTime);
    }
}
