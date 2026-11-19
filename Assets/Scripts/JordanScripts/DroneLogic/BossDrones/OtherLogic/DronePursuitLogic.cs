using UnityEngine;

// Jordan/Libby Script\\
public class DronePursuitLogic : MonoBehaviour
{
    [Header("Player Follow Variables")]
    [SerializeField] EnemyBase enemyBase;
    public Transform player;
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [Header("Obstacle Avoidance Variables")]
    [SerializeField] SphereCollider avoidRadius;


    void Update()
    {
        // follow player as long as not within attack distance
        Debug.Log(enemyBase.IsWithinAttackDist);
        if (!enemyBase.IsWithinAttackDist)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, player.position, moveSpeed * Time.deltaTime);
            Debug.Log("moving");
        }
        else Debug.Log("in attack zone");

        LookAtPlayer();
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 dirToCollision = Vector3.Normalize(other.gameObject.transform.position - transform.position);

        transform.position = Vector3.MoveTowards(gameObject.transform.position, (dirToCollision * -10), moveSpeed * Time.deltaTime);
        Debug.Log("avoiding");
    }

    void LookAtPlayer()
    {
        Quaternion goalRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, goalRotation, Time.deltaTime * turnSpeed);
    }
}
