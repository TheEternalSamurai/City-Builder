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

    private PlayerState state;

    public PlayerSelectionState selectionState;
    public PlayerBuildingSingleStructureState buildingSingleStructureState;

    public PlayerState State { get => state; }

    private void Awake()
    {
        grid = new GridStructure(cellSize, width, length);
        selectionState = new PlayerSelectionState(this, cameraMovement);
        buildingSingleStructureState = new PlayerBuildingSingleStructureState(this, placementManager, grid);
        state = selectionState;
    }
    
    void Start()
    {
        cameraMovement.SetCameraBounds(0, width, 0, length);
        inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();
        
        inputManager.AddListenerOnPointerDownEvent(HandleInput);
        inputManager.AddListenerOnPointerSecondChangeEvent(HandleInputCameraPan);
        inputManager.AddListenerOnPointerSecondUpEvent(HandleInputCameraPanStop);
        inputManager.AddListenerOnPointerChangeEvent(HandlePointerChange);
        uiController.AddListenerOnBuildAreaEvent(StartPlacementMode);
        uiController.AddListenerOnCancleActionEvent(CancleAction);
    }

    private void HandlePointerChange(Vector3 position)
    {
        state.OnInputPointerChange(position);
    }

    private void HandleInputCameraPanStop()
    {
        state.OnInputPanUp();
    }

    private void HandleInputCameraPan(Vector3 position)
    {
        state.OnInputPanChange(position);
    }

    private void StartPlacementMode()
    {
        TransistionToState(buildingSingleStructureState);
    }

    private void CancleAction()
    {
        state.OnCancle();
    }

    private void HandleInput(Vector3 position)
    {
        state.OnInputPointerDown(position);
    }

    public void TransistionToState(PlayerState newState)
    {
        this.state = newState;
        this.state.EnterState();
    }
}
