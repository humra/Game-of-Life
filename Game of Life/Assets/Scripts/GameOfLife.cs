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

    private GameObject[,] grid;
    private int width = 50;
    private int height = 50;
    private Vector3 cameraOffset = new Vector3(0, 0, 25);
    private Vector3 cellOffset = new Vector3(0.5f, 0.5f);

    private void Awake()
    {
        CreateGrid();
        SetParentAndCameraPosition();
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
}
