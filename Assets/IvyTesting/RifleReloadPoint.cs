using UnityEngine;

public class RifleReloadPoint : MonoBehaviour
{
    public WeaponRifle Rifle;
    public WeaponClass.WeaponType magType;
    //when the gun emptys the mag slot enable this script
    public Transform LockedPoint;//where the mag will be locked to once loaded
    //when a new mag is collided with put it into the gun and disable this scri


    private void OnTriggerEnter(Collider other)
    {
        //checks if th ecollision is a mag and the magaise matched the weapon type
        /*if(other.CompareTag("Magazine") && other.gameObject.GetComponent<Magazine>().Type == magType)
        {
            //reload the weapon with the provided mag
            Magazine mag = other.gameObject.GetComponent<Magazine>();
            Rifle.Reload(mag);


            mag.gameObject.transform.position = LockedPoint.position;
            mag.gameObject.transform.rotation = LockedPoint.rotation;
            mag.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //
        }*/
        
    }
}
