using UnityEngine;

// Jordan/Libby Script\\
public class DroneProjectileBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 10;
    [SerializeField] float damageDeals = 1;
    [SerializeField] float lifetime = 4;
    float timer = 0;


    private void OnEnable()
    {
        rb.linearVelocity = Vector3.zero;
        timer = 0;
    }

    void Update()
    {
        rb.linearVelocity = transform.forward * speed;

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
