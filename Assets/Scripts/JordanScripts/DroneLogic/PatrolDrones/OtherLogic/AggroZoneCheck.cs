using UnityEngine;
using System.Collections;

// Jordan/Libby Script\\
[RequireComponent(typeof(BoxCollider))]
public class AggroZoneCheck : MonoBehaviour
{
    // place this on the aggro zone trigger
    [Tooltip("Every enemy in this trigger zone must be in this array to be able to aggro")]
    [SerializeField] EnemyBase[] enemiesInZone;
    Coroutine lastCoroutine;
    [SerializeField] LootCarLogic thisZoneCar;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lastCoroutine != null) StopCoroutine(lastCoroutine);
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
            lastCoroutine = StartCoroutine(SetBackToFalse());
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

    public void CheckIfAllEnemiesInactive()
    {
        int numInactive = 0;
        foreach (EnemyBase e in enemiesInZone)
        {
            if (e.gameObject.activeSelf == false) numInactive++;
        }

        if (numInactive >= enemiesInZone.Length) thisZoneCar.OpenCar();
    }
}
