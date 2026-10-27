using UnityEngine;

[CreateAssetMenu(fileName = "PatrolChaseState", menuName = "Scriptable Objects/PatrolDrone/PatrolChaseState")]
public class PatrolChaseState : EnemyChaseSOBase
{


    public override void DoEnterLogic()
    {
        Debug.Log("entered chase");
    }
    public override void DoFrameUpdateLogic()
    {
        // only swap to attack state if the player is within drones attack range AND aggro zone
        if (enemyBase.IsAggroed && enemyBase.IsWithinAttackDist) enemyBase.stateManager.ChangeState(enemyBase.attackState);

        // chase player

    }
    public override void DoPhysicsUpdateLogic()
    {

    }
    public override void DoExitLogic()
    {
        Debug.Log("exited chase");
    }
}
