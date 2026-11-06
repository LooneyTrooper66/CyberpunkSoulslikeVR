using System.Runtime.CompilerServices;
using UnityEngine;

public class DroneFollowLogic : MonoBehaviour
{
    [Header("Player Follow Variables")]
    [SerializeField] Transform player;
    float desiredDistanceFromPlayer;
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float minDesiredDist;
    [SerializeField] float maxDesiredDist;
    [SerializeField] float thisHeight;
    [Header("Obstacle Avoidance Variables")]
    [SerializeField] int numOfRaycasts;
    [SerializeField] float rayAngle;
    [SerializeField] float rayLength;
    [SerializeField] LayerMask obstacleAvoidanceMask;
    bool obstacleDetected;


    void Start()
    {
        desiredDistanceFromPlayer = Random.Range(minDesiredDist, maxDesiredDist);
        obstacleDetected = false;
    }

    void Update()
    {
        // will cause drone to follow player at a fixed distance while avoiding any obstacles 
        ObstacleAvoidanceMovement();

        LookAtPlayer();
    }

    void FixedUpdate()
    {
        //AvoidObstacles();
    }

    void ObstacleAvoidanceMovement()
    {
        DetectObstacles();
        if (!obstacleDetected)
        {
            transform.position = Vector3.MoveTowards(transform.position, FindDesiredDestination(), moveSpeed * Time.deltaTime);
        }
    }

    Vector3 FindDesiredDestination()
    {
        // find closest point to player around x unit circle, set as destination
        Vector3 dirToPlayer = Vector3.Normalize(player.transform.position - transform.position);
        float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        float distToTravel = distanceFromPlayer - desiredDistanceFromPlayer;
        Vector3 desiredDestination = transform.position + (dirToPlayer * distToTravel);
        desiredDestination = new Vector3(desiredDestination.x, thisHeight, desiredDestination.z);

        return desiredDestination;
    }

    void DetectObstacles()
    {
        bool hitSomething = false;
        Vector3 dirToMove = Vector3.zero;
        for (int i = 0; i < numOfRaycasts; i++)
        {
            Quaternion rot = transform.rotation;
            Quaternion rotMod = Quaternion.AngleAxis(i / ((float)numOfRaycasts - 1) * rayAngle, Vector3.up);
            Vector3 dir = rot * rotMod * Vector3.forward;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit,  rayLength, obstacleAvoidanceMask))
            {
                hitSomething = true;

                // this logic DOES cause the enemy to get stuck when the player is directly in front of it
                // on the opposite side of a wall, but that should never happen in the gameplay so I'm leaving it for now
                // as I have sunk far too much time into this already and need to move on.
                dirToMove -= (1 / numOfRaycasts) * moveSpeed * dir;
                dirToMove = new Vector3(dirToMove.x, thisHeight, dirToMove.z);
                Debug.DrawRay(transform.position, dirToMove, Color.green, 5);

                transform.position = Vector3.MoveTowards(transform.position, dirToMove, moveSpeed * Time.deltaTime);
                break;
            }
        }

        // if any of the raycasts hits anything, the drone will prioritise moving around it over moving towards the player
        if (hitSomething == false) obstacleDetected = false;
        else obstacleDetected = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < numOfRaycasts;  i++)
        {
            Quaternion rot = transform.rotation;
            Quaternion rotMod = Quaternion.AngleAxis(i / ((float)numOfRaycasts - 1) * rayAngle, Vector3.up);
            Vector3 dir = rot * rotMod * Vector3.forward;
            Gizmos.DrawRay(transform.position, dir * rayLength);
        }
    }

    void LookAtPlayer()
    {
        Quaternion goalRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, goalRotation, Time.deltaTime * turnSpeed);
    }
}
