using UnityEngine;

public class Magazine : MonoBehaviour
{
    [Header("base")]
    public WeaponClass loadedWeapon; //the weapon this mag is loaded into
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
        //deslect da thingy
        //allow it to be droped into a reload point

        Debug.Log("GRAB");
        if (loadedWeapon != null)
        {
            loadedWeapon.Unload();
            loadedWeapon.mag = null;
            loadedWeapon = null;

        }
    }
    public void OnDrop()
    {
        Debug.Log("DROP");

        LookForHost();
        
    }

    /// <summary>
    /// check to see if inside a mag anchor of the matching weapon type
    /// </summary>
    public void LookForHost()
    {
        //do a shepere cast for nearby mags if return true then attach mag to thingyyyyyyyyyyyyyyyyyy
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 0.1f,Vector3.forward,0.1f,magMask);
        Debug.Log("LOOKING FOR HOST");
        Debug.Log(hits.Length);

        foreach (RaycastHit hit in hits)
        {
            Debug.Log(hit.collider.name);

            if (hit.collider != null && hit.collider.GetComponent<ReloadPoint>() != null && hit.collider.GetComponent<ReloadPoint>().attachedWeapon.mag == null && hit.collider.GetComponent<ReloadPoint>().magType == Type)
            {
                //I FOUND A MAG!!!!!!!! 
                //yippier
                loadedWeapon = hit.collider.GetComponent<ReloadPoint>().attachedWeapon;
                loadedWeapon.Reload(this);

                this.transform.position = hit.collider.GetComponent<ReloadPoint>().LockedPoint.position;
                this.transform.rotation = hit.collider.GetComponent<ReloadPoint>().LockedPoint.rotation;
                transform.parent = loadedWeapon.gameObject.transform; 
                //set the postion of this magasie
                Debug.Log("RAHHHHHHHH");
                GetComponent<Rigidbody>().isKinematic = true;
                return;
            }
            else { transform.parent = null; Debug.Log("NOTHING FOUNDs"); }
        }
    }



    //could add additional functionality such as bullet speed (this could also be in the bullet objects data)
}
