using UnityEngine;

// Jordan/Libby Script\\
[CreateAssetMenu(fileName = "BossPatrolState", menuName = "Scriptable Objects/BossDrone/BossPatrolState")]
public class BossPatrolState : EnemyPatrolSOBase
{


    public override void Initialize(EnemyBase enemyBase, GameObject gameObject)
    {
        base.Initialize(enemyBase, gameObject);
    }

    public override void DoEnterLogic()
    {
        enemyBase.stateManager.ChangeState(enemyBase.chaseState);
    }
}

