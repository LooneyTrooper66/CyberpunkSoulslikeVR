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
    [SerializeField] float avoidRadius;
    [SerializeField] LayerMask obstacleAvoidanceMask;
    [SerializeField] Transform[] otherEnemiesInZone;
    bool obstacleDetected;
    bool hitSomething;


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
        hitSomething = false;
        Vector3 dirToObstacle = DetectEnvironment();
        Vector3 dirToClosestEnemy = DetectOtherEnemies();

        Vector3 dirToMove = dirToObstacle + dirToClosestEnemy;
        Debug.Log(dirToMove);

        // if any of the raycasts hits anything, the drone will prioritise moving around it over moving towards the player
        if (hitSomething == false || dirToMove == Vector3.zero) { obstacleDetected = false; return; }
        else obstacleDetected = true;

        dirToMove = new Vector3(dirToMove.x, 0, dirToMove.z);
        dirToMove = transform.position - dirToMove.normalized;
        //Debug.Log("dir to move: " + dirToMove);
        transform.position = Vector3.MoveTowards(transform.position, dirToMove, moveSpeed * Time.deltaTime);
        Debug.DrawRay(transform.position, dirToMove, Color.yellow);

        // if any of the raycasts hits anything, the drone will prioritise moving around it over moving towards the player
        if (hitSomething == false) obstacleDetected = false;
        else obstacleDetected = true;
    }

    Vector3 DetectEnvironment()
    {
        Vector3 dirToObs = Vector3.zero;
        for (int i = 0; i < numOfRaycasts; i++)
        {
            Quaternion rot = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            Quaternion rotMod = Quaternion.AngleAxis(i / ((float)numOfRaycasts - 1) * rayAngle, Vector3.up);
            Vector3 dir = rot * rotMod * Vector3.forward;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, avoidRadius, obstacleAvoidanceMask))
            {
                hitSomething = true;
                dirToObs -= (1 / numOfRaycasts) * moveSpeed * dir;
                Debug.Log("dir to obs: " + dirToObs + " obs name: " +hit.collider.gameObject.name);
                break;
            }
        }
        return dirToObs;
    }
    Vector3 DetectOtherEnemies()
    {
        Vector3 dirToEnemy = Vector3.zero;

        // catch null error
        if (otherEnemiesInZone.Length <= 0) return dirToEnemy;

        Transform closestEnemy = null;
        float closestDist = Mathf.Infinity;
        foreach (Transform t in otherEnemiesInZone)
        {
            float dist = Vector3.Distance(transform.position, t.position);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestEnemy = t;
            }
        }

        if (closestDist <= avoidRadius)
        {
            hitSomething = true;
            dirToEnemy = (closestEnemy.position - transform.position) * -1;
            //Debug.Log("dir to enemy: " + dirToEnemy);
            return dirToEnemy;
        }
        else return dirToEnemy;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < numOfRaycasts; i++)
        {
            Quaternion rot = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            Quaternion rotMod = Quaternion.AngleAxis(i / ((float)numOfRaycasts - 1) * rayAngle, Vector3.up);
            Vector3 dir = rot * rotMod * Vector3.forward;
            Gizmos.DrawRay(transform.position, dir * avoidRadius);
        }
    }

    void LookAtPlayer()
    {
        Quaternion goalRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, goalRotation, Time.deltaTime * turnSpeed);
    }
}
