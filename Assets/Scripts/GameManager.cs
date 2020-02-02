using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlacementManager placementManager;
    public InputManager inputManager;
    public int width, length;

    private GridStructure grid;
    private int cellSize = 3;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GridStructure(cellSize, width, length);
        inputManager.AddListenerOnPointerDownEvent(HandleInput);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleInput(Vector3 position)
    {
        Vector3 gridPosition = grid.CalculateGridPosition(position);
        if (!grid.IsCellTaken(gridPosition))
        {
            placementManager.CreateBuilding(gridPosition, grid);
        }
    }
}
