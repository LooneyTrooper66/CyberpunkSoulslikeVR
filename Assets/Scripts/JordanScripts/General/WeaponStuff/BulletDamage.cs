using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] float damageDeals = 1;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(damageDeals);
        }
        gameObject.SetActive(false);
    }
}
