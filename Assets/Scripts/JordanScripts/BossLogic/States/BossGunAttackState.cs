using UnityEngine;

public class BossGunAttackState : BossState
{
    float i = 0;


    public BossGunAttackState(BossBase enemyBase, BossStateMachineManager stateManager) : base(enemyBase, stateManager)
    {
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        Debug.Log("entered gun");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        i += Time.deltaTime;
        if (i > 5) stateManager.ChangeState(enemyBase.tileAttackState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
        Debug.Log("exited gun");
    }
}
