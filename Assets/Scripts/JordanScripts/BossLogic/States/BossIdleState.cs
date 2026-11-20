using UnityEngine;

// Jordan/Libby Script\\
public class BossIdleState : BossState
{
    float maxTimeBetweenAttacks = 6;
    float minTimeBetweenAttacks = 3;
    float timeBeforeCanAttackAgain;
    /*float gunStateCooldown = 6;
    float tileStateCooldown = 12;
    float droneStateCooldown = 24;*/
    float gunStateCooldown = 20;
    float tileStateCooldown = 5;
    float droneStateCooldown = 20;
    float gunTimer;
    float tileTimer;
    float droneTimer;


    public BossIdleState(BossBase bossBase, BossStateMachineManager stateManager) : base(bossBase, stateManager)
    {
        gunTimer = gunStateCooldown;
        tileTimer = tileStateCooldown;
        droneTimer = droneStateCooldown;
    }

    public override void EnterLogic()
    {
        timeBeforeCanAttackAgain = Random.Range(minTimeBetweenAttacks, maxTimeBetweenAttacks);
        UpdateAnimation(AnimationManager.AnimationStates.Idle);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        CountDownAllTimers();

        // if can attack again, check which timer reaches 0 first and start attack (prioritising most powerful attack)
        if (timeBeforeCanAttackAgain <= 0)
        {
            if (droneTimer <= 0) { StartNextAttack(bossBase.droneAttackState); droneTimer = droneStateCooldown; }
            else if (tileTimer <= 0) { StartNextAttack(bossBase.tileAttackState); tileTimer = tileStateCooldown; }
            else if (gunTimer <= 0) { StartNextAttack(bossBase.gunAttackState); gunTimer = gunStateCooldown; }
        }
    }

    void CountDownAllTimers()
    {
        timeBeforeCanAttackAgain -= Time.deltaTime;
        gunTimer -= Time.deltaTime;
        tileTimer -= Time.deltaTime;
        droneTimer -= Time.deltaTime;
    }

    void StartNextAttack(BossState state)
    {
        bossBase.stateManager.ChangeState(state);
    }
}
