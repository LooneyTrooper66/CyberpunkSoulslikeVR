using UnityEngine;

public class Magazine : MonoBehaviour
{
    [Header("base")]
    public GameObject bulletObj;
    public uint ammo;
    public uint magSize;
    public WeaponClass.WeaponType Type;


    public void OnGrab()
    {
        //when the mag is grabbed from a gun unload the weapon
        //disable all the rigibyody stuff

        //deparent it from the rifle
        transform.parent = null;
        //allow it to be droped into a reload point

        Debug.Log("GRAB");
    }
    public void OnDrop()
    {
        Debug.Log("DROP");
        GetComponent<Rigidbody>().isKinematic = false;
    }

    //could add additional functionality such as bullet speed (this could also be in the bullet objects data)
}
