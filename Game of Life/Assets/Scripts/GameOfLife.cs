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
    private float interval = 1.0f;

    private GameObject[,] grid;
    private int width = 50;
    private int height = 50;
    private Vector3 cameraOffset = new Vector3(0, 0, -35);
    private Vector2 cellOffset = new Vector2(0.5f, 0.5f);
    private bool gamePaused = false;
    private float nextStepTime;

    private void Awake()
    {
        CreateGrid();
        SetParentAndCameraPosition();
    }

    private void Start()
    {
        RandomiseGrid();
        nextStepTime = Time.time + interval;
    }

    private void Update()
    {
        if(gamePaused)
        {
            nextStepTime += Time.deltaTime;
        }

        if (!gamePaused && Time.time >= nextStepTime)
        {
            CheckForChangeState();
            nextStepTime = Time.time + interval;
        }
    }

    private void RandomiseGrid()
    {
        System.Random r = new System.Random();
        List<Vector2Int> changeState = new List<Vector2Int>();

        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                if(r.Next(1, 5) == 1) //25% chance to create a living cell
                {
                    changeState.Add(new Vector2Int(x, y));
                }
            }
        }

        ChangeStates(changeState);
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

    private void CheckForChangeState()
    {
        List<Vector2Int> toChangeState = new List<Vector2Int>();
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int neighbourCount = CountNeighbours(i, j);
                if ((neighbourCount < 2 || neighbourCount > 3) && grid[i, j] != null)
                {
                    toChangeState.Add(new Vector2Int(i, j));
                }
                else if (neighbourCount == 3 && grid[i, j] == null)
                {
                    toChangeState.Add(new Vector2Int(i, j));
                }
            }
        }

        ChangeStates(toChangeState);
    }

    private int CountNeighbours(int x, int y)
    {
        int neighbours = 0;
        int minX = x > 0 ? -1 : 0;
        int maxX = x < width - 1 ? 1 : 0;
        int minY = y > 0 ? -1 : 0;
        int maxY = y < height - 1 ? 1 : 0;

        for (int i = minX; i <= maxX; i++)
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

    private void ChangeStates(List<Vector2Int> cellsToChange)
    {
        if(cellsToChange.Count == 0)
        {
            return;
        }

        foreach (Vector2Int cell in cellsToChange)
        {
            if (grid[cell.x, cell.y] != null)
            {
                GameObject.Destroy(grid[cell.x, cell.y]);
            }
            else
            {
                GameObject newCell = Instantiate(cellPrefab);
                newCell.transform.SetParent(gameBoard);
                newCell.transform.position = cell + cellOffset;
                grid[cell.x, cell.y] = newCell;
            }
        }
    }

    private void ClearGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if(grid[i, j] != null)
                {
                    GameObject.Destroy(grid[i, j]);
                }
            }
        }
    }

    private bool ValidateDimensions(int width, int height)
    {
        if(width <= 0 || height <= 0 || width > 200 || height > 200)
        {
            return false;
        }
        return true;
    }

    public bool TogglePause()
    {
        gamePaused = !gamePaused;

        return gamePaused;
    }

    public void Reset()
    {
        ClearGrid();
        RandomiseGrid();
        nextStepTime = Time.time + interval;
    }

    public void Clear()
    {
        ClearGrid();
    }

    public void ChangeDimensions(int newWidth, int newHeight)
    {
        if(!ValidateDimensions(newWidth, newHeight))
        {
            Debug.Log("Dimensions must be between 1 and 200!");
            return;
        }

        ClearGrid();
        width = newWidth;
        height = newHeight;
        CreateGrid();
        SetParentAndCameraPosition();
        RandomiseGrid();
    }
}
