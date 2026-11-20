using UnityEngine;

// Jordan/Libby Script\\
public class DronePursuitLogic : MonoBehaviour
{
    [Header("Player Follow Variables")]
    [SerializeField] EnemyBase enemyBase;
    public Transform player;
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    float thisHeight;
    [Header("Obstacle Avoidance Variables")]
    [SerializeField] int numOfRaycasts;
    [SerializeField] float rayAngle;
    [SerializeField] float avoidRadius;
    [SerializeField] LayerMask obstacleAvoidanceMask;
    bool obstacleDetected;
    bool hitSomething;


    void OnEnable()
    {
        thisHeight = gameObject.transform.position.y;
        obstacleDetected = false;
    }

    void Update()
    {
        // follow player while avoiding any obstacles unless player within attack dist
        ObstacleAvoidanceMovement();

        LookAtPlayer();
    }

    void ObstacleAvoidanceMovement()
    {
        DetectObstacles();
        if (!obstacleDetected && !enemyBase.IsWithinAttackDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    void DetectObstacles()
    {
        hitSomething = false;
        Vector3 dirToObstacle = DetectEnvironment();

        // if any of the raycasts hits anything, the drone will prioritise moving around it over moving towards the player
        if (hitSomething == false || dirToObstacle == Vector3.zero) { obstacleDetected = false; return; }
        else obstacleDetected = true;

        dirToObstacle = new Vector3(dirToObstacle.x, 0, dirToObstacle.z);
        Vector3 dirToMove = transform.position - dirToObstacle.normalized;
        transform.position = Vector3.MoveTowards(transform.position, dirToMove, moveSpeed * Time.deltaTime);
        //Debug.DrawRay(transform.position, dirToMove, Color.yellow);

        // if any of the raycasts hits anything, the drone will prioritise moving around it over moving towards the player
        if (hitSomething == false) obstacleDetected = false;
        else obstacleDetected = true;
    }

    Vector3 DetectEnvironment()
    {
        // if any of the raycasts hit an obstacle, this will return the directional vector to that obstacle
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
                dirToObs = (dir * -10) - transform.position;
                Debug.DrawRay(transform.position, dirToObs, Color.red, 5);
                break;
            }
        }
        return dirToObs;
    }

    void LookAtPlayer()
    {
        Quaternion goalRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, goalRotation, Time.deltaTime * turnSpeed);
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
}
