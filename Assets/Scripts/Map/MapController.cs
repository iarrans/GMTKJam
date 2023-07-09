using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public Map activeData;
    public MapGenerator mapGenerator;

    // Start is called before the first frame update
    void Start()
    {
        activeData = mapGenerator.GenerateMap();
    }
}
