using UnityEngine;

public class StateMachineManager
{
    public EnemyState currentState { get; set; }


    public void Initialize(EnemyState startState)
    {
        currentState = startState;
        currentState.EnterLogic();
    }

    public void ChangeState(EnemyState state)
    {
        currentState.ExitLogic();
        currentState = state;
        currentState.EnterLogic();
    }
}
