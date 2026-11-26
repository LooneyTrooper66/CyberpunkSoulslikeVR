using UnityEngine;

// Jordan/Libby Script\\
public class BossGunAttackState : BossState
{
    LookAtPlayer lookAt;


    public BossGunAttackState(BossBase bossBase, BossStateMachineManager stateManager) : base(bossBase, stateManager)
    {
        lookAt = bossBase.gameObject.GetComponent<LookAtPlayer>();
    }

    public override void EnterLogic()
    {
        lookAt.enabled = false;
        bossBase.animManager.ChangeAnimation(AnimationManager.AnimationStates.gunAttack);
    }

    void ShootGun()
    {
        for (int i = 0; i < bossBase.shootPoints.Length; i++)
        {
            bossBase.pooler.SpawnFromPool("bossProjectiles", bossBase.shootPoints[i].position, bossBase.shootPoints[i].rotation);
        }
    }

    public override void AnimationTriggerEvent(BossBase.AnimationTriggers trigger)
    {
        if (trigger == BossBase.AnimationTriggers.shootGun) ShootGun();
        else if (trigger == BossBase.AnimationTriggers.returnToIdle) ChangeToIdle();
    }

    public override void ExitLogic()
    {
        lookAt.enabled = true;
    }
}
