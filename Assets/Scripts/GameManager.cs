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
    public CameraMovement cameraMovement;
    public int width, length;

    private GridStructure grid;
    private int cellSize = 3;
    private bool buildingModeActive = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovement.SetCameraBounds(0, width, 0, length);
        inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();
        grid = new GridStructure(cellSize, width, length);
        inputManager.AddListenerOnPointerDownEvent(HandleInput);
        inputManager.AddListenerOnPointerSecondChangeEvent(HandleInputCameraPan);
        inputManager.AddListenerOnPointerSecondUpEvent(HandleInputCameraPanStop);
        inputManager.AddListenerOnPointerChangeEvent(HandlePointerChange);
        uiController.AddListenerOnBuildAreaEvent(StartPlacementMode);
        uiController.AddListenerOnCancleActionEvent(CancleAction);
    }

    private void HandlePointerChange(Vector3 position)
    {
        Debug.Log(position);
    }

    private void HandleInputCameraPanStop()
    {
        cameraMovement.StopCameraMovement();
    }

    private void HandleInputCameraPan(Vector3 position)
    {
        if (!buildingModeActive)
        {
            cameraMovement.MoveCamera(position);
        }
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
