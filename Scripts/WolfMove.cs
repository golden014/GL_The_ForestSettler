using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class WolfMove : MonoBehaviour
{

    public NavMeshAgent nmAgent;
    public GameObject unityChan;
    public Animator nmAnimator;
    private int timer = 10;
    // public 


    // Start is called before the first frame update
    void Start()
    {
        nmAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nmAgent.GetComponent<WolfStat>().isAlive == true)
        {
            if (Vector3.Distance(nmAgent.transform.position, unityChan.transform.position) < 30 && Vector3.Distance(nmAgent.transform.position, unityChan.transform.position) > 3)
            {
                nmAnimator.SetBool("WalkForward", false);
                nmAnimator.SetBool("RunForward", true);
                nmAgent.SetDestination(unityChan.transform.position);
                Debug.Log("run forward berjalan -> dalam range ngejar");
            }

            if (timer == 0 && Vector3.Distance(nmAgent.transform.position, unityChan.transform.position) > 30)
            {
                nmAnimator.SetBool("WalkForward", true);
                nmAnimator.SetBool("RunForward", false);
                nmAgent.SetDestination(new Vector3(nmAgent.transform.position.x + Random.Range(-10, 10), nmAgent.transform.position.y + Random.Range(-10, 10), nmAgent.transform.position.z + Random.Range(-10, 10)));
                Debug.Log("walk forward berjalan -> tidak dalam range ngejar");

                timer = 50;
            }
            timer = timer - 1;
        }
        else if (nmAgent.GetComponent<WolfStat>().isAlive == false)
        {
            nmAnimator.SetBool("WalkForward", false);
            nmAnimator.SetBool("RunForward", false);
        }
    }
}
