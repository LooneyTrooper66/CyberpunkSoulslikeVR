using System.ComponentModel;
using TMPro;
using UnityEngine;

public abstract class WeaponClass : MonoBehaviour
{
    [Header("Debug")]
    public bool fire;
    public bool reload;
    public bool pickUp;

    //VARIABLEA
    [Header("Ammo")]
    public GameObject magModel;
    public Magazine mag; //the current mag the weapon is using

    [Header("Bullets")]
    public float fireRate; 
    public Transform EjectHole; //where the bullets get ejectedd
    public float bulletSpeed;

    [Header("Visual")]
    public ParticleSystem particalSystem;
    public TMP_Text ammoVisuliser;

    public enum WeaponType
    { Rifle, Shotgun, Crossbow }


    private void Update()
    {
        if (fire) { fire = false; Fire(); }
        if (reload && mag != null) { reload = false; Reload(mag); }
        if (pickUp) { pickUp = false; OnPickUp(); }
    }

    public virtual void Fire()
    {
        if (mag == null || mag.ammo <= 0) { return; } //could also play a no ammo noise

        mag.ammo -= 1;
        if (mag.ammo == 0) { OnEmpty(); }

        particalSystem.Play();
        ammoVisuliser.text = ($"{mag.ammo}\n---\n{mag.magSize}");
        //onfire
        GameObject bullet = Instantiate(mag.bulletObj);
        bullet.transform.position = EjectHole.position;
        bullet.GetComponent<Rigidbody>().linearVelocity = EjectHole.forward * bulletSpeed;
        //spawn Buttle
    }

    public virtual void OnEmpty()
    {
        //for most weapons this will enable the ability to grab the mag discard it and get a new one
    }

    public virtual void AltFire() { }

    public virtual void Reload(Magazine Mag) //if the weapon uses special ammo types
    {
        mag = Mag;
        ammoVisuliser.text = ($"{Mag.ammo}\n---\n{Mag.magSize}");
    }
    public virtual void Unload()
    {
        ammoVisuliser.text = ($"{0}\n---\n{0}");
        mag = null;
    }

    public virtual void OnPickUp()
    {
        //onpickup set this weapon as primary weapon
        //when grabbing ammo bag grab ammo for this weapon
        GetAmmo.Instance.WeaponClass = this;
    }

    public virtual void OnDrop()
    {
        GetAmmo.Instance.WeaponClass = null;
    }
}
