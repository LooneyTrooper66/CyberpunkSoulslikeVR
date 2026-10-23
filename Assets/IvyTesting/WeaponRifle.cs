using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WeaponRifle : WeaponClass
{
    [Header("Rifle")]
    public Collider Body;
    public XRGrabInteractable magInteractable;

    public override void OnEmpty()
    {
        base.OnEmpty();
        //mag.enabled = true;

    }

    public override void OnPickUp()
    {
        base.OnPickUp();
        Body.enabled = false;

        if (magInteractable != null) 
        { 
            magInteractable.enabled = true;
        }

        //deselect the mag from the rifle on grab

    }

    public override void OnDrop()
    {
        base.OnDrop();
        //disabkle grabbing the mag
        Body.enabled = true;

        if (magInteractable != null)
        {
            magInteractable.enabled = false;
        }

    }
}
