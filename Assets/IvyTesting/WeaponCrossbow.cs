using UnityEngine;

public class WeaponCrossbow : WeaponClass
{
    [Header("Core")]
    [SerializeField] bool Ammo;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public override void Fire()
    {
        Debug.Log("Shoot");
    }
}
