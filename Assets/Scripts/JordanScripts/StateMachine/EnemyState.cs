using UnityEngine;

public class EnemyState : MonoBehaviour
{
    protected EnemyBase enemyBase;
    protected StateMachineManager stateManager;


    public EnemyState (EnemyBase enemyBase, StateMachineManager stateManager)
    {
        this.enemyBase = enemyBase; 
        this.stateManager = stateManager;
    }

    public virtual void EnterLogic() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void ExitLogic() { }
}
