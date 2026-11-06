using System.Net;
using UnityEngine;

public class WeaponCrossbowLineVisuliser : MonoBehaviour
{
    [SerializeField] Transform endPointObject;
    [SerializeField] LineRenderer lR;
    //


    // Update is called once per frame
    void FixedUpdate()
    {
        lR.SetPosition(0, this.transform.position);
        lR.SetPosition(1, endPointObject.position);
    }
}
