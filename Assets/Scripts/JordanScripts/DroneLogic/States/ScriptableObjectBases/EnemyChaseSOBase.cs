using UnityEngine;

public class EnemyChaseSOBase : ScriptableObject
{
    protected DroneStateMachine enemyBase;
    protected GameObject gameObject;


    public virtual void Initialize(DroneStateMachine enemyBase, GameObject gameObject)
    {
        this.enemyBase = enemyBase;
        this.gameObject = gameObject;
    }

    public virtual void DoEnterLogic() { }
    public virtual void DoFrameUpdateLogic() { }
    public virtual void DoPhysicsUpdateLogic() { }
    public virtual void DoExitLogic() { }
}
