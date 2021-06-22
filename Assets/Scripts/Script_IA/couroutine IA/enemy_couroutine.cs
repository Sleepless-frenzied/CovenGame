using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
namespace classEnemyC 
{ 
    public abstract class enemy_couroutine : MonoBehaviour 
    { 
        protected bool AlliesDetected= false;
        protected GameObject ally;
        protected Animator animator; 
        protected GameObject target;
        protected GameObject weapon;  
        protected int ViewDistance; 
        protected int attackRange; 
        protected float moveSpeed; 
        public Collision collision; 
        protected int attack_delay; 
        protected int attack_dammage; 
        protected int health; 
        protected int KbForces=10; 
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
            script.SetHitFrom(gameObject);
        } 
        public void SetAttackDammage(int attack_dammage) 
        { 
             this.attack_dammage=attack_dammage; 
        } 
        public void SetAttackDelay(int attack_delay) 
        { 
             this.attack_delay=attack_delay; 
        } 
        public void SetHealth(int health) 
        { 
             this.health=health; 
        } 
        public void SetFightingRange(int fightingRange) 
        { 
             this.fightingRange=fightingRange; 
        } 
        public Animator Getanimator() 
        { 
            return animator; 
        } 
        public GameObject GetAlly() 
        { 
            return ally; 
        } 
        /*public void SetMoveSpeed(float ally) 
        { 
             this.ally=ally; 
        } */
        public float GetMoveSpeed() 
        { 
            return moveSpeed; 
        } 
        public void SetMoveSpeed(float moveSpeed) 
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
        public void SetWeapon(GameObject Weapon) 
        { 
            weapon=Weapon; 
        } 
        public GameObject GetTarget() 
        { 
            return target; 
        } 
        public void SetAnimator(Animator animator) 
        { 
            this.animator=animator; 
        } 
        public abstract void TakeDamage(PlayerStat player);
        
    } 
} 