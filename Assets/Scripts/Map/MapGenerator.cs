using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapPrefab;
    public RandomMatrixGenerator randomMatrixGenerator;

    public RectTransform mapCanvas;

    public Map GenerateMap()
    {
        Debug.Log("GENERATING MAP");
        Matrix<DungeonItem> matrix = randomMatrixGenerator.GenerateRandomMatrix(0.5f, new List<ItemType>() { ItemType.ARCHITECTURE, ItemType.ENEMY, ItemType.LOOT });
        GameObject blueprint = Instantiate(mapPrefab, mapCanvas.transform);
        blueprint.GetComponentInChildren<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, mapCanvas.sizeDelta.x);
        blueprint.GetComponentInChildren<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, mapCanvas.sizeDelta.y);
        blueprint.GetComponent<MapBehaviour>().LoadImagesByMatrix(matrix);

        Map result = new Map(blueprint, matrix);
        return result;
    }
}
