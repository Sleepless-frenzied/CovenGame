using System.Collections; 
using System.Collections.Generic; 
using System; 
using UnityEngine; 
namespace classEnemyC 
{ 
    public class Couroutinetroll : enemy_couroutine 
    { 
        bool HealthAbility = true; 
       /* public Troll(int ViewDistance,int attackRange,int moveSpeed,int attack_delay,int attack_dammage,int health,int KbForces,int stability) 
        { 
            this.ViewDistance = ViewDistance; 
            this.attack_delay = attack_delay; 
            this.attack_dammage = attack_dammage; 
            this.health = health; 
            this.stability=stability; 
            attackTime = 1.5F; 
        }*/ 
        private int delay_jump = 10; 
        private int allow_jump = 0; 
        private float allow_action=0; 
 
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
                allow_action = Time.time+0.7F; 
                allow_jump= (int)Time.time + delay_jump; 
            } 
        } 
        public void SelfHeal() 
        { 
            //joue l'animation regeneration 
            //health = maxHealth 
        } 
        IEnumerator wait() 
        { 
            while (transform.position.y>target.transform.position.y) 
            { 
                yield return new WaitForSeconds(1);  
            } 
        } 
        void OnCollisionEnter(Collision collision) 
        { 
            if (collision.collider.tag=="canJumpAbove") 
            { 
                //jump animation 
                this.gameObject.GetComponent<Rigidbody>().AddForce(0,10,0,ForceMode.Impulse); 
            } 
        } 
        void OnCollisionStay(Collision collision) 
        { 
            if (isHiting /*&& animation attack is true*/) 
            { 
                if (collision.gameObject==target) 
                { 
                    ApplyDamage(); 
                    isHiting=false; 
                } 
            } 
        } 
        public void WalkTo(Vector3 position) 
        { 
            bool isRunning = animator.GetBool("isWalking"); 
            animator.SetBool("isWalking", true); 
            transform.position=Vector3.MoveTowards(position,target.transform.position, moveSpeed*Time.deltaTime); 
        } 
        public void WalkAroundTarget() 
        { 
                Vector3 Targetposition = new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z); 
                transform.LookAt (Targetposition); 
                Vector3 axis = new Vector3(0,3,0); 
                transform.RotateAround(target.transform.position,axis, 0.3F); 
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
            switch (random.Next(6)) 
            { 
                case 0 : JumpForward(); 
                         break; 
                case 1 : for (int i = 0; i < 20; i++) 
                { 
                    WalkTo(transform.position); 
                    yield return new WaitForFixedUpdate(); 
                }   
                         break; 
                default :for (int i = 0; i < 10; i++) 
                { 
                    WalkAroundTarget(); 
                    yield return new WaitForFixedUpdate(); 
                }  
                         break;        
            } 
            fight = true; 
            yield return new WaitForEndOfFrame(); 
        } 
        public override void attack() 
        { 
            if (Time.time > attackAllowed ) 
            { 
                isHiting=true; 
                //joue l'animation d'attaque 
            } 
            attackAllowed = Time.time + attack_delay; 
        } 
    } 
}
