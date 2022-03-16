using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    [SerializeField]
    private Transform gameBoard;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private GameObject cellPrefab;
    [SerializeField]
    private float interwal = 1.0f;

    private GameObject[,] grid;
    private int width = 50;
    private int height = 50;
    private Vector3 cameraOffset = new Vector3(0, 0, -35);
    private Vector2 cellOffset = new Vector3(0.5f, 0.5f);
    private bool gamePaused = false;

    private void Awake()
    {
        CreateGrid();
        SetParentAndCameraPosition();
    }

    private void Start()
    {
        RandomiseGrid();
    }

    private void RandomiseGrid()
    {
        System.Random r = new System.Random();
        List<Vector2> toChangeState = new List<Vector2>();

        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                if(r.Next(1, 5) == 1) //25% chance to create a living cell
                {
                    toChangeState.Add(new Vector2(x, y));
                }
            }
        }

        ChangeStates(toChangeState);
    }

    private void CreateGrid()
    {
        grid = new GameObject[width, height];
    }

    private void SetParentAndCameraPosition()
    {
        gameBoard.position = new Vector3(width / 2, height / 2, 0);
        mainCamera.transform.position = gameBoard.position + cameraOffset;
    }

    private void Update()
    {
        if(!gamePaused)
        {
            CheckForChangeState();
        }
    }

    private void CheckForChangeState()
    {
        List<Vector2> toChangeState = new List<Vector2>();
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                int neighbourCount = CountNeighbours(i, j);
                if((neighbourCount < 2 || neighbourCount > 3) && grid[i, j] != null)
                {
                    toChangeState.Add(new Vector2(i, j));
                }
                else if(neighbourCount == 3 && grid[i,j] == null)
                {
                    toChangeState.Add(new Vector2(i, j));
                }
            }
        }

        ChangeStates(toChangeState);
    }

    private int CountNeighbours(int x, int y)
    {
        int neighbours = 0;
        int minX = x > 0 ? -1 : 0;
        int maxX = x < width ? -1 : 0;
        int minY = y > 0 ? -1 : 0;
        int maxY = y < height ? -1 : 0;

        for(int i = minX; i <= maxX; i++)
        {
            for(int j = minY; j <= maxY; j++)
            {
                if(i == 0 && j == 0)
                {
                    continue; //this would count the active cell
                }

                if (grid[x + i, y + j] != null)
                {
                    neighbours++;
                }
            }
        }

        return neighbours;
    }

    private void ChangeStates(List<Vector2> cellsToChange)
    {
        foreach(Vector2 cell in cellsToChange)
        {
            if(grid[(int)cell.x, (int)cell.y] != null)
            {
                grid[(int)cell.x, (int)cell.y] = null;
            }
            else
            {
                GameObject newCell = Instantiate(cellPrefab);
                newCell.transform.SetParent(gameBoard);
                newCell.transform.position = cell + cellOffset;
                grid[(int)cell.x, (int)cell.y] = newCell;
            }
        }
    }
}
