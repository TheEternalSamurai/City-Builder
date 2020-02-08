using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildingSingleStructureState : PlayerState
{
    private BuildingManager buildingManager;
    private string structureName;

    public PlayerBuildingSingleStructureState(GameManager gameManager, BuildingManager buildingManager) : base(gameManager)
    {
        this.buildingManager = buildingManager;
    }

    public override void OnInputPointerDown(Vector3 position)
    {
        this.buildingManager.PlaceStructureAt(position, structureName, StructureType.SingleStructure);
    }

    public override void OnCancle()
    {
        this.gameManager.TransistionToState(this.gameManager.selectionState, null);
    }

    public override void EnterState(string structureName)
    {
        this.structureName = structureName;
    }
}
