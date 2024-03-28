using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent OnDeath;
    public int maxHealth = 1;
    public int currentHealth;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("ded, not big soup rice.");
        OnDeath.Invoke();
    }
}
