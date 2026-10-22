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
        mag.enabled = true;

    }

    public override void OnPickUp()
    {
       base.OnPickUp();
        //enable the mag obj
        Debug.Log("rifel pickuo");
        Body.enabled = false;
        magInteractable.enabled = true;

    }

    public override void OnDrop()
    {
        base.OnDrop();
        Debug.Log("rifel drop");
        //disabkle grabbing the mag
        Body.enabled = true;
        magInteractable.enabled = false;

    }
}
