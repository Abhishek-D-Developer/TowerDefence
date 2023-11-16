using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator
{
    private int width, height;
    [SerializeField] List<Vector2Int> pathCells;

    public PathGenerator(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public List<Vector2Int> GeneratePath()
    {
        pathCells = new List<Vector2Int>();

        int y = (int)(height / 2);

        for (int x = 0; x < width; x++)
        {
            pathCells.Add(new Vector2Int(x, y));
        }

        return pathCells;
    }
}
