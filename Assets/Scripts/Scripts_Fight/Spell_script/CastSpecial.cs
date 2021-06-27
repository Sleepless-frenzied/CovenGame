using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CastSpecial : MonoBehaviourPunCallbacks
{
    public GameObject[] specialAnim;
    private UnarmedCharacter player;

    private void Start()
    {
        if (!photonView.IsMine)
        {
            enabled = false;
        }
        player = gameObject.GetComponent<UnarmedCharacter>();
    }
    

    public void WhatSpecial(int spellNb, float manaCost)
    {
        if (!photonView.IsMine)
        {
            return;
        }
        switch (spellNb)
        {
            case 0:
                Special0(spellNb,manaCost);
                break;
            case 1:
                Special1(spellNb,manaCost);
                break;
            case 2:
                Special2(spellNb,manaCost);
                break;
            case 3:
                Special3(spellNb,manaCost);
                break;
            case 4:
                Special4(spellNb,manaCost);
                break;
        }
    }

    private void Special0(int spellNb, float manaCost)
    {
        player.mana -= manaCost;
        GameObject theSpell = Instantiate(specialAnim[spellNb], transform);
    }
    
    private void Special1(int spellNb, float manaCost)
    {
        player.mana -= manaCost;
        GameObject theSpell = Instantiate(specialAnim[spellNb], transform);
    }
    
    private void Special2(int spellNb, float manaCost)
    {
        player.mana -= manaCost;
        GameObject theSpell = Instantiate(specialAnim[spellNb], player.targetSpell.transform.position, transform.rotation);
        theSpell.GetComponent<Rigidbody>().AddForce(transform.forward * 400);
    }
    
    private void Special3(int spellNb, float manaCost)
    {
        player.mana -= manaCost;
        GameObject theSpell = Instantiate(specialAnim[spellNb], transform);
        Destroy(theSpell, 2);
    }
    
    private void Special4(int spellNb, float manaCost)
    {
        player.mana -= manaCost;
        GameObject theSpell = Instantiate(specialAnim[spellNb], transform);
        Destroy(theSpell, 0.5f);
    }
}
