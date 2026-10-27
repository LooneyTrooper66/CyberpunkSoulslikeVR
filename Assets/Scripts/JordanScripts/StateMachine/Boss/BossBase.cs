using UnityEngine;

public class BossBase : MonoBehaviour
{
    public BossStateMachineManager stateManager { get; set; }

    public BossIdleState idleState;
    public BossTileAttackState tileAttackState;
    public BossLaserAttackState laserAttackState;
    public BossDroneAttackState droneAttackState;


    private void Awake()
    {
        stateManager = new BossStateMachineManager();

        idleState = new BossIdleState(this, stateManager);
        tileAttackState = new BossTileAttackState(this, stateManager);
        laserAttackState = new BossLaserAttackState(this, stateManager);
        droneAttackState = new BossDroneAttackState(this, stateManager);
    }

    private void Start()
    {
        stateManager.Initialize(idleState);
    }

    private void Update()
    {
        stateManager.currentState.FrameUpdate();
    }
    private void FixedUpdate()
    {
        stateManager.currentState.PhysicsUpdate();
    }
}
