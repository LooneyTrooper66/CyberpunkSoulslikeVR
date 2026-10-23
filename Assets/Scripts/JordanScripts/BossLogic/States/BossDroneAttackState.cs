using UnityEngine;

public class BossDroneAttackState : BossState
{
    float i = 0;


    public BossDroneAttackState(BossStateMachine enemyBase, BossStateMachineManager stateManager) : base(enemyBase, stateManager)
    {
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        Debug.Log("entered chase");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        i += Time.deltaTime;
        if (i > 5) stateManager.ChangeState(enemyBase.idleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
        Debug.Log("exited chase");
    }
}
