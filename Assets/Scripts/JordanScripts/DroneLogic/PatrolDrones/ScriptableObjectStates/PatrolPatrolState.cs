using UnityEngine;

[CreateAssetMenu(fileName = "PatrolPatrolState", menuName = "Scriptable Objects/PatrolDrone/PatrolPatrolState")]
public class PatrolPatrolState : EnemyPatrolSOBase
{
    [SerializeField] DronePatrolRouteHandler handler;


    public override void Initialize(EnemyBase enemyBase, GameObject gameObject)
    {
        base.Initialize(enemyBase, gameObject);
        handler = gameObject.GetComponentInChildren<DronePatrolRouteHandler>();
        handler.parent = gameObject;
    }

    public override void DoEnterLogic()
    {
        handler.enabled = true;
        handler.StartPatrol();
    }
    public override void DoFrameUpdateLogic()
    {
        if (enemyBase.IsAggroed) enemyBase.stateManager.ChangeState(enemyBase.chaseState); 
    }
    public override void DoPhysicsUpdateLogic()
    {

    }
    public override void DoExitLogic()
    {
        handler.enabled = false;
    }
}
