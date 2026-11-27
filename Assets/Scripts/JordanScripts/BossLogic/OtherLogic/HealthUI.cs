using UnityEngine;
using UnityEngine.UI;

// Jordan/Libby Script\\
public class HealthUI : MonoBehaviour
{
    [SerializeField] BossBase bossBase;
    [SerializeField] Slider healthBar;
    [SerializeField] Transform playerCam;
    Quaternion ogRotation;


    private void Start()
    {
        ogRotation = transform.rotation;
    }

    // i know it would be better to do this as a call when the enemy takes damage
    // but i dont have time to implement that right now (the project is due in a week and i still have so much to do)
    private void Update()
    {
        // health bar
        healthBar.value = bossBase.currentHealth / bossBase.maxHealth;

        // make sure ui is always facing player
        transform.LookAt(playerCam);
        //transform.rotation = playerCam.rotation * ogRotation;
    }
}
