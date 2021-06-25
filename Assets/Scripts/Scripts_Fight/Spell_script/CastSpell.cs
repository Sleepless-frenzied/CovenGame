using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public GameObject[] spellAnim;
    private UnarmedCharacter player;

    private void Start()
    {
        player = gameObject.GetComponent<UnarmedCharacter>();
    }
    

    public void WhatSpell(int spellNb, float manaCost)
    {
        switch (spellNb)
        {
            case 0:
                Spell0(spellNb,manaCost);
                break;
            case 1:
                Spell1(spellNb,manaCost);
                break;
            case 2:
                Spell2(spellNb,manaCost);
                break;
            case 3:
                Spell3(spellNb,manaCost);
                break;
            case 4:
                Spell4(spellNb,manaCost);
                break;
        }
    }


    //Regen de PV
    private void Spell0(int spellNb, float manaCost)
    { 
        player.mana -= manaCost;
        GameObject theSpell = Instantiate(spellAnim[spellNb], transform);
        Destroy(theSpell, 1);
    }
    
    //Regen de Mana
    private void Spell1(int spellNb, float manaCost)
    {
        //ce spell coûte des HP
        player.health -= manaCost;
        GameObject theSpell = Instantiate(spellAnim[spellNb], transform);
        Destroy(theSpell, 2);
        
    }
    
    //Launch an elementalBall
    private void Spell2(int spellNb, float manaCost)
    {
        player.mana -= manaCost;
        GameObject theSpell = Instantiate(spellAnim[spellNb], player.targetSpell.transform.position, transform.rotation);
        theSpell.GetComponent<Rigidbody>().AddForce(player.cam.transform.forward * 800);
    }
    
    //Create a laserOfLight around the player which deals damage and knockback
    private void Spell3(int spellNb, float manaCost)
    {
        player.mana -= manaCost;
        GameObject theSpell = Instantiate(spellAnim[spellNb], transform);
        Destroy(theSpell,1);
    }
    
    private void Spell4(int spellNb, float manaCost)
    {
        player.mana -= manaCost;
        GameObject theSpell = Instantiate(spellAnim[spellNb], transform);
    }
    
}
