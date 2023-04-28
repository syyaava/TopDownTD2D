using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public UpgradeMenu UpgradeMenu;

    private string towerTag = "Tower";
    private Tower selectedTower = null;

    private void Start()
    {
        if (UpgradeMenu == null)
            UpgradeMenu = GameObject.FindObjectOfType<UpgradeMenu>();

        UpgradeMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && BuildHelper.SelectedTowerPrefab == null)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var collider = Physics2D.OverlapPoint(mousePosition);
            if (collider != null && collider.tag == towerTag)
            {
                selectedTower = collider.gameObject.GetComponent<Tower>();
                var towerSprite = selectedTower.GetComponentInChildren<RotationController>().GetComponent<SpriteRenderer>().sprite;
                UpgradeMenu.gameObject.SetActive(true);
                int upgradeCost = selectedTower.TowerData.UpgradeCosts[selectedTower.TowerData.Level - 1].Count;
                UpgradeMenu.DisplayData(selectedTower.TowerData, upgradeCost, towerSprite);
            }
        }
    }

    public void UpgradeTower()
    {
        var upgradeCostResource = selectedTower.TowerData.UpgradeCosts[selectedTower.TowerData.Level - 1];
        if (PlayerResourceController.Instance.RemoveResources(upgradeCostResource))
        {
            TowerData newData = GetNewTowerStats();
            selectedTower.TowerData = newData;
            upgradeCostResource = selectedTower.TowerData.UpgradeCosts[selectedTower.TowerData.Level - 1];
            var towerSprite = selectedTower.GetComponentInChildren<RotationController>().GetComponent<SpriteRenderer>().sprite;
            UpgradeMenu.DisplayData(selectedTower.TowerData, upgradeCostResource.Count, towerSprite);
        }
    }

    private TowerData GetNewTowerStats()
    {
        var newData = new TowerData()
        {
            Level = selectedTower.TowerData.Level + 1,
            ReloadSecs = selectedTower.TowerData.ReloadSecs,
            ShootDistance = selectedTower.TowerData.ShootDistance,
            BulletPrefabs = selectedTower.TowerData.BulletPrefabs,
            Cost = selectedTower.TowerData.Cost,
            UpgradeCosts = selectedTower.TowerData.UpgradeCosts
        };        

        return newData;
    }
}
