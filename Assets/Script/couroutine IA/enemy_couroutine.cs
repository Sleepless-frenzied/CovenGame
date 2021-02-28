using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
namespace classEnemyC 
{ 
    public abstract class enemy_couroutine : MonoBehaviour 
    { 
        protected bool TargetDetected= false;
        protected bool AlliesDetected= false;
        protected GameObject ally;
        protected Animator animator; 
        protected GameObject target; 
        protected int ViewDistance; 
        protected int attackRange; 
        protected int moveSpeed; 
        public Collision collision; 
        protected int attack_delay; 
        protected int attack_dammage; 
        protected int health; 
        protected bool isHiting; 
        protected int KbForces; 
        protected int fightingRange=6; 
        protected float attackTime; 
        protected int gravity = 20; 
        protected int stability; 
        protected float attackAllowed =0; 
        protected Vector3 positionOffset; 
        public abstract void attack(); 
        public abstract void chase(); 
        public abstract IEnumerator fighting(); 
        public abstract IEnumerator CheckEntity();
        public void ApplyDamage() 
        { 
            PlayerStat script =target.GetComponent<PlayerStat>(); 
            script.TakeDamage(attack_dammage,KbForces); 
        } 
        public void SetAttackDammage(int attack_dammage) 
        { 
             this.attack_dammage=attack_dammage; 
        } 
        public void SetAttackDelay(int attack_delay) 
        { 
             this.attack_delay=attack_delay; 
        } 
        public bool GetTargetDetection() 
        { 
            return TargetDetected; 
        } 
        public GameObject GetAlly() 
        { 
            return ally; 
        } 
        public void SetMoveSpeed(GameObject ally) 
        { 
             this.ally=ally; 
        } 
        public int GetMoveSpeed() 
        { 
            return moveSpeed; 
        } 
        public void SetMoveSpeed(int moveSpeed) 
        { 
             this.moveSpeed=moveSpeed; 
        } 
        public int GetFightingRange() 
        { 
            return fightingRange; 
        } 
        public int GetAttackRange() 
        { 
            return attackRange; 
        } 
        public void SetAttackRange(int attackRange) 
        { 
            this.attackRange=attackRange; 
        } 
        public void SetTarget(GameObject Target) 
        { 
            target=Target; 
        } 
        public GameObject GetTarget() 
        { 
            return target; 
        } 
        public void SetAnimator(Animator animator) 
        { 
            this.animator=animator; 
        } 
        public void TakeDamage(PlayerStat player) 
        { 
            health-=player.GetDamage(); 
            if (health<=0) 
            { 
                //joue l'animation de mort 
                //Destroy(this.gameObject,3); 
            } 
            else 
            { 
                this.gameObject.GetComponent<Rigidbody>().AddForce(0,(player.GetKnockBack()-stability)/2,stability-player.GetKnockBack(),ForceMode.Impulse); 
            } 
        } 
    } 
} 