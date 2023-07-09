using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public GameObject blueprint;
    public Matrix<DungeonItem> data;

    public Map()
    {

    }

    public Map(GameObject blueprint, Matrix<DungeonItem> data)
    {
        this.blueprint = blueprint;
        this.data = data;
    }
}
