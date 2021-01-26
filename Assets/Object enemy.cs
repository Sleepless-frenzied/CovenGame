using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace classEnemy
{
    public class Enemy
    {
        protected target : Transform;
        protected int ViewDistance;
        protected int attackRange;
        protected int moveSpeed;
        protected int attack_delay;
        protected int attack_dammage;
        protected int health;
        protected int KbForces;
        protected int fightingRange=;
        private var MoveDirection : Vector3 = Vector3.zero;
        protected var controller = : CharacterController;
        protected var attackTime;
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
        }
        public override void chase()
        {
            animation.Play("attack");
            animation.["attack"].speed = 1;
            moveDirection = transform.forward*moveSpeed;
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
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

