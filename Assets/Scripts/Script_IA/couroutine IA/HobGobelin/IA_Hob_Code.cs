using System.Collections; 
using System.Collections.Generic; 
using System; 
using UnityEngine; 
namespace Coven
{ 
    public class IA_Hob_Code : enemy_couroutine 
    { 
        private int delay_jump = 10; 
        private int allow_jump = 0; 
        private float allow_action=0; 
        private float accel = 0.1f;
 
        private bool fight = true; 
        public bool GetFight() 
        { 
            return fight; 
        } 
        public float GetAllow_action() 
        { 
            return allow_action; 
        } 
        public override void TakeDamage(PlayerStat player)
        {
            health-=player.GetDamage();
            if (health<=0)
            {
                animator.SetBool("Dead",true);
                Destroy(this.gameObject,3);
            }
        }
        public void JumpForward() 
        { 
            if (Time.time > allow_jump) 
            { 
                this.gameObject.GetComponent<Rigidbody>().AddForce(0,2,0,ForceMode.Impulse); 
                attack();
                allow_action = Time.time+0.7F; 
                allow_jump= (int)Time.time + delay_jump; 
            } 
        } 
        void OnCollisionEnter(Collision collision) 
        { 
            if (collision.collider.tag=="canJumpAbove") 
            { 
                this.gameObject.GetComponent<Rigidbody>().AddForce(0,4.5F,0,ForceMode.Impulse); 
            } 
        } 
        public void WalkTo(Vector3 position) 
        { 
            animator.SetTrigger("Run");
            if(target==null){}
            else{
            transform.LookAt (new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z)); 
             transform.position=Vector3.MoveTowards(position,target.transform.position, moveSpeed*Time.deltaTime);}
        }  
        public override void chase() 
        { 
            Vector3 Targetposition = new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z); 
            transform.LookAt (Targetposition); 
            WalkTo(transform.position); 
        } 
        public override IEnumerator fighting() 
        { 
            fight = false; 
            System.Random random = new System.Random(); 
            switch (random.Next(2)) 
            { 
                case 0 : JumpForward(); 
                         break; 
                case 1 : for (int i = 0; i < 20; i++) 
                { 
                    WalkTo(transform.position); 
                    yield return new WaitForFixedUpdate(); 
                }   
                         break;        
            } 
            fight = true; 
            yield return new WaitForEndOfFrame(); 
        } 
        public override void attack() 
        { 
            transform.LookAt (new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z)); 
            if (Time.time > attackAllowed ) 
            { 
                animator.SetTrigger("Attack");
                Debug.Log("attaque hob");
                Hob_Weapon script = weapon.GetComponent<Hob_Weapon>(); 
                script.SetIsHiting(true);
                attackAllowed = Time.time + attack_delay;
            }  
        } 

        public override IEnumerator CheckEntity()
        {
            while(true)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position,fightingRange*2);
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.tag == "Player")
                    {
                        target = hitCollider.gameObject;
                    }
                    else
                    {
                        if (hitCollider.tag=="mob")
                        {
                            AlliesDetected=true;
                            ally=hitCollider.gameObject;
                            if (target!=null)
                            {
                                CallAllies();
                            }
                        }
                    }
                }
                yield return new WaitForSeconds(1);
            }
        }
        public void CallAllies()
        {
            IA_Skeleton_code script =ally.GetComponent<IA_Skeleton_code>(); 
            script.SetTarget(target); 
        }
    } 
}

