using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
namespace Coven
{ 
public class IA_Hob : MonoBehaviour 
{ 
    public Animator animator; 
    public GameObject Weapon;
    CapsuleCollider playerCollider; 
    IA_Hob_Code Hob; 
    void Start() 
    { 
        Hob = gameObject.AddComponent<IA_Hob_Code>(); 
        Hob.SetTarget(null); 
        Hob.SetAnimator(animator);
        Hob.SetWeapon(Weapon);
        ((enemy_couroutine)Hob).SetAttackRange(2); 
        ((enemy_couroutine)Hob).SetMoveSpeed(3); 
        ((enemy_couroutine)Hob).SetAttackDelay(1); 
        ((enemy_couroutine)Hob).SetAttackDammage(15);
        ((enemy_couroutine)Hob).SetHealth(100);
        Hob.StartCoroutine("CheckEntity");
    } 
    // Update is called once per frame 
    void Update() 
    { 
        if (Time.time>Hob.GetAllow_action()) 
        { 
            if (Hob.GetTarget()!=null)
            {
            float Distance = Vector3.Distance(Hob.transform.position,Hob.GetTarget().transform.position);
            if (Distance>Hob.GetFightingRange()) 
            { 
                Hob.chase(); 
            } 
            else 
            { 
                if (Distance<=Hob.GetAttackRange()) 
                { 
                    Hob.attack(); 
                } 
                else 
                { 
                    if (Hob.GetFight() && Distance<=Hob.GetFightingRange()) 
                    { 
                        Hob.StartCoroutine("fighting"); 
                    } 
                }     
            } }
        } 
        else 
        { 
            if (Hob.GetTarget()!=null)
            {
                Vector3 Targetposition = new Vector3 (Hob.GetTarget().transform.position.x, transform.position.y,Hob.GetTarget().transform.position.z); 
                transform.LookAt (Targetposition); 
                transform.position=Vector3.MoveTowards(transform.position,Hob.GetTarget().transform.position, 6*Time.deltaTime); 
            }
        }
    } 
}
}