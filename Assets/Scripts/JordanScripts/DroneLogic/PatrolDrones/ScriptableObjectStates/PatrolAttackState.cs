using UnityEngine;

// Jordan/Libby Script\\
[CreateAssetMenu(fileName = "PatrolAttackState", menuName = "Scriptable Objects/PatrolDrone/PatrolAttackState")]
public class PatrolAttackState : EnemyAttackSOBase
{
    [SerializeField] float timeBetweenAttacks;
    float attackTimer;
    bool useGun1;


    public override void Initialize(EnemyBase enemyBase, GameObject gameObject)
    {
        base.Initialize(enemyBase, gameObject);
    }
    public override void DoEnterLogic()
    {
        enemyBase.shootPoint1.gameObject.SetActive(true);
        enemyBase.shootPoint2.gameObject.SetActive(true);
        attackTimer = timeBetweenAttacks - 2;
    }
    public override void DoFrameUpdateLogic()
    {
        // chase and object avoidance will be running from base enemy script \\

        attackTimer += Time.deltaTime;
        if (attackTimer >= timeBetweenAttacks)
        {
            // alternate between each shoot point
            if (useGun1)
            {
                enemyBase.pooler.SpawnFromPool("droneProjectiles", enemyBase.shootPoint1.position, enemyBase.shootPoint1.rotation);
                useGun1 = false;
            }
            else
            {
                enemyBase.pooler.SpawnFromPool("droneProjectiles", enemyBase.shootPoint2.position, enemyBase.shootPoint1.rotation);
                useGun1 = true;
            }
            attackTimer = 0;
        }

        if (!enemyBase.IsAggroed || !enemyBase.IsWithinAttackDist) enemyBase.stateManager.ChangeState(enemyBase.chaseState);
    }
    public override void DoPhysicsUpdateLogic()
    {

    }
    public override void DoExitLogic()
    {
        enemyBase.shootPoint1.gameObject.SetActive(false);
        enemyBase.shootPoint2.gameObject.SetActive(false);
    }
}
