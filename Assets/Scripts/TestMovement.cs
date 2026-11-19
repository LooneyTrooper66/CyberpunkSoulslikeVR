using UnityEngine;

public class TestMovement : MonoBehaviour, IDamageable
{
    float hitCount;


    void IDamageable.TakeDamage(float damage)
    {
        hitCount += damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(10);
        }
    }
}
