using UnityEngine;

public class BossStateMachineManager
{
    public BossState currentState { get; set; }


    public void Initialize(BossState startState)
    {
        currentState = startState;
        currentState.EnterLogic();
    }

    public void ChangeState(BossState state)
    {
        currentState.ExitLogic();
        currentState = state;
        currentState.EnterLogic();
    }
}
