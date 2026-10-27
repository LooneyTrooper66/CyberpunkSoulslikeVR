using UnityEngine;

public class EnemyPatrolSOBase : ScriptableObject
{
    protected EnemyBase enemyBase;
    protected GameObject gameObject;


    public virtual void Initialize(EnemyBase enemyBase, GameObject gameObject)
    {
        this.enemyBase = enemyBase;
        this.gameObject = gameObject;
    }

    public virtual void DoEnterLogic() { }
    public virtual void DoFrameUpdateLogic() { }
    public virtual void DoPhysicsUpdateLogic() { }
    public virtual void DoExitLogic() { }
}
