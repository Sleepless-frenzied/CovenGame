using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace classEnemy
{
public class IA_Troll : MonoBehaviour
{
    public Animator animator;
    public GameObject Target;
    CapsuleCollider playerCollider;
    Troll troll;
    void Start()
    {
        troll = gameObject.AddComponent<Troll>();
        troll.SetTarget(Target);
        troll.SetAnimator(animator);
        ((Enemy)troll).SetAttackRange(1);
        ((Enemy)troll).SetMoveSpeed(5);
        ((Enemy)troll).SetAttackDelay(3);
        ((Enemy)troll).SetAttackDammage(10);
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
                    troll.fighting();
                }    
            }
        }
        else
        {
            Vector3 Targetposition = new Vector3 (Target.transform.position.x, transform.position.y, Target.transform.position.z);
            transform.LookAt (Targetposition);
            transform.position=Vector3.MoveTowards(transform.position,Target.transform.position, -6*Time.deltaTime);
        }
    }
}
}