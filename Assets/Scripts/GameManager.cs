using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlacementManager placementManager;
    public IInputManager inputManager;
    public UIController uiController;
    public int width, length;

    private GridStructure grid;
    private int cellSize = 3;
    private bool buildingModeActive = false;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();
        grid = new GridStructure(cellSize, width, length);
        inputManager.AddListenerOnPointerDownEvent(HandleInput);
        uiController.AddListenerOnBuildAreaEvent(StartPlacementMode);
        uiController.AddListenerOnCancleActionEvent(CancleAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartPlacementMode()
    {
        buildingModeActive = true;
    }

    private void CancleAction()
    {
        buildingModeActive = false;
    }

    private void HandleInput(Vector3 position)
    {
        Vector3 gridPosition = grid.CalculateGridPosition(position);
        if (buildingModeActive && !grid.IsCellTaken(gridPosition))
        {
            placementManager.CreateBuilding(gridPosition, grid);
        }
    }
}
