using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearMove : MonoBehaviour
{

    public NavMeshAgent nmAgent;
    public GameObject unityChan;
    private int timer = 10;
   // public 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(nmAgent.transform.position, unityChan.transform.position) < 50 && Vector3.Distance(nmAgent.transform.position, unityChan.transform.position) > 3)
        {
            nmAgent.SetDestination(unityChan.transform.position);
        } 

        if (timer == 0 && Vector3.Distance(nmAgent.transform.position, unityChan.transform.position) > 50)
        {
            
            nmAgent.SetDestination(new Vector3(nmAgent.transform.position.x + Random.Range(-10, 10), nmAgent.transform.position.y + Random.Range(-10, 10), nmAgent.transform.position.z + Random.Range(-10, 10)));
             
            timer = 50;
        }
        timer = timer - 1;
    }
}
