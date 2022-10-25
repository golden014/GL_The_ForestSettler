using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasControllerEndScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void exitForestSettler()
    {

        Application.Quit();
        Debug.Log("is quitting");
    }
}
