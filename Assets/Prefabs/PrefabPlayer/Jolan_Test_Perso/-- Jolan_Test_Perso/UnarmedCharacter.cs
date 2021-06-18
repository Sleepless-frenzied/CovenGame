using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnarmedCharacter : MonoBehaviour
{
    public GameObject Weapon;
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

        //show the weapon
        if (animator.GetInteger("Weapon") == 1)

            Weapon.SetActive(true);
        else
            Weapon.SetActive(false);

     
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
            animator.SetInteger("Attack_NB", Random.Range(0, 6));
            animator.SetTrigger("Attack");

        }
        


    }
}
