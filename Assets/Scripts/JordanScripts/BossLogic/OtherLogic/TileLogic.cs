using UnityEngine;
using System.Collections;

// Jordan/Libby Script\\
public class TileLogic : MonoBehaviour
{
    [SerializeField] GameObject player; // change this reference to player health script later
    [SerializeField] float damageDeals;
    public bool playerOnTile = false;
    MeshRenderer thisRenderer;
    bool lerpColour = false;
    Color colourToLerpTo = Color.white;


    private void Start()
    {
        thisRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (lerpColour)
        {
            Color newColour = Color.Lerp(thisRenderer.material.color, colourToLerpTo, Time.deltaTime * 4);
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
        lerpColour = true;
    }
    void LerpColourToWhite()
    {
        colourToLerpTo = Color.white;
        lerpColour = true;
    }

    public void TileHit()
    {
        LerpColourToWhite();
        // damage player if on tile
        if (playerOnTile) player.GetComponent<IDamageable>().TakeDamage(damageDeals);
    }
}
