using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
namespace classEnemyC 
{ 
public class IA_Skeleton : MonoBehaviour 
{ 
    public Animator animator; 
    public GameObject Weapon;
    CapsuleCollider playerCollider; 
    IA_Skeleton_code Skeleton; 
    void Start() 
    { 
        Skeleton = gameObject.AddComponent<IA_Skeleton_code>(); 
        Skeleton.SetTarget(null); 
        Skeleton.SetAnimator(animator);
        Skeleton.SetWeapon(Weapon);
        ((enemy_couroutine)Skeleton).SetAttackRange(1); 
        ((enemy_couroutine)Skeleton).SetMoveSpeed(3); 
        ((enemy_couroutine)Skeleton).SetAttackDelay(3); 
        ((enemy_couroutine)Skeleton).SetAttackDammage(27); 
        Skeleton.StartCoroutine("CheckEntity");
    } 
    // Update is called once per frame 
    void Update() 
    { 
        if (Time.time>Skeleton.GetAllow_action()) 
        { 
            if (Skeleton.GetTarget()!=null)
            {
            float Distance = Vector3.Distance(Skeleton.transform.position,Skeleton.GetTarget().transform.position);
            if (Distance>Skeleton.GetFightingRange()) 
            { 
                Skeleton.chase(); 
            } 
            else 
            { 
                if (Distance<=Skeleton.GetAttackRange()) 
                { 
                    Skeleton.attack(); 
                } 
                else 
                { 
                    if (Skeleton.GetFight() && Distance<=Skeleton.GetFightingRange()) 
                    { 
                        Skeleton.StartCoroutine("fighting"); 
                    } 
                }     
            } }
        } 
        else 
        { 
            if (Skeleton.GetTarget()!=null)
            {
                Vector3 Targetposition = new Vector3 (Skeleton.GetTarget().transform.position.x, transform.position.y, Skeleton.GetTarget().transform.position.z); 
                transform.LookAt (Targetposition); 
                transform.position=Vector3.MoveTowards(transform.position,Skeleton.GetTarget().transform.position, 6*Time.deltaTime); 
            }
        }
    } 
}
}