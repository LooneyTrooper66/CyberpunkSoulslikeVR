using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AttackTrigger : MonoBehaviour
{
    // place this on empty drone child

    [SerializeField] EnemyBase enemyBase;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyBase.IsWithinAttackDist = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyBase.IsWithinAttackDist = false;
        }
    }
}
