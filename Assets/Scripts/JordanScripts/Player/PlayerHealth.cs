using UnityEngine;

// Jordan/Libby Script\\
public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float playerHealth;


    void IDamageable.TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0) Debug.Log("dead");
    }
}
