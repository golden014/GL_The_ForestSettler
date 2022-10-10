using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private CharacterController charController;

    //supaya bisa diganti di unity nya tapi ttp private
   
    //2.5f
    private float defaultSpeed = 2.5f;

    [SerializeField]
    private float speed = 0;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform cam;

    [SerializeField]
    private Animator animator;

    private float gravity = 9.8f;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //simpan input ke vector
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 moveDir = new Vector3();

        //kalau ada gerakan
        if (direction.magnitude >= 0.1f)
        {
            if(animator.GetBool("isMoving"))
            {
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    this.speed = defaultSpeed + 2f;
                } else
                {
                    this.speed = defaultSpeed;
                }
            }

            //arah liat
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //supaya ga patah2 mutar nya
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir = moveDir.normalized;

            //
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            charController.Move(moveDir.normalized * speed * Time.deltaTime);


        }

        moveDir.y += (gravity * -1);
        moveDir.x *= speed;
        moveDir.z *= speed;

        charController.Move(moveDir * Time.deltaTime);

        
    }
}
