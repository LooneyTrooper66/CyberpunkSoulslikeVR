using UnityEngine;

public class BossTileAttackState : BossState
{
    float i = 0;


    public BossTileAttackState(BossBase enemyBase, BossStateMachineManager stateManager) : base(enemyBase, stateManager)
    {
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        Debug.Log("entered tile");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        i += Time.deltaTime;
        if (i > 5) stateManager.ChangeState(enemyBase.laserAttackState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
        Debug.Log("exited tile");
    }
}
