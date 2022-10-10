using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public static CanvasController canvasControllerSingleton = null;
   [SerializeField]
    public GameObject canvas;
   [SerializeField]
    public GameObject weaponPopUpPanel;


    private void Awake() 
    {
        if (canvasControllerSingleton == null)
        {
            canvasControllerSingleton = this; 
        }

    }

    private void Start()
    {
        //canvasControllerSingleton = new CanvasController();
        Debug.Log("start canvas controller");
        // canvas = GetComponent<GameObject>();
        // weaponPopUpPanel = GameObject.Find("WeaponPopUpPanel").GetComponent<GameObject>();
        Debug.Log(weaponPopUpPanel.name);
        //Debug.Log()
    }



    public void hideWeaponPopUp()
    {
        Debug.Log("inside hide weapon pop up");
        weaponPopUpPanel.SetActive(false);
    }

    public void showWeaponPopUp()
    {
        Debug.Log("inside show weapon pop up");
        weaponPopUpPanel.SetActive(true);
    }

    public CanvasController()
    {

    }

  //  public static CanvasController getInstance()
  //  {
       // if (canvasControllerSingleton == null)
       // {
            //canvasControllerSingleton = new CanvasController();
       // }

  //      return canvasControllerSingleton;
  //  }
}
