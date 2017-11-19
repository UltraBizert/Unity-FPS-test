using UnityEngine;
using UnityEngine.UI;

public class HitEntity : MonoBehaviour
{
    public float MaxHealth;
    public Slider HPBar;
    public bool IsDied;

    protected float currentHealth;

    void Awake()
    {
        SetUp();
    }

    public virtual void OnHit(float dmg)
    {
        currentHealth -= dmg;

        if (HPBar)
            HPBar.value = currentHealth;

        if (currentHealth <= 0)
            OnDie();
    }

    public void SetUp()
    {
        IsDied = false;
        currentHealth = MaxHealth;
        if (HPBar)
        {
            HPBar.maxValue = MaxHealth;
            HPBar.value = currentHealth;
        }
    }

    protected virtual void OnDie()
    {
        IsDied = true;
    }
}
