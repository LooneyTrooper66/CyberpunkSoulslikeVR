using UnityEngine;

public class DroneChaseState : EnemyState
{
    public DroneChaseState(EnemyBase enemyBase, EnemyStateMachineManager stateManager) : base(enemyBase, stateManager)
    {
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        enemyBase.chaseBaseInstance.DoEnterLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemyBase.chaseBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemyBase.chaseBaseInstance.DoPhysicsUpdateLogic();
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
        enemyBase.chaseBaseInstance.DoExitLogic();
    }
}
