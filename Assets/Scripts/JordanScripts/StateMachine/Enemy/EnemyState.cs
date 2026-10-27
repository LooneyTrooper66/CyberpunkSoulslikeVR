using UnityEngine;

public class EnemyState
{
    protected EnemyBase enemyBase;
    protected EnemyStateMachineManager stateManager;


    public EnemyState (EnemyBase enemyBase, EnemyStateMachineManager stateManager)
    {
        this.enemyBase = enemyBase; 
        this.stateManager = stateManager;
    }

    public virtual void EnterLogic() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void ExitLogic() { }
}
