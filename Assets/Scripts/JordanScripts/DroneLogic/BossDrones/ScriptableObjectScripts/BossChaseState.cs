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
        // movement handled by pursuit logic \\

        // only swap to attack state if the player is within drones attack range 
        if (enemyBase.IsWithinAttackDist) enemyBase.stateManager.ChangeState(enemyBase.attackState);
    }
}

