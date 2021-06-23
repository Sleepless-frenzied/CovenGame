using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
 namespace classEnemyC 
{ 
public class PlayerStat : MonoBehaviour 
{ 
    protected Animator animator;
    protected GameObject HitFrom;
    public GameObject Healthbar;
    protected int health=100; 
    protected int damage; 
    protected float death;
    protected int allow_attack; 
    protected int stability; 
    protected int knockBack=10; 
    public int GetDamage() 
    { 
        return damage; 
    } 
    public int GetKnockBack() 
    { 
        return knockBack; 
    } 
    public void SetHitFrom(GameObject mob)
    {
        HitFrom = mob;
    }
    public void TakeDamage(int dammage,int KB) 
    { 
        health-=dammage; 
        if (health<=0) 
        { 
            //joue l'animation de mort ou qqchose
            gameObject.tag = "dead";
            enemy_couroutine script = HitFrom.GetComponent<enemy_couroutine>(); 
            script.SetTarget(null);
            animator.SetBool("Dead",true);
            death = Time.time + 4;
        } 
        else 
        { 
            this.gameObject.GetComponent<Rigidbody>().AddForce(0,(KB-stability)/2,stability-KB,ForceMode.Impulse); 
        } 
    } 
    public void OnCollisionEnter(Collision collision) 
    { 
        if (/*bool anim attack is true*/true && collision.gameObject.tag=="mob") 
        { 
            ApplyDamage(collision.gameObject); 
        } 
    } 
    public void ApplyDamage(GameObject OurTarget) 
    { 
        OurTarget.SendMessage("TakeDamage",this); 
    } 
 
    // Update is called once per frame 
    void Start() 
    { 
        animator = gameObject.GetComponent<Animator>();
    } 
    void Update()
    {
        if (tag=="dead" && death<=Time.time)
        {
            transform.position = (GameObject.FindGameObjectWithTag("Spawn")).transform.position;
            animator.SetBool("Dead",false);
            tag="Player";
            health = 100;
        }
    }
} }
