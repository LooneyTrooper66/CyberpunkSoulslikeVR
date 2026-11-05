using UnityEngine;

public class DroneAttackState : EnemyState
{
    public DroneAttackState(EnemyBase enemyBase, EnemyStateMachineManager stateManager) : base(enemyBase, stateManager)
    {
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        enemyBase.attackBaseInstance.DoEnterLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemyBase.attackBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemyBase.attackBaseInstance.DoPhysicsUpdateLogic();
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
        enemyBase.attackBaseInstance.DoExitLogic();
    }
}
