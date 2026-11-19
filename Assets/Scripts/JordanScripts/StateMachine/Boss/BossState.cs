using UnityEngine;

// Jordan/Libby Script\\
public class BossState
{
    protected BossBase bossBase;
    protected BossStateMachineManager stateManager;


    public BossState(BossBase bossBase, BossStateMachineManager stateManager)
    {
        this.bossBase = bossBase;
        this.stateManager = stateManager;
    }

    public virtual void EnterLogic() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void ExitLogic() { }
    public virtual void AnimationTriggerEvent(BossBase.AnimationTriggers trigger) { }

    protected void ChangeToIdle()
    {
        bossBase.stateManager.ChangeState(bossBase.idleState);
    }
    protected void UpdateAnimation(AnimationManager.AnimationStates state)
    {
        bossBase.animManager.ChangeAnimation(state);
    }
}
