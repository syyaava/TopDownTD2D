using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public TMP_Text TowerLevelText;
    public TMP_Text UpgradeTowerCostText;
    public Image TowerImage;
    public GameObject UpgradeButton;
    private TowerData displayedTowerData;

    private void OnDisable()
    {
        displayedTowerData = null;
        TowerLevelText.text = "0";
        UpgradeTowerCostText.text = "0";
    }

    public void DisplayData(TowerData data, int upgradeCost, Sprite towerSprite)
    {        
        displayedTowerData = data;
        TowerImage.sprite = towerSprite;
        TowerLevelText.text = displayedTowerData.Level.ToString();
        if(data.Level >= 4)
        {
            UpgradeButton.SetActive(false);
            UpgradeTowerCostText.text = "";
            return;
        }    
        else
        {
            UpgradeButton.SetActive(true);
            UpgradeTowerCostText.text = upgradeCost.ToString();
        }    
    }

    public void CloseTab()
    {
        gameObject.SetActive(false);
    }
}
