using UnityEngine;

public class ShootPointLookAt : MonoBehaviour
{
    EnemyBase enemyBase;


    void Start()
    {
        enemyBase = gameObject.GetComponentInParent<EnemyBase>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.LookAt(enemyBase.player.transform);
    }
}
