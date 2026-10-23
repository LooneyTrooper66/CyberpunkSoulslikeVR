using UnityEngine;

[CreateAssetMenu(fileName = "PatrolPatrolState", menuName = "Scriptable Objects/PatrolDrone/PatrolPatrolState")]
public class PatrolPatrolState : EnemyPatrolSOBase
{
    float i = 0;

    public override void DoEnterLogic()
    {
        i = 0;
        Debug.Log("entered patrol");
    }
    public override void DoFrameUpdateLogic()
    {
        i += Time.deltaTime;
        if (i > 3) enemyBase.stateManager.ChangeState(enemyBase.chaseState);
    }
    public override void DoPhysicsUpdateLogic()
    {

    }
    public override void DoExitLogic()
    {
        Debug.Log("exited patrol");
    }
}
