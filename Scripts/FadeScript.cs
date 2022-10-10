using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        
    }

    public void startAnimate()
    {
        animator.SetBool("StartClicked", true);
    }

   
}
