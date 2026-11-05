using UnityEngine;

public class BossState
{
    protected BossBase enemyBase;
    protected BossStateMachineManager stateManager;


    public BossState(BossBase enemyBase, BossStateMachineManager stateManager)
    {
        this.enemyBase = enemyBase;
        this.stateManager = stateManager;
    }

    public virtual void EnterLogic() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void ExitLogic() { }
}
