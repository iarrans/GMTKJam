using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintController : MonoBehaviour
{
    private Matrix data;

    public Transform blueprint;
    public MapController mapController;

    // Start is called before the first frame update
    void Awake()
    {
        data = new();
    }

    /// <summary>
    /// Add an item to the blueprint
    /// </summary>
    /// <param name="item">Item to add</param>
    /// <param name="prevItem">Previous item in the position. If not, null</param>
    /// <param name="mapPosition">Position to create the GameObject</param>
    /// <param name="row">Row of the matrix</param>
    /// <param name="column">Column of the matrix</param>
    /// <returns></returns>
    public GameObject AddDungeonItem(DungeonItem item, GameObject prevItem, Vector3 mapPosition, int row, int column)
    {
        if(prevItem != null) DeleteGameObject(prevItem);
        data.Add(item, row, column);
        Debug.Log(data.ToString());
        return Instantiate(item.prefab3DModel, mapPosition, blueprint.rotation);
    }

    /// <summary>
    /// Delete an item in the blueprint
    /// </summary>
    /// <param name="row">Row of the matrix</param>
    /// <param name="column">Column of the matrix</param>
    /// <param name="itemToDelete">GameObject to delete</param>
    public void DeleteDungeonItem(int row, int column, GameObject itemToDelete)
    {
        if (itemToDelete == null) return;
        data.Delete(row, column);
        Debug.Log(data.ToString());
        DeleteGameObject(itemToDelete);
    }

    private void DeleteGameObject(GameObject item)
    {
        Destroy(item);
    }

    /// <summary>
    /// Compare the blueprint with the active map
    /// </summary>
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
