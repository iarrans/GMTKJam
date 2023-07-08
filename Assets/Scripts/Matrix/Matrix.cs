using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Matrix<T>
{
    public readonly static int SIZE = 5;

    private readonly T[,] data; 

    public Matrix()
    {
        data = new T[SIZE, SIZE];
    }

    /// <summary>
    /// Add an item to the indicated position.
    /// </summary>
    /// <param name="item">Item to add.</param>
    /// <param name="row">Row of the matrix.</param>
    /// <param name="column">Column of the matrix.</param>
    public void Add(T item, int row, int column)
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
        data[row, column] = default(T);
    }

    /// <summary>
    /// Get an element of the matrix. If it doesn't exist, null is returned.
    /// </summary>
    /// <param name="row">Row of the matrix.</param>
    /// <param name="column">Row of the matrix.</param>
    /// <returns></returns>
    public T Get(int row, int column)
    {
        return data[row, column];
    }

    /// <summary>
    /// Compare two matrixes.
    /// </summary>
    /// <param name="matrix">Matrix to compare.</param>
    /// <returns></returns>
    public bool Equals(Matrix<T> matrix)
    {
        for(int row = 0; row < SIZE; row++)
        {
            for (int column = 0; column < SIZE; column++)
            {
                if(matrix.Get(row, column).Equals(data[row, column]))
                {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary>
    /// Get the positions of the elements that are not equal in matrix
    /// </summary>
    /// <param name="matrix">Matrix to compare</param>
    /// <returns></returns>
    public List<Vector2> GetNotEqualsPositions(Matrix<T> matrix)
    {
        List<Vector2> differences = new();
        for (int row = 0; row < SIZE; row++)
        {
            for (int column = 0; column < SIZE; column++)
            {
                if (matrix.Get(row, column).Equals(data[row, column]))
                {
                    differences.Add(new(row, column));
                }
            }
        }
        return differences;
    }

    /// <summary>
    /// Call a function for every item in data.
    /// </summary>
    /// <param name="action">Function to call</param>
    public void ForEach(Action<T, int, int> action)
    {
        for (int row = 0; row < SIZE; row++)
        {
            for (int column = 0; column < SIZE; column++)
            {
                T item = data[row, column];
                if (item != null)
                {
                    action(item, row, column);
                }
            }
        }
    }

    public override string ToString()
    {
        string s = "";
        for (int row = 0; row < SIZE; row++)
        {
            s += "[";
            for (int column = 0; column < SIZE; column++)
            {
                T item = data[row, column];
                if (item != null)
                {
                    s += item.ToString();
                } else
                {
                    s += "null";
                }

                if(column + 1 < SIZE)
                {
                    s += ", ";
                }
            }
            s += "]\n";
        }

        return s;
    }
}
