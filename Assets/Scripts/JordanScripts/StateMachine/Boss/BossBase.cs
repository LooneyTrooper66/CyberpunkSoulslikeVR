using UnityEngine;

public class BossBase : MonoBehaviour
{
    public BossStateMachineManager stateManager { get; set; }


    private void Awake()
    {
        stateManager = new BossStateMachineManager();
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
