using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapPrefab;
    public RandomMatrixGenerator randomMatrixGenerator;

    public RectTransform mapCanvas;

    public Matrix GenerateMap()
    {
        Debug.Log("GENERATING MAP");
        Matrix matrix = randomMatrixGenerator.GenerateRandomMatrix(0.5f, new List<ItemType>() { ItemType.ARCHITECTURE, ItemType.ENEMY, ItemType.LOOT });
        GameObject map = Instantiate(mapPrefab, mapCanvas.transform);
        map.GetComponentInChildren<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, mapCanvas.sizeDelta.x);
        map.GetComponentInChildren<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, mapCanvas.sizeDelta.y);
        map.GetComponent<MapBehaviour>().LoadImagesByMatrix(matrix);
        return matrix;
    }
}
