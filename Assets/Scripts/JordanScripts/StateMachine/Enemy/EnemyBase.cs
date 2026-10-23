using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public EnemyStateMachineManager stateManager { get; set; }


    private void Awake()
    {
        stateManager = new EnemyStateMachineManager();
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
