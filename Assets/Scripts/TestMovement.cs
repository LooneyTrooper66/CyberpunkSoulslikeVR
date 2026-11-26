using UnityEngine;

public class TestMovement : MonoBehaviour, IDamageable
{
    public float hitCount;
    public string towerCurrentlyOn;
    LayerMask floorMask;


    void Start()
    {
        floorMask = LayerMask.GetMask("TowerFloor");
    }

    private void FixedUpdate()
    {
        CheckTowerOn();
    }

    void IDamageable.TakeDamage(float damage)
    {
        hitCount += damage;
    }

    void CheckTowerOn()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up * -1, out hit, 10, floorMask))
        {
            towerCurrentlyOn = hit.collider.gameObject.name;
        }
    }
}
