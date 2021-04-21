using System.Collections; 
using System.Collections.Generic; 
using System; 
using UnityEngine; 
namespace classEnemyC 
{ 
    public class IA_Skeleton_code : enemy_couroutine 
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
        public void JumpForward() 
        { 
            if (Time.time > allow_jump) 
            { 
                this.gameObject.GetComponent<Rigidbody>().AddForce(0,3,0,ForceMode.Impulse); 
                animator.Play("Attack1h1");
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
            accel +=0.1f;
            animator.SetFloat("speedh",accel);
            transform.position=Vector3.MoveTowards(position,target.transform.position, moveSpeed*Time.deltaTime); 
        }  
        public override void chase() 
        { 
            Vector3 Targetposition = new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z); 
            transform.LookAt (Targetposition); 
            WalkTo(transform.position); 
        } 
        public override IEnumerator fighting() 
        { 
            accel=0;
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
            accel = 0;
            if (Time.time > attackAllowed ) 
            { 
                animator.Play("Attack1h1");
                Skeleton_Sword script = weapon.GetComponent<Skeleton_Sword>(); 
                script.SetIsHiting(true);
            } 
            attackAllowed = Time.time + attack_delay; 
        } 

        public override IEnumerator CheckEntity()
        {
            while(true)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position,fightingRange*2);
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject == target)
                    {
                        TargetDetected = true;
                    }
                    else
                    {
                        if (hitCollider.tag=="mob")
                        {
                            AlliesDetected=true;
                            ally=hitCollider.gameObject;
                            if (TargetDetected)
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
            script.TargetDetected = true; 
        }
    } 
}

