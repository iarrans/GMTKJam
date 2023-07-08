using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapPrefab;
    public RandomMatrixGenerator randomMatrixGenerator;

    private void Start()
    {
        
        GenerateMap();
    }

    public Matrix GenerateMap()
    {
        Matrix matrix = randomMatrixGenerator.GenerateRandomMatrix(0.5f, new List<ItemType>() { ItemType.ARCHITECTURE, ItemType.ENEMY, ItemType.LOOT });
        GameObject map = Instantiate(mapPrefab);
        map.GetComponent<MapBehaviour>().LoadImagesByMatrix(matrix);
        return matrix;
    }
}
