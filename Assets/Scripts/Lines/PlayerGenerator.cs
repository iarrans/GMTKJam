using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    public List<LineBehaviour> lines;
    public float creationRate = 1.5f;

    private void Start()
    {
        InvokeRepeating(nameof(CreateNewPlayer), 1, creationRate);
    }

    public void CreateNewPlayer()
    {
        LineBehaviour firstEmptyLine = lines.Find(line => !line.isPlayerHere);
        if(firstEmptyLine == null) return;
        firstEmptyLine.OnActiveLine();
    }
}
