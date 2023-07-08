using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapPrefab;
    public RandomMatrixGenerator randomMatrixGenerator;

    public Texture2D cursor;

    private void Start()
    {
        Matrix matrix = randomMatrixGenerator.GenerateRandomMatrix(0.5f, new List<ItemType>() { ItemType.ARCHITECTURE, ItemType.ENEMY, ItemType.LOOT });
        GenerateMap(matrix);
    }

    private void GenerateMap(Matrix matrix)
    {
        GameObject map = Instantiate(mapPrefab);
        map.GetComponent<MapBehaviour>().LoadImagesByMatrix(matrix);
    }

    private void Update()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }
}
