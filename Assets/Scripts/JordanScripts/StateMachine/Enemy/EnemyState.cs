using UnityEngine;

public class EnemyState
{
    protected DroneStateMachine enemyBase;
    protected EnemyStateMachineManager stateManager;


    public EnemyState (DroneStateMachine enemyBase, EnemyStateMachineManager stateManager)
    {
        this.enemyBase = enemyBase; 
        this.stateManager = stateManager;
    }

    public virtual void EnterLogic() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void ExitLogic() { }
}
