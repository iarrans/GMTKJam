using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintController : MonoBehaviour
{
    private Matrix<DungeonItem> data;
    private Matrix<GameObject> models;

    public Transform blueprint;
    public MapController mapController;

    // Start is called before the first frame update
    void Awake()
    {
        data = new();
        models = new();
    }

    /// <summary>
    /// Add an item to the blueprint
    /// </summary>
    /// <param name="item">Item to add</param>
    /// <param name="mapPosition">Position to create the GameObject</param>
    /// <param name="row">Row of the matrix</param>
    /// <param name="column">Column of the matrix</param>
    /// <returns></returns>
    public void AddDungeonItem(DungeonItem item, Vector3 mapPosition, int row, int column)
    {
        GameObject prevModel = models.Get(row, column);
        if(prevModel != null) DeleteGameObject(prevModel);
        data.Add(item, row, column);
        Debug.Log(data.ToString());
        GameObject model = Instantiate(item.prefab3DModel, mapPosition, blueprint.rotation);
        models.Add(model, row, column);
    }

    /// <summary>
    /// Delete an item in the blueprint
    /// </summary>
    /// <param name="row">Row of the matrix</param>
    /// <param name="column">Column of the matrix</param>
    public void DeleteDungeonItem(int row, int column)
    {
        data.Delete(row, column);
        GameObject model = models.Get(row, column);
        if(model != null)
        {
            models.Delete(row, column);
            DeleteGameObject(model);
        }
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
        Matrix<DungeonItem> activeMapData = mapController.activeData;
        List<Vector2> differences = data.GetNotEqualsPositions(activeMapData);

        if(differences.Count == 0)
        {
            Debug.Log("Correcto!");
        } else
        {
            Debug.Log("Cagaste mamawebaso >:(");
        }
    }

    public void ClearBlueprint()
    {
        data = new Matrix<DungeonItem>();

        models.ForEach(DeleteInForEach);
        models = new Matrix<GameObject>();
    }

    private void DeleteInForEach(GameObject model, int row, int column)
    {
        DeleteGameObject(model);
    }
}
