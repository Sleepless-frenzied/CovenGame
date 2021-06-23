using System.Collections; 
using System.Collections.Generic; 
using System; 
using UnityEngine; 
namespace classEnemyC 
{ 
    public class IA_Albinos_code : enemy_couroutine 
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
                Destroy(this.gameObject);
            }
            else
            {
                animator.Play("Hit");
            }
        }
        public void WalkTo(Vector3 position) 
        { 
            animator.Play("Walk");
            transform.position=Vector3.MoveTowards(position,target.transform.position, moveSpeed*Time.deltaTime); 
        }  
        public override void chase()
        {}
        public void FireAttack() 
        { 
            transform.LookAt (target.transform.position);
            Debug.Log("flame attack");
            animator.SetTrigger("Flame Attack");
            GameObject[] listPlayer = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in listPlayer)
            {
                Animator animationPlayer = player.GetComponent<Animator>();
                animationPlayer.SetTrigger("Dead");
            }
            allow_action = Time.time + 6;
            
        } 
        public override IEnumerator fighting() 
        { 
            accel=0;
            fight = false; 
            System.Random random = new System.Random();
            switch (random.Next(15)) 
            { 
                case 1 : for (int i = 0; i < 10; i++) 
                { 
                    WalkTo(transform.position); 
                    yield return new WaitForFixedUpdate(); 
                }  
                         break;        
                case 2 : 
                         FireAttack();
                         break;
                case 3 : 
                         FireAttack();
                         break;
                case 4 : for (int i = 0; i < 10; i++) 
                { 
                    WalkTo(transform.position); 
                    yield return new WaitForFixedUpdate(); 
                }  break;
                default: attack();
                         break;
            } 
            fight = true; 
            yield return new WaitForEndOfFrame(); 
        } 
        public override void attack() 
        { 
            transform.LookAt (target.transform.position);
            if (Time.time > attackAllowed ) 
            { 
                System.Random random = new System.Random();
                if (random.Next(2)==1)
                {
                    animator.SetTrigger("Basic attack");
                }
                else {animator.Play("Claw Attack");}
                HitboxHit script = weapon.GetComponent<HitboxHit>(); 
                script.SetIsHiting(true);
                allow_action = Time.time + 1;
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
                }
                yield return new WaitForSeconds(1);
            }
        }
    } 
}
