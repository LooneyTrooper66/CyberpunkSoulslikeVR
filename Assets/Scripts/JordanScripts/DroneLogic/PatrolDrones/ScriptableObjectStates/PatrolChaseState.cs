using UnityEngine;

[CreateAssetMenu(fileName = "PatrolChaseState", menuName = "Scriptable Objects/PatrolDrone/PatrolChaseState")]
public class PatrolChaseState : EnemyChaseSOBase
{


    public override void DoEnterLogic()
    {

    }
    public override void DoFrameUpdateLogic()
    {
        // only swap to attack state if the player is within drones attack range AND aggro zone
        if (enemyBase.IsAggroed && enemyBase.IsWithinAttackDist) enemyBase.stateManager.ChangeState(enemyBase.attackState);
        // if player is outside of aggro area, swap back to patrol
        if (!enemyBase.IsAggroed) enemyBase.stateManager.ChangeState(enemyBase.patrolState);

        // chase player
        // ill make my own obstacle avoidance for this
    }
    public override void DoPhysicsUpdateLogic()
    {

    }
    public override void DoExitLogic()
    {

    }
}
