﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRemoveBuildingState : PlayerState
{
    private BuildingManager buildingManager;

    public PlayerRemoveBuildingState(GameManager gameManager, BuildingManager buildingManager) : base(gameManager)
    {
        this.buildingManager = buildingManager;
    }

    public override void OnCancle()
    {
        this.gameManager.TransistionToState(this.gameManager.selectionState, null);
    }

    public override void OnInputPointerDown(Vector3 position)
    {
        this.buildingManager.RemoveBuildingAt(position);
    }
}
