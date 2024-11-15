using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A class for Grid-based calculations, conversions, and utilities.
/// </summary>
public class Grid : MonoBehaviour
{

    // --- UTILITIES FOR CELL-BASED CALCULATIONS
    public static int GetGridDistance(Vector3 start, Vector3 end)
    {
        return (int)(Mathf.Abs(start.x - end.x) + Mathf.Abs(start.z - end.z));
    }


    /// <summary> Returns the grid position of a target object. </summary>
    public static Vector3 GetGridPosition(Transform target)
    {
        return new Vector3((int)target.position.x, 0, (int)target.position.z);
    }

    /// <summary> Returns the grid position of a position. </summary>
    public static Vector3 GetGridPosition(Vector3 position)
    {
        return new Vector3((int)position.x, 0, (int)position.z);
    }

    /// <summary> Returns grids within a square radius </summary>
    public static List<Vector3> GetSquareGridArea(Vector3 origin, int areaSize)
    {
        List<Vector3> cells = new();
        for (int x = -areaSize; x <= areaSize; x++)
        {
            for (int z = -areaSize; z <= areaSize; z++)
            {
                cells.Add(new Vector3(origin.x + x, 0, origin.z + z));
            }
        }
        return cells;
    }

    /// <summary> Returns grids within a circular radius </summary>
    public static List<Vector3> GetCircularGridArea(Vector3 origin, int radius)
    {
        List<Vector3> cells = new();
        for (int x = -radius; x <= radius; x++)
        {
            for (int z = -radius; z <= radius; z++)
            {
                if (Mathf.Pow(x, 2) + Mathf.Pow(z, 2) <= Mathf.Pow(radius, 2))
                {
                    cells.Add(new Vector3(origin.x + x, 0, origin.z + z));
                }
            }
        }
        return cells;
    }

    /// <summary> Returns the closest grid position from a list of positions. </summary>
    public static Vector3 GetClosestGridPosition(Vector3 origin, List<Vector3> positions)
    {
        Vector3 closest = positions[0];
        foreach (Vector3 pos in positions)
        {
            if (GetGridDistance(origin, pos) < GetGridDistance(origin, closest))
            {
                closest = pos;
            }
        }
        return closest;
    }
}
