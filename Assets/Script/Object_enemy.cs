using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace classEnemy
{
    public abstract class Enemy
    {
        public GameObject target;
        public Transform self;
        protected int ViewDistance;
        protected int attackRange;
        protected int moveSpeed;
        protected int attack_delay;
        protected int attack_dammage;
        protected int health;
        protected int KbForces;
        protected int fightingRange;
        protected float attackTime;
        protected int gravity = 20;
        public abstract void attack();
        public abstract void chase();
        public abstract void fighting();
    }
    public class Troll : Enemy
    {
        public Troll(int ViewDistance,int attackRange,int moveSpeed,int attack_delay,int attack_dammage,int health,int KbForces)
        {
            this.ViewDistance = ViewDistance;
            this.attackRange = attackRange;
            this.moveSpeed = moveSpeed;
            this.attack_delay = attack_delay;
            this.attack_dammage = attack_dammage;
            this.health = health;
            attackTime = 1.5F;
        }
        public override void chase()
        {
            Vector3.MoveTowards(self.position,target.transform.position, moveSpeed * Time.deltaTime);
        }
        public override void fighting()
        {
            throw new System.NotImplementedException();
        }
        public override void attack()
        {
            throw new System.NotImplementedException();
        }
    }
}

