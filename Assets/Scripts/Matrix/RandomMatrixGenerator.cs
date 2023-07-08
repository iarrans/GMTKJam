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

    public Matrix GenerateRandomMatrix(float totalItemsRatio, List<ItemType> activeItemTypes)
    {
        Matrix result = new Matrix();

        //transforms % of totalItemsRatio in a number which represent that ratio between minTotalItems and maxTotalItems
        //We will use this number to control how many items are created in the image.
        int numberOfObjects = (int)Mathf.Lerp(minTotalItems, maxTotalItems, totalItemsRatio);
        if (numberOfObjects < minTotalItems) { numberOfObjects = minTotalItems; }
        else if (numberOfObjects > maxTotalItems) { numberOfObjects = maxTotalItems; }
        Debug.Log("Se van a crear " + numberOfObjects);

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

        //Loop choosing where to spawn these chosen items and adding them to the final randomized matrix
        int matrixSize = Matrix.SIZE;
        foreach (DungeonItem itemToPlace in newItems)
        {
            int randomRow = UnityEngine.Random.Range(0, matrixSize - 1);
            int randomColumn = UnityEngine.Random.Range(0, matrixSize - 1);
            Debug.Log("Position selected: ["+randomRow + "," + randomColumn +"]");
            //until the loop doesn't get a free position, it will keep generating random positions
            while (result.Get(randomRow, randomColumn) != null)
            {
                randomRow = UnityEngine.Random.Range(0, matrixSize - 1);
                randomColumn = UnityEngine.Random.Range(0, matrixSize - 1);
                Debug.Log("Position selected in loop: [" + randomRow + "," + randomColumn + "]");
            }
            result.Add(itemToPlace, randomRow, randomColumn);
            Debug.Log(itemToPlace.id + " Succesfully added");
        }

        return result;
    }
}
