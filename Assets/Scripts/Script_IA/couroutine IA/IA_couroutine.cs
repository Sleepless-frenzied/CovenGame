using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
namespace classEnemyC 
{ 
public class IA_couroutine : MonoBehaviour 
{ 
    public Animator animator;  
    CapsuleCollider playerCollider; 
    Couroutinetroll troll; 
    void Start() 
    { 
        troll = gameObject.AddComponent<Couroutinetroll>(); 
        troll.SetTarget(null); 
        troll.SetAnimator(animator); 
        ((enemy_couroutine)troll).SetAttackRange(1); 
        ((enemy_couroutine)troll).SetMoveSpeed(3); 
        ((enemy_couroutine)troll).SetAttackDelay(3); 
        ((enemy_couroutine)troll).SetAttackDammage(0); 
        troll.StartCoroutine("CheckEntity");
    } 
    // Update is called once per frame 
    void Update() 
    { 
        if (Time.time>troll.GetAllow_action() && troll.GetTarget()!=null) 
        { 
            float Distance = Vector3.Distance(troll.transform.position,troll.GetTarget().transform.position);
            if (Distance>troll.GetFightingRange()) 
            { 
                troll.chase(); 
            } 
            else 
            { 
                if (Distance<=troll.GetAttackRange()) 
                { 
                    troll.attack(); 
                } 
                else 
                { 
                    if (troll.GetFight() && Distance<=troll.GetFightingRange()) 
                    { 
                        troll.StartCoroutine("fighting"); 
                    } 
                }     
            } 
        } 
        else 
        { 
            Vector3 Targetposition = new Vector3 (troll.GetTarget().transform.position.x, transform.position.y, troll.GetTarget().transform.position.z); 
            transform.LookAt (Targetposition); 
            transform.position=Vector3.MoveTowards(transform.position,troll.GetTarget().transform.position, 6*Time.deltaTime); 
        } 
    } 
} 
} 
