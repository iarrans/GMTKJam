using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMatrixGenerator
{
    [Tooltip("Items for the randomizer to use")]
    public List<DungeonItem> dungeonItems;

    [Tooltip("Minimun of items to be placed in the dungeon")]
    public int minTotalItems;

    [Tooltip("Maximun of items to be placed in the dungeon")]
    public int maxTotalItems;

    public Matrix GenerateRandomMatrix(float totalItemsRatio, List<ItemType> activeItemTypes)
    {
        Matrix result = new Matrix();

        //transforms % of totalItemsRatio in a number which represent that ratio between minTotalItems and maxTotalItems
        //We will use this number to control how many items are created in the image.
        int numberOfObjects = (int)Mathf.Clamp(totalItemsRatio, minTotalItems, maxTotalItems);
        if (numberOfObjects < minTotalItems) { numberOfObjects = minTotalItems; }
        else if (numberOfObjects > maxTotalItems) { numberOfObjects = maxTotalItems; }

        //We generate randomly numberOfObjects amount of intems
        int objectsGenerated = 0;
        List<DungeonItem> newItems = new List<DungeonItem>();

        //Loop choosing what items to spawn
        while (objectsGenerated < numberOfObjects)
        {
            int itemListPosition = UnityEngine.Random.Range(0, dungeonItems.Count - 1);//the list is supossed to be already filtered
            DungeonItem itemTemplate = dungeonItems[itemListPosition];
            Debug.Log(itemTemplate.id + " will be spawned");
            newItems.Add(itemTemplate);
            objectsGenerated++;
        }

        //Loop choosing where to spam these chosen items
        foreach (DungeonItem itemToPlace in newItems)
        {
            int matrixSize = result.GetSize();
            int randomRow = UnityEngine.Random.Range(0, matrixSize - 1);
            int randomColumn = UnityEngine.Random.Range(0, matrixSize - 1);

        }

        return result;
    }
}
