using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTowerButton : MonoBehaviour
{
    public Tower Tower;

    public void SelectTower()
    {
        BuildHelper.SelectedTowerPrefab = Tower;
    }
}
