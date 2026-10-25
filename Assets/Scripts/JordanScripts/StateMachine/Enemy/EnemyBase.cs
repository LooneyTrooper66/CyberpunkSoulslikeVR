using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public EnemyStateMachineManager stateManager { get; set; }

    // Concrete States \\
    public DronePatrolState patrolState;
    public DroneChaseState chaseState;
    public DroneAttackState attackState;

    // Scriptable Object States \\
    [SerializeField] EnemyPatrolSOBase patrolBase;
    [SerializeField] EnemyChaseSOBase chaseBase;
    [SerializeField] EnemyAttackSOBase attackBase;
    public EnemyPatrolSOBase patrolBaseInstance { get; set; }
    public EnemyChaseSOBase chaseBaseInstance { get; set; }
    public EnemyAttackSOBase attackBaseInstance { get; set; }


    private void Awake()
    {
        stateManager = new EnemyStateMachineManager();
        patrolBaseInstance = Instantiate(patrolBase);
        chaseBaseInstance = Instantiate(chaseBase);
        attackBaseInstance = Instantiate(attackBase);

        patrolState = new DronePatrolState(this, stateManager);
        chaseState = new DroneChaseState(this, stateManager);
        attackState = new DroneAttackState(this, stateManager);
    }

    private void Start()
    {
        patrolBaseInstance.Initialize(this, gameObject);
        chaseBaseInstance.Initialize(this, gameObject);
        attackBaseInstance.Initialize(this, gameObject);

        stateManager.Initialize(patrolState);
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
