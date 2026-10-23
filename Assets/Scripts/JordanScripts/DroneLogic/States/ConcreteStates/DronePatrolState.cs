using UnityEngine;

public class DronePatrolState : EnemyState
{
    public DronePatrolState(DroneStateMachine enemyBase, EnemyStateMachineManager stateManager) : base(enemyBase, stateManager)
    {
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        enemyBase.patrolBaseInstance.DoEnterLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemyBase.patrolBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemyBase.patrolBaseInstance.DoPhysicsUpdateLogic();
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
        enemyBase.patrolBaseInstance.DoExitLogic();
    }
}
