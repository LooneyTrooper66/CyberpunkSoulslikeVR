using UnityEngine;

// Jordan/Libby Script\\
[CreateAssetMenu(fileName = "BossAttackState", menuName = "Scriptable Objects/BossDrone/BossAttackState")]
public class BossAttackState : EnemyAttackSOBase
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
        // drone will stay still while in this state \\


        ShootOnTimer();

        // if player gets out of range swap back to chase
        if (!enemyBase.IsWithinAttackDist) enemyBase.stateManager.ChangeState(enemyBase.chaseState);
    }

    void ShootOnTimer()
    {
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
    }

    public override void DoExitLogic()
    {
        enemyBase.shootPoint1.gameObject.SetActive(false);
        enemyBase.shootPoint2.gameObject.SetActive(false);
    }
}
