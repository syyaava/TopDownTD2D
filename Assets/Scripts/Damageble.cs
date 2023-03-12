using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageble : MonoBehaviour
{
    public int MaxHealth = 1;
    [SerializeField]
    private int health;
    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit;
    public UnityEvent OnHeal;

    
    public int Health
    {
        get { return health; } 
        set
        {
            health = value;
            OnHealthChange?.Invoke((Health * 1.0f) / MaxHealth);
        }
    }

    private void Start()
    {
        Health = MaxHealth;
    }

    public void Hit(int damagePoints)
    {
        Health -= damagePoints;
        if(Health <= 0) 
            OnDead?.Invoke();
        else
            OnHit?.Invoke();
    }

    public void Heal(int healthBoost)
    {
        Health += healthBoost;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        OnHeal?.Invoke();
    }
}
