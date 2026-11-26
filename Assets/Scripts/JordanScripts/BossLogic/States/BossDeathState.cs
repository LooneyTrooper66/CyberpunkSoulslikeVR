using UnityEngine;

// Jordan/Libby Script\\
public class BossDeathState : BossState
{


    public BossDeathState(BossBase bossBase, BossStateMachineManager stateManager) : base(bossBase, stateManager)
    {
    }

    public override void EnterLogic()
    {
        bossBase.animManager.ChangeAnimation(AnimationManager.AnimationStates.Destroyed);
    }

    void ShowWinUI()
    {
        Debug.Log("you winned");
    }

    public override void AnimationTriggerEvent(BossBase.AnimationTriggers trigger)
    {
        if (trigger == BossBase.AnimationTriggers.deathAnimEnded) ShowWinUI();
    }
}
