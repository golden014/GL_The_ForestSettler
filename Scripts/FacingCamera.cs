using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCamera : MonoBehaviour
{

    public Camera cam;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.forward);  
    }


}
