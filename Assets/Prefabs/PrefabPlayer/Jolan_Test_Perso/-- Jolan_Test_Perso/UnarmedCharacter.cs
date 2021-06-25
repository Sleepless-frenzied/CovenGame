using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class UnarmedCharacter : MonoBehaviour
{
    //movement attributes
    public CharacterController controller;
    public float speed = 0f;
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //interact
    public LayerMask interactionMask;
    public Camera camInteract;
    protected Coven.PlayerStat playerStat;

    //jump attributes and gravity
    public bool isGrounded;
    public float airSpeed = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 6f;

    //fight attributes
    public GameObject Weapon;
    Animator animator;
    public bool isAttackPressed;
    bool lShiftPressed;
    bool jumpPressed;
    public float attackCooldown = 1;
    public float nextAttackTime = 1;
    public float celerity = 1;

    //generic attributes
    public float damagePower = 15;
    public float armorPower = 15;
    public float MaxHealth = 100;
    public float MaxMana = 100;
    public float health = 100;
    public float mana = 100;
    public Image healthBar;
    public Image manaBar;
    public GameObject equipement;
    public GameObject inventoryUI;
    public GameObject targetSpell;

    public Status status = Status.Healthy;

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Acting", false);
        playerStat = gameObject.GetComponent<Coven.PlayerStat>();
    }

    //[PunRPC]
    void Update()
    {
        
        //PV and Mana update
        healthBar.fillAmount = health / MaxHealth;
        manaBar.fillAmount = mana / MaxMana;
        mana += 0.05f;
        health = health > MaxHealth ? MaxHealth : health;
        mana = mana > MaxMana ? MaxMana : mana;
        health = health <= 0 ? 0 : health;
        mana = mana <= 0 ? 0 : mana;
             
        //Is grounded ??? and gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.DrawRay(groundCheck.position, transform.up * -0.5f, Color.red);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }    
        
        //si on est dans les airs ou pas
        if (isGrounded)      
            animator.SetBool("isInTheAir", false);      
        else
            animator.SetBool("isInTheAir", true);
        
        //show the weapon
        if (animator.GetInteger("Weapon") == 1)
            Weapon.SetActive(true);
        else
            Weapon.SetActive(false);
        
        //Change Weapon
        /*if (equipement.GetComponent<EquipmentManager>().currentEquipment[2] == null)
            animator.SetInteger("Weapon", 0);
        else
            animator.SetInteger("Weapon",(int) equipement.GetComponent<EquipmentManager>().currentEquipment[2].weapontype);*/
        
        
        //If in the inventory, you cannot do anything
        //
        //
        if (inventoryUI.activeSelf)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking",false);
            velocity.y = -2f;
            return;
        }
        
        lShiftPressed = Input.GetKeyDown(KeyCode.LeftShift);
        jumpPressed = Input.GetKeyDown(KeyCode.Space);
        isAttackPressed = Input.GetKeyDown(KeyCode.Mouse0);


        //saut
        if (jumpPressed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("Jump", true);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
        //roll
        if (lShiftPressed)
            animator.SetBool("Roll", true);
        else
            animator.SetBool("Roll", false);


        //run (and in air)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (isGrounded)    
                animator.SetBool("isRunning", true);
            else
                animator.SetBool("isRunning", false);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if (isGrounded)
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            else
                controller.Move(moveDir.normalized * airSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        

        //Attack
        if (Time.time > nextAttackTime)
            animator.SetBool("CanAttack",true);
        else
            animator.SetBool("CanAttack",false);

        if (isAttackPressed && isGrounded && Time.time > nextAttackTime)
        {
            //playerStat.SetIsHiting(true);
            animator.SetInteger("Attack_NB", Random.Range(0, 6));
            
            animator.SetBool("isAttacking",true);
            nextAttackTime = Time.time + attackCooldown;
        }
        else
        {
            animator.SetBool("isAttacking",false);
        }

        
        

        //ToInteractWith object
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = camInteract.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
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
public enum Status
{
    Healthy,
    Poisoned,
    Burned,
    Stunned,
}