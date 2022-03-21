using UnityEngine;

public abstract class Shape_Base
{
    protected int width;
    protected int height;
    protected bool[,] grid;

    public Shape_Base()
    {
        InitializeShape();
        SetLivingSpaces();
    }

    public Vector2Int GetDimensions()
    {
        return new Vector2Int(width, height);
    }

    public virtual bool[,] InitializeShape()
    {
        grid = new bool[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                grid[i, j] = false; //default all elements to false
            }
        }

        return grid;
    }

    public abstract void SetLivingSpaces();

    public bool[,] GetGrid()
    {
        return grid;
    }
}

public enum BlockType
{
    Block, Tub, Blinker, Glider, Beehive, Toad, Loaf, Boat, Beacon, Pulsar, Pentadecathlon, LWSS, MWSS, HWSS
}