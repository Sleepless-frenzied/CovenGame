using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
 namespace Coven 
{ 
public class PlayerStat : MonoBehaviour 
{ 
    public Coroutine coroutine;
    protected UnarmedCharacter player;
    protected bool isHiting;
    protected GameObject weapon;
    protected Animator animator;
    protected GameObject HitFrom;
    protected float death;
    protected int stability;
    protected float DOT_Time;
    protected int knockBack=10; 
    public int GetDamage() 
    { 
        return player.equipement.GetComponent<EquipmentManager>().currentEquipment[2].damageModifier; 
    } 
    public int GetKnockBack() 
    { 
        return knockBack; 
    } 
    public IEnumerator GetOverTime()
    {
        return OverTime();
    }
    public void SetDOT_Time(float time)
    {
        DOT_Time = time;
    }
    public void SetIsHiting(bool isHiting)
    {
        PlayerWeapon script = weapon.GetComponent<PlayerWeapon>();
        script.SetIsHiting(isHiting);
        script.SetPlayer(gameObject);
    }
    public void SetHitFrom(GameObject mob)
    {
        HitFrom = mob;
    }
    public void TakeDamage(int dammage,int KB) 
    { 
        player.health-=dammage;
        if (player.health<=0) 
        { 
            gameObject.tag = "dead";
            enemy_couroutine script = HitFrom.GetComponent<enemy_couroutine>(); 
            script.SetTarget(null);
            animator.SetBool("Dead",true);
            death = Time.time + 3;
        } 
        else 
        { 
            this.gameObject.GetComponent<Rigidbody>().AddForce(0,(KB-stability)/2,stability-KB,ForceMode.Impulse); 
        } 
    } 
    public void ApplyDamage(GameObject OurTarget) 
    { 
        OurTarget.SendMessage("TakeDamage",this); 
    } 
  
    void Start() 
    { 
        player = gameObject.GetComponent<UnarmedCharacter>();
        animator = gameObject.GetComponent<Animator>();
        weapon = player.Weapon;
        coroutine = StartCoroutine(OverTime());
    } 
    IEnumerator OverTime()
    {
        for (int i = 0; i < DOT_Time; i++)
        {
            yield return new WaitForSeconds(1);
        }
        player.status= Status.Healthy;
    }
    void Update()
    {
        if (tag=="dead" && death<=Time.time && GameObject.FindGameObjectsWithTag("Player").Length==0)
        {
            transform.position = (GameObject.FindGameObjectWithTag("Spawn")).transform.position;
            animator.SetBool("Dead",false);
            tag="Player";
            player.health = player.MaxHealth;
        }
        if(tag=="Player" && player.status==Status.Stunned)
        {
            animator.SetBool("Dead",true);
        }
        if (tag=="Player" && player.status!=Status.Stunned)
        {
            animator.SetBool("Dead",false);
        }
    }
} }
