using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class AggroZoneCheck : MonoBehaviour
{
    // place this on the aggro zone trigger

    [Tooltip("Every enemy in this trigger zone must be in this array to be able to aggro")]
    [SerializeField] EnemyBase[] enemiesInZone;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(SetBackToFalse());
            for (int i = 0; i < enemiesInZone.Length; i++)
            {
                EnemyBase thisBase = enemiesInZone[i].GetComponentInChildren<EnemyBase>();
                thisBase.SetAggroStatus(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SetBackToFalse());
        }
    }

    IEnumerator SetBackToFalse()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < enemiesInZone.Length; i++)
        {
            EnemyBase thisBase = enemiesInZone[i].GetComponentInChildren<EnemyBase>();
            thisBase.SetAggroStatus(false);
        }
    }
}
