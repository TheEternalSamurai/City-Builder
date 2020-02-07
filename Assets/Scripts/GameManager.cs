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
    public LayerMask inputMask;
    public int width, length;

    private BuildingManager buildingManager;
    private int cellSize = 3;

    private PlayerState state;

    public PlayerSelectionState selectionState;
    public PlayerBuildingSingleStructureState buildingSingleStructureState;
    public PlayerRemoveBuildingState demolishState;

    public PlayerState State { get => state; }

    private void Awake()
    {
        buildingManager = new BuildingManager(cellSize, width, length, placementManager);
        selectionState = new PlayerSelectionState(this, cameraMovement);
        buildingSingleStructureState = new PlayerBuildingSingleStructureState(this, buildingManager);
        demolishState = new PlayerRemoveBuildingState(this, buildingManager);
        state = selectionState;
#if (UNITY_EDITOR && TEST) || !(UNITY_IOS || UNITY_ANDROID)
        inputManager = gameObject.AddComponent<InputManager>();
#endif
#if (UNITY_IOS || UNITY_ANDROID)
        
#endif
    }

    private void Start()
    {
        PrepareGameComponents();
        AssignInputListeners();
        AssignUIControllerListeners();
    }

    private void PrepareGameComponents()
    {
        inputManager.MouseInputMask = inputMask;
        cameraMovement.SetCameraBounds(0, width, 0, length);
    }

    private void AssignUIControllerListeners()
    {
        uiController.AddListenerOnBuildAreaEvent(StartPlacementMode);
        uiController.AddListenerOnCancleActionEvent(CancleAction);
        uiController.AddListenerOnDemolishActionEvent(StartDemolishMode);
    }

    private void AssignInputListeners()
    {
        inputManager.AddListenerOnPointerDownEvent(HandleInput);
        inputManager.AddListenerOnPointerSecondChangeEvent(HandleInputCameraPan);
        inputManager.AddListenerOnPointerSecondUpEvent(HandleInputCameraPanStop);
        inputManager.AddListenerOnPointerChangeEvent(HandlePointerChange);
    }

    private void StartDemolishMode()
    {
        TransistionToState(demolishState, null);
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

    private void StartPlacementMode(string variable)
    {
        TransistionToState(buildingSingleStructureState, variable);
    }

    private void CancleAction()
    {
        state.OnCancle();
    }

    private void HandleInput(Vector3 position)
    {
        state.OnInputPointerDown(position);
    }

    public void TransistionToState(PlayerState newState, string variable)
    {
        this.state = newState;
        this.state.EnterState(variable);
    }
}
