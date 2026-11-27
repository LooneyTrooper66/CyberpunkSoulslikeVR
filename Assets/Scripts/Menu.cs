using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Menu : MonoBehaviour
{
    //MainMenu script
    [Header("<color=red>Menu Open </color>")]
    InputAction openMenu;
    InputAction closeMenu;
    bool MenuState;
    public Transform leftHand;
    public float distance;
    public LayerMask mask;

    public GameObject MenuObject;



    [Header("<color=blue>Menus  </color>")]
    [SerializeField] GameObject SecondaryMenu;
    private void Awake()
    {
        //openMenu = InputSystem.actions.FindAction("RAHHHHHHHHHH");

        //openMenu.performed += cxt => ToggleMenu();


    }


    //script called when the menu is open
    public void ToggleMenu()
    {
        if (MenuState == true) { CloseMenu(); return; }
        MenuState = true;
        RaycastHit hit;
        Physics.Raycast(leftHand.position, leftHand.forward, out hit ,distance, mask, QueryTriggerInteraction.Ignore);

        if(hit.point == null)
        {
            //spawn it a fixed distance forward
            MenuObject.transform.position = leftHand.position + (leftHand.transform.forward * distance);
        }
        else
        {
            MenuObject.transform.position = Vector3.Lerp(leftHand.transform.position, hit.point, 0.75f);
        }
        MenuObject.transform.LookAt(leftHand.transform.position);

        MenuObject.SetActive(true);
    }
    public void CloseMenu()
    {
        MenuState = false;
        MenuObject.SetActive(false);
        SecondaryMenu.SetActive(false);
    }


    public void GrabWeapon(GameObject Prefab)
    {
        //no idea how to spawn a weapon in the players hands
        GameObject Spawned = Instantiate(Prefab);
        Spawned.transform.position = this.transform.position;
        Spawned.GetComponent<XRGrabInteractable>().IsSelectedByRight();

        //grab a weapon from the menu/enable a weapon
    }

    public void OpenSecondaryMenu()
    {
        MenuObject.SetActive(false);
        SecondaryMenu.SetActive(true);
    }

}
