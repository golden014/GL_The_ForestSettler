using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanAnimation : MonoBehaviour
{
    private Animator animator;

    private float lastTimeRoll;
    private float timeBetweenRoll = 1.05f;
    private bool currentlyRolling;

    public AudioSource punch1, weaponSwing1;

    //public PickUpController pickUpController;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        //pickUpController = GetComponent<PickUpController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.visible)
        {
            return;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(horizontal, 0, vertical).normalized;
      
        //
        if (dir.magnitude >= 0.1f)
        {

            if (dir.x != 0 && dir.z == 0)
            {
                animator.SetBool("isStrafing", true);
            } else
            {   
                animator.SetBool("isStrafing", false);
                animator.SetBool("isMoving", true);
                animator.SetBool("isIdleAnimation", false);

                if (Input.GetMouseButtonDown(1) && (Time.time - lastTimeRoll) > timeBetweenRoll && currentlyRolling == false)
                {
                    animator.SetBool("isRolling", true);
                    animator.SetBool("isMoving", false);
                    currentlyRolling = true;
                    lastTimeRoll = Time.time;
                }

                if ((Time.time - lastTimeRoll) > timeBetweenRoll && currentlyRolling == true)
                {
                    currentlyRolling = false;
                    animator.SetBool("isRolling", false);
                }
            } 

            animator.SetFloat("dirX", dir.x);
            animator.SetFloat("dirY", Mathf.Abs(dir.z));

            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("isStrafing", false);
                animator.SetBool("isMoving", false);

                if (PickUpController.full == true)
                {
                    animator.SetBool("isSwingingWeapon1", true);

                    weaponSwing1.Play();
                    Debug.Log("swinging weapon");

                } else
                {
                    animator.SetBool("isPunching1", true);
                    punch1.Play();
                    Debug.Log("punching"); 
                }
            }


           // animator.SetBool("isMoving", true);

        } else
        {
            //idle
            animator.SetBool("isMoving", false);
            animator.SetBool("isStrafing", false);
            animator.SetBool("isPunching1", false);
            animator.SetBool("isSwingingWeapon1", false);
            //animator.SetBool("isRolling", false);

            
            if (Input.GetMouseButtonDown(0))
            {
                if (PickUpController.full == true)
                {
                    animator.SetBool("isSwingingWeapon1", true);
                    weaponSwing1.Play();
                    Debug.Log("swinging weapon");
                }
                else
                {
                    animator.SetBool("isPunching1", true);
                    punch1.Play();
                    Debug.Log("punching");
                }
            }

        }
    }
}
