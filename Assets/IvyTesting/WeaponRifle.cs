using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WeaponRifle : WeaponClass
{
    [Header("Rifle")]
    public Collider Body;
    public override void OnEmpty()
    {
        base.OnEmpty();
        //mag.enabled = true;

    }

    public override void OnPickUp()
    {
        base.OnPickUp();
        Body.enabled = false;

        if (mag != null) 
        { 
            mag.GetComponent<XRGrabInteractable>().enabled = true;
        }

        //deselect the mag from the rifle on grab

    }

    public override void OnDrop()
    {
        base.OnDrop();
        //disabkle grabbing the mag
        Body.enabled = true;

        if (mag != null)
        {
            mag.GetComponent<XRGrabInteractable>().enabled = false;
        }

    }
}
