using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    public GameObject enemy, unityChan;
    public SliderController HPSlider;
    private float delayInSeconds = 0;

    private static Animator animator;

    private void Start()
    {

        animator = GetComponent<Animator>();

    }

    private void Update()
    {
       
        if (enemy && Vector3.Distance(enemy.transform.position, unityChan.transform.position) < 3)
        {

            if(delayInSeconds >= 2)
            {

                enemy.GetComponent<Animator>().SetTrigger("Attack1");
                delayInSeconds = 0;

            }

            delayInSeconds += Time.deltaTime;
        
        }

    }

    public static void die()
    {

        animator.SetTrigger("Die");

    }

}
