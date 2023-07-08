using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintController : MonoBehaviour
{
    private Matrix data;

    public MapController mapController;

    // Start is called before the first frame update
    void Awake()
    {
        data = new();
    }

    public GameObject AddDungeonItem(DungeonItem item, GameObject prevItem, Vector3 mapPosition, int row, int column)
    {
        if (prevItem != null) DeleteGameObject(prevItem);
        data.Add(item, row, column);
        return Instantiate(item.prefab3DModel, mapPosition, item.prefab3DModel.transform.rotation);
    }

    public void DeleteDungeonItem(int row, int column, GameObject gameObject)
    {
        data.Delete(row, column);
        DeleteGameObject(gameObject);
    }

    private void DeleteGameObject(GameObject item)
    {
        Destroy(item);
    }

    public void SendBlueprint()
    {
        Matrix activeMapData = mapController.activeData;
        List<Vector2> differences = data.GetNotEqualsPositions(activeMapData);
        if(differences.Count == 0)
        {
            Debug.Log("Correcto!");
        } else
        {
            Debug.Log("Cagaste mamawebaso >:(");
        }
    }
}
