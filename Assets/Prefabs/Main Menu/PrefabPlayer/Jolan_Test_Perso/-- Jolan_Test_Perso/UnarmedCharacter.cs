
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;
public class UnarmedCharacter : MonoBehaviourPunCallbacks
{



    public Camera cam;
    //public Interactable focus;
    

    public LayerMask interactionMask;



    
    CapsuleCollider playerCollider;
    Animator animator;
    public bool isGrounded;
    public Vector3 jumpHigh;
    public float turnSpeed;
    public bool isAttackPressed;
    public bool isAttacking;
    bool forwardPressed;
    bool lShiftPressed;
    bool jumpPressed;
    bool backwardPressed;
    bool turnLeft;
    bool turnRight;
    public int airSpeed;

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Acting", false);
        if (!photonView.IsMine)
        {
            this.enabled = false;
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == default) isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == default) isGrounded = true;
    }

    void Update()
    {
        forwardPressed = Input.GetKey(KeyCode.Z);
        lShiftPressed = Input.GetKey(KeyCode.LeftShift);
        jumpPressed = Input.GetKeyDown(KeyCode.Space);
        backwardPressed = Input.GetKey(KeyCode.S);
        turnLeft = Input.GetKey(KeyCode.Q);
        turnRight = Input.GetKey(KeyCode.D);
        isAttackPressed = Input.GetKeyDown(KeyCode.Mouse0);

        if (animator.GetInteger("Weapon") == 0)
        {
            //roll
            if (lShiftPressed)
                animator.SetBool("Roll", true);
            else
                animator.SetBool("Roll", false);


            //run
            if (forwardPressed && !backwardPressed)
            {
                animator.SetBool("isRunning", true);
                if (!isGrounded)
                {
                    transform.Translate(0, 0, airSpeed * Time.deltaTime);
                }
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            //back
            if (backwardPressed && !forwardPressed)
            {
                animator.SetBool("isBack", true);
                if (!isGrounded)
                {
                    transform.Translate(0, 0, -airSpeed * Time.deltaTime);
                }
            }
            else
            {
                animator.SetBool("isBack", false);
            }



            // Rotation à gauche
            if (turnLeft)
            {
                transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            }

            // Rotation à droite
            if (turnRight)
            {
                transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            }


            //saut
            if (jumpPressed && isGrounded)
            {
                Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
                v.y = jumpHigh.y;

                animator.SetBool("Jump", true);
                gameObject.GetComponent<Rigidbody>().velocity = jumpHigh;
            }

            //si on est dans les airs ou pas
            if (isGrounded)
            {
                animator.SetBool("isInTheAir", false);
            }
            else
            {
                animator.SetBool("isInTheAir", true);
            }

            //Attack
            if (isAttackPressed && isGrounded)
            {
                animator.SetInteger("Attack_NB", Random.Range(0, 5));
                animator.SetTrigger("Attack");

            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
            RaycastHit hit;
            Debug.DrawRay(cam.transform.position,new Vector3(Screen.width/2,Screen.height/2,0));
            if (Physics.Raycast(ray, out hit, 100,interactionMask))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    Debug.Log("test");
                    interactable.Interact();
                }
            }
        }
    }
}
