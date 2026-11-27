using UnityEngine;
using System.Collections;

// Jordan/Libby Script\\
public class TileLogic : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth; // change this reference to player health script later
    [SerializeField] float damageDeals;
    public bool playerOnTile = false;
    MeshRenderer thisRenderer;
    float lerpTime;
    bool lerpColour = false;
    Color colourToLerpTo = Color.white;


    private void Start()
    {
        thisRenderer = gameObject.GetComponent<MeshRenderer>();
        lerpTime = 0;
    }

    private void Update()
    {
        if (lerpColour)
        {
            lerpTime += Time.deltaTime * 0.02f;
            Color newColour = Color.Lerp(thisRenderer.material.color, colourToLerpTo, lerpTime);
            thisRenderer.material.color = newColour;
            thisRenderer.material.SetColor("_EmissionColor", newColour);
            if (thisRenderer.material.color == colourToLerpTo) lerpColour = false;
        }
    }

    // using on trigger stay to prevent issues due to teleportation movement (hoping doesn't effect onTriggerExit)
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) playerOnTile = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) playerOnTile = false;
    }

    public void LerpColourToRed()
    {
        colourToLerpTo = Color.red;
        lerpColour = true; lerpTime = 0;
    }
    void LerpColourToWhite()
    {
        colourToLerpTo = Color.white;
        lerpColour = true; lerpTime = 0;
    }

    public void TileHit()
    {
        LerpColourToWhite();
        // damage player if on tile
        if (playerOnTile) playerHealth.GetComponent<IDamageable>().TakeDamage(damageDeals);
    }
}
