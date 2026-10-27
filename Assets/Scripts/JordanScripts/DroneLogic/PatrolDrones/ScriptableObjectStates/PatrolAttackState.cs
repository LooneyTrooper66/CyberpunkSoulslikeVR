using UnityEngine;

[CreateAssetMenu(fileName = "PatrolAttackState", menuName = "Scriptable Objects/PatrolDrone/PatrolAttackState")]
public class PatrolAttackState : EnemyAttackSOBase
{
    [SerializeField] float timeBetweenAttacks;
    float attackTimer;


    public override void DoEnterLogic()
    {
        enemyBase.shootPoint.gameObject.SetActive(true);
        attackTimer = timeBetweenAttacks - 1;
    }
    public override void DoFrameUpdateLogic()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= timeBetweenAttacks)
        {
            // need to upgrade to alternate between two shoot points or shoot two at once
            enemyBase.pooler.SpawnFromPool("droneProjectiles", enemyBase.shootPoint.position, enemyBase.shootPoint.rotation);
            attackTimer = 0;
        }

        if (!enemyBase.IsAggroed || !enemyBase.IsWithinAttackDist) enemyBase.stateManager.ChangeState(enemyBase.chaseState);
    }
    public override void DoPhysicsUpdateLogic()
    {

    }
    public override void DoExitLogic()
    {
        enemyBase.shootPoint.gameObject.SetActive(false);
    }
}
