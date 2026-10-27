using UnityEngine;

public class TestMovement : MonoBehaviour, IDamageable
{
    float hitCount;


    void IDamageable.TakeDamage(float damage)
    {
        hitCount += damage;
    }
}
