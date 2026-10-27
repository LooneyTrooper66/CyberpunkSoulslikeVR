using UnityEngine;

[CreateAssetMenu(fileName = "PatrolAttackState", menuName = "Scriptable Objects/PatrolDrone/PatrolAttackState")]
public class PatrolAttackState : EnemyAttackSOBase
{
    [SerializeField] float timeBetweenAttacks;
    float attackTimer;


    public override void DoEnterLogic()
    {
        Debug.Log("entered attack");
        attackTimer = timeBetweenAttacks - 1;
    }
    public override void DoFrameUpdateLogic()
    {

    }
    public override void DoPhysicsUpdateLogic()
    {

    }
    public override void DoExitLogic()
    {
        Debug.Log("exited attack");
    }
}
