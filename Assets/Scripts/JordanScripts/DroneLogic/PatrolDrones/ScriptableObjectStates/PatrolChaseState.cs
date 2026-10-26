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

    }
    public override void DoPhysicsUpdateLogic()
    {

    }
    public override void DoExitLogic()
    {
        Debug.Log("exited chase");
    }
}
