using UnityEngine;

[CreateAssetMenu(fileName = "PatrolAttackState", menuName = "Scriptable Objects/PatrolDrone/PatrolAttackState")]
public class PatrolAttackState : EnemyAttackSOBase
{
    float i = 0;

    public override void DoEnterLogic()
    {
        i = 0;
        Debug.Log("entered attack");
    }
    public override void DoFrameUpdateLogic()
    {
        i += Time.deltaTime;
        if (i > 3) enemyBase.stateManager.ChangeState(enemyBase.patrolState);
    }
    public override void DoPhysicsUpdateLogic()
    {

    }
    public override void DoExitLogic()
    {
        Debug.Log("exited attack");
    }
}
