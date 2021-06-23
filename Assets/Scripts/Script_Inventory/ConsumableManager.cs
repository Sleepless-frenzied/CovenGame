using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun.Demo.Cockpit;
using UnityEngine;
using UnityEngine.XR.WSA;

public class ConsumableManager : MonoBehaviour
{
    
    #region Singleton

    public static ConsumableManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public UnarmedCharacter player;

    private Inventory inventory;
    public float Duration;
    public Buffs buff = Buffs.None;

    private void Start()
    {
        inventory = Inventory.instance;
    }

    private void Update()
    {
        if (buff != Buffs.None)
        {
            if (Duration > 0)
            {
                Duration -= Time.deltaTime;
                switch (buff)
                {
                    case Buffs.ManaRegen:
                        player.mana +=5;
                        break;
                    case Buffs.HealthRegen:
                        player.health += 5;
                        break;
                }
            }
            else
            {
                switch (buff)
                {
                    case Buffs.CelerityBuff:
                        player.celerity -= 0.2f;
                        break;
                    case Buffs.CooldownBuff:
                        player.celerity += 0.2f;
                        break;
                    case Buffs.SpeedBuff:
                        player.speed -= 4;
                        break;
                    default:
                        break;
                }

                buff = Buffs.None;
            }
        }

        //player.playerStat.health = player.health;
    }

    public void What(Consumable consumable)
    {
        switch (consumable.effect)
        {
            case Effect.Potion:
                Potion(consumable.grade);
                break;
            case Effect.Antidote:
                Antidote();
                break;
            case Effect.Revive:
                Revive(consumable);
                break;
            case Effect.Buff:
                WhatBuff(consumable);
                break;
        }
    }
    
    public void Potion(Grade grade)
    {
        float pv = 0;
        switch (grade) 
        { 
            case Grade.Low:
                pv = player.MaxHealth * 0.25f ;
                break;
            case Grade.Middle: 
                pv = player.MaxHealth * 0.5f ;
                break;
            case Grade.High: 
                pv = player.MaxHealth * 0.75f ;
                break;
            case Grade.God: 
                pv = player.MaxHealth;
                break;
        }
        player.health += pv;
    }

    public void Antidote()
    {
        player.status = Status.Healthy;
    }

    public void Revive(Consumable consumable)
    {
        /*if (player.CompareTag("Player"))
        {
           TODO
        }
        else */if (player.CompareTag("dead"))
        {
            player.GetComponent<Animator>().SetBool("Dead",false);
            player.tag = "Player";
            switch (consumable.grade) 
            { 
                case Grade.Low:
                    player.health = player.MaxHealth * 0.25f ;
                    break;
                case Grade.Middle: 
                    player.health = player.MaxHealth * 0.5f ;
                    break;
                case Grade.High: 
                    player.health = player.MaxHealth * 0.75f ;
                    break;
                case Grade.God: 
                    player.health = player.MaxHealth;
                    break;
            }
        }
            
    }

    public void WhatBuff(Consumable consumable)
    {
        switch (consumable.buff)
        {
            case Buffs.ManaRegen:
                buff = Buffs.ManaRegen;
                ManaRegen(consumable.grade);
                break;
            case Buffs.HealthRegen:
                buff = Buffs.HealthRegen;
                HealthRegen(consumable.grade);
                break;
            case Buffs.CelerityBuff:
                buff = Buffs.CelerityBuff;
                CelerityBuff(consumable.grade);
                break;
            case Buffs.CooldownBuff:
                buff = Buffs.CooldownBuff;
                CooldownBuff(consumable.grade);
                break;
            case Buffs.SpeedBuff:
                buff = Buffs.SpeedBuff;
                SpeedBuff(consumable.grade);
                break;
        }
    }

    public void ManaRegen(Grade grade)
    {
        
        switch (grade)
        {
            case Grade.Low:
                Duration = 10;
                break;
            case Grade.Middle: 
                Duration = 30;
                break;
            case Grade.High: 
                Duration = 60;
                break;
            case Grade.God: 
                Duration = 90;
                break;
        }
    }
    public void HealthRegen(Grade grade)
    {
        switch (grade)
        {
            case Grade.Low:
                Duration = 10;
                break;
            case Grade.Middle: 
                Duration = 30;
                break;
            case Grade.High: 
                Duration = 60;
                break;
            case Grade.God: 
                Duration = 90;
                break;
        }
    }

    public void CelerityBuff(Grade grade)
    {
        switch (grade)
        {
            case Grade.Low:
                Duration = 10;
                player.celerity += 0.2f; 
                break;
            case Grade.Middle: 
                Duration = 30;
                player.celerity += 0.2f; 
                break;
            case Grade.High: 
                Duration = 60;
                player.celerity += 0.2f; 
                break;
            case Grade.God: 
                Duration = 90;
                player.celerity += 0.2f; 
                break;
        }
    }

    public void CooldownBuff(Grade grade)
    {
        switch (grade)
        {
            case Grade.Low:
                Duration = 10;
                player.attackCooldown -= 0.2f;
                break;
            case Grade.Middle: 
                Duration = 30;
                player.attackCooldown -= 0.2f;
                break;
            case Grade.High: 
                Duration = 60;
                player.attackCooldown -= 0.2f;
                break;
            case Grade.God: 
                Duration = 90;
                player.attackCooldown -= 0.2f;
                break;
        }
    }

    public void SpeedBuff(Grade grade)
    {
        switch (grade)
        {
            case Grade.Low:
                Duration = 10;
                player.speed += 4;
                break;
            case Grade.Middle: 
                Duration = 30;
                player.speed += 4;
                break;
            case Grade.High: 
                Duration = 60;
                player.speed += 4;
                break;
            case Grade.God: 
                Duration = 90;
                player.speed += 4;
                break;
        }
    }
}
public enum Effect
{
    Potion,
    Antidote,
    Revive,
    Buff
}
    
public enum Grade
{
    Low,
    Middle,
    High,
    God
}

public enum Buffs
{
    None,
    ManaRegen,
    HealthRegen,
    CelerityBuff,
    CooldownBuff,
    SpeedBuff
}
