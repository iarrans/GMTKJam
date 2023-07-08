using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMatrixGenerator: MonoBehaviour
{
    [Tooltip("Items for the randomizer to use")]
    public List<DungeonItem> dungeonItems;

    [Tooltip("Minimun of items to be placed in the dungeon")]
    public int minTotalItems;

    [Tooltip("Maximun of items to be placed in the dungeon")]
    public int maxTotalItems;

    /// <summary>
    /// Generates an entire new random map Matrix with items
    /// </summary>
    /// <param name="totalItemsRatio">%of items to be spawned between the range. 0=minimun, 1=maximum</param>
    /// <param name="activeItemTypes">Lets the randomizer filter between objects class to be spawned</param>
    /// <returns></returns>
    public Matrix GenerateRandomMatrix(float totalItemsRatio, List<ItemType> activeItemTypes)
    {
        Matrix result = new Matrix();

        //transforms % of totalItemsRatio in a number which represent that ratio between minTotalItems and maxTotalItems
        //We will generate randomly numberOfObjects amount of intems
        int numberOfObjects = (int)Mathf.Lerp(minTotalItems, maxTotalItems, totalItemsRatio);
        if (numberOfObjects < minTotalItems) { numberOfObjects = minTotalItems; }
        else if (numberOfObjects > maxTotalItems) { numberOfObjects = maxTotalItems; }

        //We will filter the original DungeonItem list that will be iterated later
        List<DungeonItem> availableItems = new List<DungeonItem>();
        foreach (DungeonItem item in dungeonItems)
        {
            if (activeItemTypes.Contains(item.itemType))  availableItems.Add(item);
        }

        int objectsGenerated = 0;//serves to control amount of objects selected in loop
        List<DungeonItem> newItems = new List<DungeonItem>();
        //Loop choosing what items to spawn
        while (objectsGenerated < numberOfObjects)
        {
            int itemListPosition = UnityEngine.Random.Range(0, availableItems.Count - 1);//use the new filtered list
            DungeonItem itemTemplate = availableItems[itemListPosition];
            newItems.Add(itemTemplate);
            objectsGenerated++;
        }

        //Loop choosing where to spawn these chosen items and adding them to the final randomized matrix
        int matrixSize = Matrix.SIZE;
        foreach (DungeonItem itemToPlace in newItems)
        {
            int randomRow = UnityEngine.Random.Range(0, matrixSize);
            int randomColumn = UnityEngine.Random.Range(0, matrixSize);
            //until the loop doesn't get a free position, it will keep generating random positions
            while (result.Get(randomRow, randomColumn) != null)
            {
                randomRow = UnityEngine.Random.Range(0, matrixSize);
                randomColumn = UnityEngine.Random.Range(0, matrixSize);
            }
            result.Add(itemToPlace, randomRow, randomColumn);
        }

        return result;
    }
}
