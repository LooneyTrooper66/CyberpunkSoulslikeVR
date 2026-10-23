using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public StateMachineManager stateManager { get; set; }
    public EnemyState patrolState; // need to find a good way to expand this for the boss states
    public EnemyState chaseState; 
    public EnemyState attackState; 


    private void Awake()
    {
        stateManager = new StateMachineManager();

        patrolState = new EnemyState(this, stateManager);
        chaseState = new EnemyState(this, stateManager);
        attackState = new EnemyState(this, stateManager);
    }

    private void Start()
    {
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
