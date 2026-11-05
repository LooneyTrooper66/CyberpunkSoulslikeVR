using UnityEngine;
using UnityEngine.PlayerLoop;

public class DroneFollowLogic : MonoBehaviour
{
    [Header("Player Follow Variables")]
    [SerializeField] Transform player;
    float desiredDistanceFromPlayer;
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float minDesiredDist;
    [SerializeField] float maxDesiredDist;
    [Header("Obstacle Avoidance Variables")]
    [SerializeField] float obstacleCheckRadius;
    [SerializeField] float obstacleCheckDistance;
    [SerializeField] LayerMask obstacleAvoidanceMask;
    float hitDist;


    void Start()
    {
        desiredDistanceFromPlayer = Random.Range(minDesiredDist, maxDesiredDist);
    }

    void Update()
    {
        // will cause drone to follow player at a fixed distance while avoiding any obstacles 
        gameObject.transform.position = Vector3.MoveTowards(transform.position, FindDesiredDestination(), moveSpeed * Time.deltaTime);

        LookAtPlayer();
    }

    void FixedUpdate()
    {
        AvoidObstacles();
    }

    Vector3 FindDesiredDestination()
    {
        // find closest point to player around x unit circle, set as destination
        Vector3 dirToPlayer = Vector3.Normalize(player.transform.position - transform.position);
        float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        float distToTravel = distanceFromPlayer - desiredDistanceFromPlayer;
        Vector3 desiredDestination = transform.position + (dirToPlayer * distToTravel);

        return desiredDestination;
    }

    void AvoidObstacles()
    {
        

       // Vector3 dirToMoveIn = Vector3.Reflect(hit.point, hit.normal);
       // transform.position += dirToMoveIn.normalized;
    }

    void LookAtPlayer()
    {
        Quaternion goalRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, goalRotation, Time.deltaTime * turnSpeed);
    }
}
