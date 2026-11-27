using UnityEngine;

// Jordan/Libby Script\\
public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float playerHealth;
    [SerializeField] GameObject deadUI;


    void IDamageable.TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0) DeathLogic();
    }

    void DeathLogic()
    {
        deadUI.SetActive(true);
    }
}
