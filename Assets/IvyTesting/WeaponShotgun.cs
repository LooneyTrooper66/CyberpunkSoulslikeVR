using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WeaponShotgun : WeaponClass
{
    public Magazine secondaryMag;
    public Transform secondaryEjectHole;
    public Transform secondaryLockedPoint;
    public XRSimpleInteractable SnapPoint;
    //scatter bullets
    public Vector2 offsetDir;


    public override void Fire()
    {
        if (mag.ammo != 0) {
            FireLoop(mag,EjectHole);
        }
        else if (secondaryMag.ammo != 0)
        {
            FireLoop(secondaryMag,secondaryEjectHole);
        }
    }


    public override void OnPickUp()
    {
        SnapPoint.enabled = true;
    }
    public override void OnDrop()
    {
        SnapPoint.enabled = false;
        SnapPoint.gameObject.GetComponent<SnapOpenShotgun>().ForceClose();
    }

    public override void Unload(Magazine magazine)
    {
        //find what mag was grabbed and unload it!!!
        if (magazine == mag)
        { mag = null; }
        else
        { secondaryMag = null; }

        UpdateText();

    }


    //custom Reload for dule mags

    public override void Reload(Magazine Mag)
    {
        if (mag == null)
        {
            mag = Mag;
        }
        else if (secondaryMag == null)
        {
            secondaryMag = Mag;
        }
        UpdateText();
    }

    //whent the gun is snapped open fire the shells backwards
    void EjectMags()
    {
        if (mag.ammo == 0)
        {
            //discoonect the mag and launch it backwards




            mag = null;
        }


        if (secondaryMag.ammo == 0)
        {

            secondaryMag = null; 
        }
    }

    private void UpdateText()
    {
        string slot1 = "X";
        string slot2 = "X";

        if (mag != null && mag.ammo > 0) { slot1 = "O"; }
        if (secondaryMag != null && secondaryMag.ammo > 0) { slot2 = "O"; }

        ammoVisuliser.text = $"{slot1}|{slot2} ";
    }


    public override bool IsAvaiableMagSlot(WeaponType MagType)
    {
        if (MagType != type) { return false; }
        if (mag == null || secondaryMag == null) { return true; }
        return false;
    }
    public override Transform LockedPoint()
    {
        if (mag == null)
        {
            return MagLockedPoint;
        }
        else 
        {
            return secondaryLockedPoint;
        }
    }


    void FireLoop(Magazine Shot, Transform ejectHole)
    {
        particalSystem.Play();
        for (int i = 0; i < Shot.magSize; i++)
        {
            GameObject bullet = Instantiate(Shot.bulletObj);


            bullet.transform.position = ejectHole.position;
            Vector3 RandomOffset = new Vector3(EjectHole.forward.x + Random.Range(-offsetDir.x, offsetDir.x), EjectHole.forward.y + Random.Range(-offsetDir.y, offsetDir.y), EjectHole.forward.z);

            bullet.GetComponent<Rigidbody>().linearVelocity = RandomOffset * bulletSpeed;
            //discard that weapon!!!!!!!!!!!!!
        }
        Shot.ammo = 0;
        UpdateText();
        //UPDATE THE AMMO VISULIERS
    }
}
