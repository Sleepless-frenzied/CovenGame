using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
namespace classEnemyC 
{ 
public class IA_couroutine : MonoBehaviour 
{ 
    public Animator animator; 
    public GameObject Target; 
    CapsuleCollider playerCollider; 
    Couroutinetroll troll; 
    void Start() 
    { 
        troll = gameObject.AddComponent<Couroutinetroll>(); 
        troll.SetTarget(Target); 
        troll.SetAnimator(animator); 
        ((enemy_couroutine)troll).SetAttackRange(1); 
        ((enemy_couroutine)troll).SetMoveSpeed(5); 
        ((enemy_couroutine)troll).SetAttackDelay(3); 
        ((enemy_couroutine)troll).SetAttackDammage(10); 
    } 
    // Update is called once per frame 
    void Update() 
    { 
        if (Time.time>troll.GetAllow_action()) 
        { 
            if (Vector3.Distance(troll.transform.position,troll.GetTarget().transform.position)>troll.GetFightingRange()) 
            { 
                troll.chase(); 
            } 
            else 
            { 
                if (Vector3.Distance(troll.transform.position,troll.GetTarget().transform.position)<=troll.GetAttackRange()) 
                { 
                    troll.attack(); 
                } 
                else 
                { 
                    if (troll.GetFight()) 
                    { 
                        troll.StartCoroutine("fighting"); 
                    } 
                }     
            } 
        } 
        else 
        { 
            Vector3 Targetposition = new Vector3 (Target.transform.position.x, transform.position.y, Target.transform.position.z); 
            transform.LookAt (Targetposition); 
            transform.position=Vector3.MoveTowards(transform.position,Target.transform.position, 6*Time.deltaTime); 
        } 
    } 
} 
} 
