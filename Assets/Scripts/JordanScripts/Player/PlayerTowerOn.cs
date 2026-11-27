using UnityEngine;

// Jordan/Libby Script\\
public class PlayerTowerOn : MonoBehaviour
{
    public string towerCurrentlyOn;
    LayerMask floorMask;


    void Start()
    {
        floorMask = LayerMask.GetMask("Default");
    }

    private void FixedUpdate()
    {
        CheckTowerOn();
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
