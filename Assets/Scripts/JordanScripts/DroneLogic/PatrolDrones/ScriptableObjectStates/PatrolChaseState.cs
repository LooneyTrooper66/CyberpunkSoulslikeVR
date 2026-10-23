using UnityEngine;

[CreateAssetMenu(fileName = "PatrolChaseState", menuName = "Scriptable Objects/PatrolDrone/PatrolChaseState")]
public class PatrolChaseState : EnemyChaseSOBase
{
    float i = 0;

    public override void DoEnterLogic()
    {
        i = 0;
        Debug.Log("entered chase");
    }
    public override void DoFrameUpdateLogic()
    {
        i += Time.deltaTime;
        if (i > 3) enemyBase.stateManager.ChangeState(enemyBase.attackState);
    }
    public override void DoPhysicsUpdateLogic()
    {

    }
    public override void DoExitLogic()
    {
        Debug.Log("exited chase");
    }
}
