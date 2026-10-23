using UnityEngine;

public class GetAmmo : MonoBehaviour
{
    public bool GetAmmoDebug;

    private void Update()
    {
        if (GetAmmoDebug) { GetAmmoDebug = false;GrabAmmo(); }
    }

    public static GetAmmo Instance;
    private void Start() {  Instance = this; }

    public WeaponClass WeaponClass;


    public void GrabAmmo()
    {
        //spawn weaponcla
        Instantiate(WeaponClass.magModel); 


        //link it to the hand that the player grabbed it with

        //other bits
    }
}
