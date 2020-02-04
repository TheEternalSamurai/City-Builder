using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager
{
    private GridStructure grid;
    private PlacementManager placementManager;

    public BuildingManager(int cellSize, int width, int length, PlacementManager placementManager)
    {
        this.grid = new GridStructure(cellSize, width, length);
        this.placementManager = placementManager;
    }

    public void PlaceStructureAt(Vector3 inputPosition)
    {
        Vector3 gridPosition = grid.CalculateGridPosition(inputPosition);
        if (!grid.IsCellTaken(gridPosition))
        {
            placementManager.CreateBuilding(gridPosition, grid);
        }
    }
}
