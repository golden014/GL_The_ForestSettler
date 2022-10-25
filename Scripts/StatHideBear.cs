using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHideBear : MonoBehaviour
{
    public GameObject bear;
    public GameObject unityChan;
    public Canvas bearStat;
  
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(bear.transform.position, unityChan.transform.position) < 30 )
        {
            bearStat.enabled = true;
        } else
        {
            bearStat.enabled = false;
        }
    }
}
