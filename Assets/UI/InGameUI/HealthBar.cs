using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    public Damageble PlayerBase;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        if (PlayerBase == null) 
            PlayerBase = FindObjectOfType<PlayerBase>().GetComponent<Damageble>();

        PlayerBase.OnHealthChange.AddListener(SetHealth);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
