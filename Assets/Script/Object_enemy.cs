using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace classEnemy
{
    public abstract class Enemy
    {
        public GameObject target;
        public Transform self;
        public Rigidbody body;
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
        protected int stability;
        protected Vector3 positionOffset;
        public abstract void attack();
        public abstract void chase();
        public abstract void fighting();
    }
    public class Troll : Enemy
    {
        bool HealthAbility = true;
        public Troll(int ViewDistance,int attackRange,int moveSpeed,int attack_delay,int attack_dammage,int health,int KbForces,int stability)
        {
            this.ViewDistance = ViewDistance;
            this.attackRange = attackRange;
            this.moveSpeed = moveSpeed;
            this.attack_delay = attack_delay;
            this.attack_dammage = attack_dammage;
            this.health = health;
            this.stability=stability;
            attackTime = 1.5F;
        }
        public void JumpBackward()
        {
            body.AddForce(0,100,100,ForceMode.Impulse);
        }
        public void SelfHeal()
        {
            //joue l'animation regeneration
            System.Threading.Thread.Sleep(1500);
            //health = maxHealth
        }
        public void WalkTo(Vector3 position)
        {
            //joue l'animation de marche
            Vector3.MoveTowards(position,target.transform.position, moveSpeed * Time.deltaTime);
        }
        public void WalkAroundTarget()
        {
           // joue l'animation de marche
           positionOffset.Set(Mathf.Cos(120) * fightingRange,0,Mathf.Sin(120) * fightingRange );
           WalkTo(target.transform.position + positionOffset);
        }
        public override void chase()
        {
            WalkTo(self.position);
        }
        public override void fighting()
        {
            System.Random random = new System.Random();
            switch (random.Next(5))
            {
                case 0 : JumpBackward();
                         break;
                case 1 : WalkTo(target.transform.position);
                         break;
                default : WalkAroundTarget();
                         break;       
            }
        }
        public override void attack()
        {
            /*if (Time.deltaTime+attack_delay)
            {

            }
            else
            {
                //joue l'animation d'attack
            }*/
        }
    }
}
