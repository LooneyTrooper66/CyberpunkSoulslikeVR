using UnityEngine;

[CreateAssetMenu(fileName = "PatrolChaseState", menuName = "Scriptable Objects/PatrolDrone/PatrolChaseState")]
public class PatrolChaseState : EnemyChaseSOBase
{


    public override void Initialize(EnemyBase enemyBase, GameObject gameObject)
    {
        base.Initialize(enemyBase, gameObject);
    }
    public override void DoFrameUpdateLogic()
    {
        // chase and object avoidance will be running from base enemy script \\

        // only swap to attack state if the player is within drones attack range AND aggro zone
        if (enemyBase.IsAggroed && enemyBase.IsWithinAttackDist) enemyBase.stateManager.ChangeState(enemyBase.attackState);
        // if player is outside of aggro area, swap back to patrol
        if (!enemyBase.IsAggroed) enemyBase.stateManager.ChangeState(enemyBase.patrolState);
    }

    public override void DoExitLogic()
    {

    }
}
