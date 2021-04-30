using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class AnimationStateController : MonoBehaviourPunCallbacks
{
    Animator animator;

    public Camera cam;
    //public Interactable focus;
    

    public LayerMask interactionMask;
    //private Camera cam;
    // Movement speed
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;
    public Vector3 jumpSpeed;

    CapsuleCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        //cam = Camera.main;
        animator = GetComponent<Animator>();

        if (!photonView.IsMine)
        {
            this.enabled = false;
            cam.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/

        bool isBacking = animator.GetBool("isBackward");
        bool isRunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");
        bool forwardPressed = Input.GetKey(KeyCode.Z);
        bool lShiftPressed = Input.GetKey(KeyCode.LeftShift);
        bool backwardPressed = Input.GetKey(KeyCode.S);
        bool turnLeft = Input.GetKey(KeyCode.Q);
        bool turnRight = Input.GetKey(KeyCode.D);
        

        // On avance avec Z
        if (!isRunning && forwardPressed)
        {
            animator.SetBool("isWalking", true);
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
        }
        else if (isWalking && !forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }

        // On cours avec Z et shift
        if(lShiftPressed && forwardPressed)
        {
            animator.SetBool("isRunning", true);
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
        }
        else if (!lShiftPressed || !forwardPressed)
        {
            animator.SetBool("isRunning", false);
        }

        // Recule
        if (!isRunning && backwardPressed)
        {
            animator.SetBool("isBackward", true);
            transform.Translate(0, 0, -(walkSpeed/2) * Time.deltaTime);
        }
        else if (!backwardPressed)
        {
            animator.SetBool("isBackward", false);
        }

        // Rotation à gauche
        if(turnLeft)
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }

        // Rotation à droite
        if(turnRight)
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
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
