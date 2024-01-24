using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public DeathEvent DeathEvent;

    public int MaxHealth;
    public int CurrentHealth;
    public int CriticalDamage;
    public int Damage;

    public void OnHit(bool critical=false)
    {
        Debug.Log($"{name} Nice {(critical ? "Critical" : "")} Hit!");

        CurrentHealth = Mathf.Max(0, CurrentHealth - (critical ? CriticalDamage : Damage));
    
        if (CurrentHealth == 0 && DeathEvent != null)
        {
            DeathEvent.RaiseEvent();

            Destroy(gameObject);
        }
    }

    public void OnEnable()
    {
        CurrentHealth = MaxHealth;
    }
}
