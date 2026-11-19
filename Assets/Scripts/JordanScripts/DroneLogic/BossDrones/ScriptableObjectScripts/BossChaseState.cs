using UnityEngine;

// Jordan/Libby Script\\
[CreateAssetMenu(fileName = "BossChaseState", menuName = "Scriptable Objects/BossDrone/BossChaseState")]
public class BossChaseState : EnemyChaseSOBase
{
    [SerializeField] float moveSpeed;


    public override void Initialize(EnemyBase enemyBase, GameObject gameObject)
    {
        base.Initialize(enemyBase, gameObject);
    }
    public override void DoFrameUpdateLogic()
    {
        // move towards player
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, enemyBase.player.transform.position, moveSpeed);

        // only swap to attack state if the player is within drones attack range 
        if (enemyBase.IsWithinAttackDist) enemyBase.stateManager.ChangeState(enemyBase.attackState);
    }

    public override void DoExitLogic()
    {

    }
}

