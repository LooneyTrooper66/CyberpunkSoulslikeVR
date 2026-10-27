using UnityEngine;

public class DroneProjectileBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float damageDeals = 1;
    [SerializeField] float lifetime = 6;
    float timer = 0;


    private void OnEnable()
    {
        rb.linearVelocity = Vector3.zero;
    }

    void Update()
    {
        rb.linearVelocity = transform.forward * 10;

        timer += Time.deltaTime;
        if (timer >= lifetime) gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(damageDeals);
        }
        gameObject.SetActive(false);
    }
}
