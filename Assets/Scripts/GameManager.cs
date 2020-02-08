using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlacementManager placementManager;
    public StructureRepository structureRepository;
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
    public PlayerBuildingZoneState buildingAreaState;
    public PlayerBuildingRoadState buildingRoadState;

    public PlayerState State { get => state; }

    private void Awake()
    {
        PrepareStates();

#if (UNITY_EDITOR && TEST) || !(UNITY_IOS || UNITY_ANDROID)
        inputManager = gameObject.AddComponent<InputManager>();
#endif
#if (UNITY_IOS || UNITY_ANDROID)
        
#endif
    }

    private void PrepareStates()
    {
        buildingManager = new BuildingManager(cellSize, width, length, placementManager, structureRepository);
        selectionState = new PlayerSelectionState(this, cameraMovement);
        buildingSingleStructureState = new PlayerBuildingSingleStructureState(this, buildingManager);
        buildingAreaState = new PlayerBuildingZoneState(this, buildingManager);
        buildingRoadState = new PlayerBuildingRoadState(this, buildingManager);
        demolishState = new PlayerRemoveBuildingState(this, buildingManager);
        state = selectionState;
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
        uiController.AddListenerOnBuildAreaEvent((structureName) => state.OnBuildArea(structureName));
        uiController.AddListenerOnBuildSingleStructure((structureName) => state.OnBuildSingleStructure(structureName));
        uiController.AddListenerOnBuildRoad((structureName) =>  state.OnBuildRoad(structureName));
        uiController.AddListenerOnCancleActionEvent(() => state.OnCancle());
        uiController.AddListenerOnDemolishActionEvent(() => state.OnDemolishAction());
    }

    private void AssignInputListeners()
    {
        inputManager.AddListenerOnPointerDownEvent((position) => state.OnInputPointerDown(position));
        inputManager.AddListenerOnPointerSecondChangeEvent((position) => state.OnInputPanChange(position));
        inputManager.AddListenerOnPointerSecondUpEvent(() => state.OnInputPanUp());
        inputManager.AddListenerOnPointerChangeEvent((position) => state.OnInputPointerChange(position));
    }

    public void TransistionToState(PlayerState newState, string variable)
    {
        this.state = newState;
        this.state.EnterState(variable);
    }
}
