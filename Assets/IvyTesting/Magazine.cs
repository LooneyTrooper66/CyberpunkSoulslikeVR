using UnityEngine;

public class Magazine : MonoBehaviour
{
    [Header("base")]
    public GameObject bulletObj;
    public uint ammo;
    public uint magSize;
    public WeaponClass.WeaponType Type;
    public LayerMask magMask;

    public void OnGrab()
    {
        //when the mag is grabbed from a gun unload the weapon
        //disable all the rigibyody stuff

        //deparent it from the rifle
        transform.parent = null;
        //deslect da thingy
        //allow it to be droped into a reload point

        Debug.Log("GRAB");
    }
    public void OnDrop()
    {
        Debug.Log("DROP");
        GetComponent<Rigidbody>().isKinematic = false;

        LookForHost();
    }

    /// <summary>
    /// check to see if inside a mag anchor of the matching weapon type
    /// </summary>
    public void LookForHost()
    {
        //do a shepere cast for nearby mags if return true then attach mag to thingyyyyyyyyyyyyyyyyyy
        RaycastHit hit;
        Physics.SphereCast(transform.position, 0.3f,Vector3.zero,out hit,0.1f,magMask);

        Debug.Log("LOOKING FOR HOST");

        if (hit.collider != null && hit.collider.GetComponent<WeaponClass>() != null)
        {
            //I FOUND A MAG!!!!!!!! 
            //yippier
            Debug.Log("RAHHHHHHHH"); 

        }
    }



    //could add additional functionality such as bullet speed (this could also be in the bullet objects data)
}
