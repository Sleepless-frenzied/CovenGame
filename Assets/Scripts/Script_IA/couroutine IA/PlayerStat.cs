using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
 namespace Coven 
{ 
public class PlayerStat : MonoBehaviour 
{ 
    protected UnarmedCharacter player;
    protected float health;
    protected bool isHiting;
    protected GameObject weapon;
    protected Animator animator;
    protected GameObject HitFrom;
    protected float death;
    protected int stability; 
    protected int knockBack=10; 
    public int GetDamage() 
    { 
        return player.equipement.GetComponent<EquipmentManager>().currentEquipment[2].damageModifier; 
    } 
    public int GetKnockBack() 
    { 
        return knockBack; 
    } 
    public void SetIsHiting(bool isHiting)
    {
        this.isHiting = isHiting;
    }
    public void SetHitFrom(GameObject mob)
    {
        HitFrom = mob;
    }
    public void TakeDamage(int dammage,int KB) 
    { 
        health-=dammage;
        player.health = health;
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
        player = gameObject.GetComponent<UnarmedCharacter>();
        animator = gameObject.GetComponent<Animator>();
        weapon = player.Weapon;
        health = player.MaxHealth ; 
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
