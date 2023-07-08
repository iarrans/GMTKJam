using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerTest : MonoBehaviour
{
    public RandomMatrixGenerator generator;
    void Start()
    {
        List<ItemType> listatest = new List<ItemType>() { ItemType.ARCHITECTURE, ItemType.ENEMY };
        generator.GenerateRandomMatrix(0.4f, listatest);
    }

}
