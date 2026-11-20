using UnityEngine;

// Jordan/Libby Script\\
public class DronePursuitLogic : MonoBehaviour
{
    [Header("Player Follow Variables")]
    [SerializeField] EnemyBase enemyBase;
    [SerializeField] Transform player;
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float thisHeight;
    [Header("Obstacle Avoidance Variables")]
    [SerializeField] int numOfRaycasts;
    [SerializeField] float rayAngle;
    [SerializeField] float avoidRadius;
    [SerializeField] Transform[] otherEnemiesInZone;
    [SerializeField] Transform bossTransform;
    [SerializeField] float bossAvoidRadius;
    bool obstacleDetected;
    bool hitSomething;


    void OnEnable()
    {
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
        if (!obstacleDetected && !enemyBase.IsWithinAttackDist)
        {
            Vector3 playerHigher = new Vector3(player.position.x, player.position.y + 2, player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, playerHigher, moveSpeed * Time.deltaTime);
        }
    }

    void DetectObstacles()
    {
        hitSomething = false;
        Vector3 dirToBoss = DetectBoss();
        Vector3 dirToClosestEnemy = DetectOtherEnemies();

        Vector3 dirToMove = dirToBoss + dirToClosestEnemy;

        // if any of the raycasts hits anything, the drone will prioritise moving around it over moving towards the player
        if (hitSomething == false || dirToMove == Vector3.zero) { obstacleDetected = false; return; }
        else obstacleDetected = true;

        dirToMove = new Vector3(dirToMove.x, 0, dirToMove.z);
        dirToMove = transform.position - dirToMove.normalized;
        transform.position = Vector3.MoveTowards(transform.position, dirToMove, moveSpeed * Time.deltaTime);
        Debug.DrawRay(transform.position, dirToMove, Color.yellow);
    }
    Vector3 DetectBoss()
    {
        // if the closest enemy in this drones area gets within the avoid radius, this will return the directional vector to that enemy
        float distToBoss = Vector3.Distance(transform.position, bossTransform.position);
        Vector3 dirToBoss = Vector3.zero;

        if (distToBoss <= bossAvoidRadius)
        {
            hitSomething = true;
            dirToBoss = bossTransform.position - transform.position;
            Debug.DrawRay(transform.position, dirToBoss, Color.purple, 5);
            return dirToBoss;
        }
        else return dirToBoss;
    }
    Vector3 DetectOtherEnemies()
    {
        // if the closest enemy in this drones area gets within the avoid radius, this will return the directional vector to that enemy
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
            dirToEnemy = closestEnemy.position - transform.position;
            //Debug.DrawRay(transform.position, dirToEnemy, Color.purple, 5);
            return dirToEnemy;
        }
        else return dirToEnemy;
    }

    void LookAtPlayer()
    {
        Quaternion goalRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, goalRotation, Time.deltaTime * turnSpeed);
    }


    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < numOfRaycasts; i++)
        {
            Quaternion rot = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            Quaternion rotMod = Quaternion.AngleAxis(i / ((float)numOfRaycasts - 1) * rayAngle, Vector3.up);
            Vector3 dir = rot * rotMod * Vector3.forward;
            Gizmos.DrawRay(transform.position, dir * avoidRadius);
        }
    }*/
}
