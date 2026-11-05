using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SnapOpenShotgun : MonoBehaviour
{
    public Transform rotationPoint;
    public float OpenAngle;
    public ReloadPoint reload;
    public bool isOpen;
    public WeaponShotgun gun;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Open()
    {
        if (isOpen == false)
        {
            rotationPoint.localRotation = Quaternion.Euler(0, 0, OpenAngle);
            isOpen = true;
            reload.enabled = true;

            //also disable grabbing the bullets
            if (gun.mag != null) { gun.mag.gameObject.GetComponent<XRGrabInteractable>().enabled = true; }
            if (gun.secondaryMag != null) { gun.secondaryMag.gameObject.GetComponent<XRGrabInteractable>().enabled = true; }

        }
        else
        {
            rotationPoint.localRotation = Quaternion.Euler(0, 0, 0);
            isOpen = false;
            reload.enabled = false;

            if (gun.mag != null) { gun.mag.gameObject.GetComponent<XRGrabInteractable>().enabled = false; } 
            if (gun.secondaryMag != null) { gun.secondaryMag.gameObject.GetComponent<XRGrabInteractable>().enabled = false; }
        }
    }

    public void ForceClose()
    {
        rotationPoint.localRotation = Quaternion.Euler(0, 0, 0);
        isOpen = false;
        reload.enabled = false;
        if (gun.mag != null) { gun.mag.gameObject.GetComponent<XRGrabInteractable>().enabled = false; }
        if (gun.secondaryMag != null) { gun.secondaryMag.gameObject.GetComponent<XRGrabInteractable>().enabled = false; }
    }
}
