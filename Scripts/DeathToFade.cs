using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathToFade : MonoBehaviour
{
    public Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void fadeAfterDeath()
    {
        animator.SetBool("isDead", true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
