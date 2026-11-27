using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    //MainMenu script
    [Header("<color=red>Menu Open </color>")]
    public InputAction openMenu;
    public InputAction closeMenu;

    public Transform leftHand;
    public float distance;
    public LayerMask mask;

    public GameObject MenuObject;



    [Header("<color=blue>Menus  </color>")]
    [SerializeField] GameObject SecondaryMenu;
    private void Awake()
    {
        openMenu = InputSystem.actions.FindAction("RAHHHHHHHHHH");

        openMenu.performed += cxt => OpenMenu();

        closeMenu = InputSystem.actions.FindAction("RAHHHHHHHHHH");

        closeMenu.performed += cxt => CloseMenu();

    }


    //script called when the menu is open
    public void OpenMenu()
    {
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
        //enable the menu object linked to the players left hand (beacuse this game is for right handed people only!!!!!!!! fuck you leftiesss!!!!!!!!! im joking we love everyone <3 im just yapparoining)


        //enable menu object


        //when grab an 


    }
    public void CloseMenu()
    {
        MenuObject.SetActive(false);
        SecondaryMenu.SetActive(false);
    }


    public void GrabWeapon(GameObject Prefab)
    {
        //grab a weapon from the menu/enable a weapon
    }

    public void OpenSecondaryMenu()
    {
        MenuObject.SetActive(false);
        SecondaryMenu.SetActive(true);
    }

}
