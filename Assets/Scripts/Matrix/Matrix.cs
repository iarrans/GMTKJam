using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
    public readonly static int SIZE = 5;

    private readonly DungeonItem[,] data; 

    public Matrix()
    {
        data = new DungeonItem[SIZE, SIZE];
    }

    /// <summary>
    /// Add an item to the indicated position.
    /// </summary>
    /// <param name="item">Item to add.</param>
    /// <param name="row">Row of the matrix.</param>
    /// <param name="column">Column of the matrix.</param>
    public void Add(DungeonItem item, int row, int column)
    {
        data[row, column] = item;
    }

    /// <summary>
    /// Delete an element of the matrix.
    /// </summary>
    /// <param name="row">Row of the matrix.</param>
    /// <param name="column">Row of the matrix.</param>
    public void Delete(int row, int column)
    {
        data[row, column] = null;
    }

    /// <summary>
    /// Get an element of the matrix. If it doesn't exist, null is returned.
    /// </summary>
    /// <param name="row">Row of the matrix.</param>
    /// <param name="column">Row of the matrix.</param>
    /// <returns></returns>
    public DungeonItem Get(int row, int column)
    {
        return data[row, column];
    }

    /// <summary>
    /// Compare two matrixes.
    /// </summary>
    /// <param name="matrix">Matrix to compare.</param>
    /// <returns></returns>
    public bool Equals(Matrix matrix)
    {
        for(int row = 0; row < SIZE; row++)
        {
            for (int column = 0; column < SIZE; column++)
            {
                if(matrix.Get(row, column) != data[row, column])
                {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary>
    /// Returns the number of rows/columns of the matrix
    /// </summary>
    /// <returns></returns>
}
