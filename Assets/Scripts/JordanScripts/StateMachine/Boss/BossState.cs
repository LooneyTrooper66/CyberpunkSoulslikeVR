using UnityEngine;

public class BossState
{
    protected BossStateMachine enemyBase;
    protected BossStateMachineManager stateManager;


    public BossState(BossStateMachine enemyBase, BossStateMachineManager stateManager)
    {
        this.enemyBase = enemyBase;
        this.stateManager = stateManager;
    }

    public virtual void EnterLogic() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void ExitLogic() { }
}
