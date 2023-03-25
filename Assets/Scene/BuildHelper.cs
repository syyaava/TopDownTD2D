using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildHelper : MonoBehaviour //TODO: ѕеределать строительство, добавив расход ресурсов. ƒобавить возможность постройки нескольких башен.
{
    public Tilemap TowerBaseTilemap;
    public LayerMask TowerBaseLayerMask;
    public static Tower SelectedTowerPrefab;
    //TODO: сделать так чтбы можно было выбирать башню.
    private bool[,] cellsForBuild;
    [SerializeField]
    private Vector3 spawnOffset = new Vector3(0.5f, 0.5f);

    private void Start()
    {
        InitCanBuildArray();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
        {
            TryBuildTower();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            TryBuildTower();
            SelectedTowerPrefab = null;
        }
        if (Input.GetMouseButtonDown(1))
            SelectedTowerPrefab = null;
    }

    private void TryBuildTower()
    {
        if (SelectedTowerPrefab == null || GamePauseController.IsPause)
            return;

        var cellCoord = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var cellCoordInt = TowerBaseTilemap.WorldToCell(cellCoord);
        var bounds = TowerBaseTilemap.cellBounds;
        if (TowerBaseTilemap.cellBounds.Contains(cellCoordInt))
        {
            if (CanBuild(cellCoordInt - bounds.min))
            {
                BuildTowerIfCan(cellCoordInt, bounds);
            }
        }
    }

    private void BuildTowerIfCan(Vector3Int cellCoordInt, BoundsInt bounds)
    {
        if (PlayerResourceController.Instance.HaveResources(SelectedTowerPrefab.TowerData.Cost.ToArray()))
        {
            Instantiate(SelectedTowerPrefab, cellCoordInt + spawnOffset, Quaternion.identity);
            cellsForBuild[cellCoordInt.x - bounds.xMin, cellCoordInt.y - bounds.yMin] = false;
            PlayerResourceController.Instance.RemoveResources(SelectedTowerPrefab.TowerData.Cost.ToArray());
        }
    }

    private bool CanBuild(Vector3Int position)
    {
        return cellsForBuild[position.x, position.y];
    }

    private void InitCanBuildArray()
    {
        var tilemapBounds = TowerBaseTilemap.cellBounds;
        cellsForBuild = new bool[tilemapBounds.size.x, tilemapBounds.size.y];
        for (var x = 0; x < tilemapBounds.size.x; x++)
            for(var y = 0; y < tilemapBounds.size.y; y++)
            {
                if (TowerBaseTilemap.GetTile(new Vector3Int(x + tilemapBounds.xMin, y + tilemapBounds.yMin)) != null)
                    cellsForBuild[x, y] = true;
                else
                    cellsForBuild[x, y] = false;
            }
    }
}
