using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFadeScript : MonoBehaviour
{

    public Animator animator;
    public void Start()
    {

    }

    public void startAnimateText()
    {
        animator.SetBool("StartClickedText", true);
    }
}
