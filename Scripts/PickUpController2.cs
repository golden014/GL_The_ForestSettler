using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class PickUpController2 : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, weaponContainer;
    public Animator weaponAnimator;
    //public Canvas canvas;
    // public CanvasScript canvasScript;

    public bool equipped;
    //public static bool full;
    //public GameObject panel;
    CanvasController cvController;

    /*
    public static void showPopUpWeapon()
    {
       
        
        // panel.SetActive(true); 
        //GameObject.FindGameObjectWithTag("PickUpWeaponPopUpTag").GetComponent<Panw>
       // GameObject.FindGameObjectWithTag("PickUpWeaponPopUptag").GetComponent<Image>().enabled = true;
       // GameObject.FindObjectOfType<TextMeshProUGUI>().GetComponent<TextMeshProUGUI>().enabled = true;
        //GameObject.FindGameObjectWithTag("PickUpWeaponPopUptag").GetComponent<TextMeshProUGUI>().enabled = true;
    } 
     
    public static void hidePopUpWeapon() 
    {
       // canvas.
        GameObject.FindGameObjectWithTag("PickUpWeaponPopUptag").GetComponent<Image>().enabled = false;
        GameObject.FindObjectOfType<TextMeshProUGUI>().enabled = false;
        //GameObject.FindGameObjectWithTag("PickUpWeaponPopUptag").GetComponent<TextMeshProUGUI>().enabled = false;
    } */

    public float pickUpRange;
    private void Start()
    {
        cvController = CanvasController.canvasControllerSingleton;
        // panel = GetComponent<GameObject>();
        cvController.hideWeaponPopUp();
        //hidePopUpWeapon();
        //canvasScript = GetComponent(canvasScript )
        //canvas = GetComponent<Canvas>();
        weaponAnimator = GetComponent<Animator>();

        equipped = false;

        if (!equipped)
        {
            weaponAnimator.enabled = true;
            rb.isKinematic = false;
            coll.isTrigger = false;

        }

        if (equipped)
        {
            weaponAnimator.enabled = false;
            rb.isKinematic = true;
            coll.isTrigger = true;
        }
    }

    private void Update()
    {
        Vector3 distanceToUnityChan = player.position - transform.position;

        if (distanceToUnityChan.magnitude > pickUpRange)
        {
            Debug.Log("tidak didalam jarak, harusnya hide");
            cvController.hideWeaponPopUp();
            // hidePopUpWeapon();
        }


        if (!equipped && distanceToUnityChan.magnitude <= pickUpRange)
        {
            Debug.Log("masuk line 66");
            cvController.showWeaponPopUp();
            //showPopUpWeapon();
            //CanvasScript.pickUpWeaponPopUp.enabled = true; 
        }
        else if (equipped)
        {
            Debug.Log("masuk line 71");
            cvController.hideWeaponPopUp();
            //CanvasScript.pickUpWeaponPopUp.enabled = false;
        }


        if (!equipped && distanceToUnityChan.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !PickUpController.full)
        {
            //Debug.Log("aaaaaaaaa");
            pickUp();
        }

        if (equipped && Input.GetKeyDown(KeyCode.R))
        {
            drop();
        }

        if (equipped)
        {
            pickUp();
        }
    }

    private void pickUp()
    {
        //Debug.Log("masuk pickup");
        equipped = true;
        PickUpController.full = true;

        cvController.hideWeaponPopUp();

        //
        transform.SetParent(weaponContainer);
        transform.localPosition = Vector3.zero;
        //transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        

        weaponAnimator.enabled = false;
        rb.isKinematic = true;
        coll.isTrigger = true;
    }

    private void drop()
    {
        equipped = false;
        PickUpController.full = false;

        // showPopUpWeapon();

        weaponAnimator.enabled = true;
        rb.isKinematic = false;
        coll.isTrigger = false;
        transform.SetParent(null);
    }

    /* private void hidePanel(ArrayList listOfObjects)
     {
         foreach(UI object_ in listOfObjects)
         {
             object_.
         }
     }
    */



}



