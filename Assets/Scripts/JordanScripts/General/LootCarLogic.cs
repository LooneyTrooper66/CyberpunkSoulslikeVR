using UnityEngine;

// Jordan/Libby Script\\
public class LootCarLogic : MonoBehaviour
{
    [SerializeField] GameObject carClosed;
    [SerializeField] GameObject carOpen;


    public void OpenCar()
    {
        // change colliders to allow player to grab stuff from car
        // open car door
        // spawn guns/ammo
        carClosed.SetActive(false);
        carOpen.SetActive(true);
    }
}
