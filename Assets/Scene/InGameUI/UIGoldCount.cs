using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIGoldCount : MonoBehaviour
{
    public TMP_Text GoldCountText;
    private Resource playerGold;

    // Update is called once per frame
    void Update()
    {
        if (GoldCountText == null) return;
        if(playerGold == null) 
            playerGold = PlayerResourceController.Instance.Resources.FirstOrDefault(x => x.Type == Resource.ResourceType.Gold);

        UIDisplayGoldCount();
    }

    private void UIDisplayGoldCount()
    {
        GoldCountText.text = playerGold.Count.ToString();
    }
}
