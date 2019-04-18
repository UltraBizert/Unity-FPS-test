using System;
using UnityEngine;
using UnityEngine.UI;

public class HitEntity : MonoBehaviour
{
    public float MaxHealth;
    public Slider HPBar;
    public bool IsDied;
    public Action OnDie;

    private float currentHealth;

    public void OnHit(float dmg)
    {
        Debug.Log($"{name} : {dmg}");

        currentHealth -= dmg;

        if (HPBar)
            HPBar.value = currentHealth;

        if (currentHealth <= 0)
            Die();
    }

    protected void SetUpHealth(float maxHealth = 0)
    {
        MaxHealth = maxHealth == 0 ? MaxHealth : maxHealth;

        IsDied = false;
        currentHealth = MaxHealth;

        if (!HPBar) return;

        HPBar.maxValue = MaxHealth;
        HPBar.value = currentHealth;
    }

    protected virtual void Die()
    {
        Debug.Log($"{name} die");

        IsDied = true;
        gameObject.SetActive(false);
        OnDie?.Invoke();
    }
}
