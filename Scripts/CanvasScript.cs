using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    //public Animator a;
    public  static Image pickUpWeaponPopUp;

    private void Start()
    {  
        Debug.Log("masuk start");
       // a = GetComponent<Animator>();
        pickUpWeaponPopUp = GetComponent<Image>();
    }
}
