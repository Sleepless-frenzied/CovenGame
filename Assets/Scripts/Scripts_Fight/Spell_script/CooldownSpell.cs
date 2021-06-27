using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownSpell : MonoBehaviour
{
    private float cooldown;
    private float manaCost;
    public Image image;
    public GameObject ThePlayer;
    private UnarmedCharacter player;
    private CastSpell _castSpell;
    private Animator animator;
    private int spellNb;
    
    // Start is called before the first frame update
    void Start()
    {
        player = ThePlayer.GetComponent<UnarmedCharacter>();
        animator = ThePlayer.GetComponent<Animator>();
        image.fillAmount = 0;
        _castSpell = ThePlayer.GetComponent<CastSpell>();
        spellNb = animator.GetInteger("Spell");
    }

    // Update is called once per frame
    void Update()
    {
        spellNb = animator.GetInteger("Spell");
        //update the spell
        switch (spellNb)
        {
            case 0:
                cooldown = 10;
                manaCost = 25;
                break;
            case 1:
                cooldown = 10;
                manaCost = 20;
                break;
            case 2:
                cooldown = 3;
                manaCost = 25;
                break;
            case 3:
                cooldown = 10;
                manaCost = 40;
                break;
            case 4:
                cooldown = 20;
                manaCost = 70;
                break;
        }

        if (Input.GetKeyDown(KeyCode.R) && image.fillAmount <= 0 && player.mana >= manaCost && animator.GetBool("CanAttack"))
        {
            animator.SetBool("isSpell", true);
            image.fillAmount = 1;
            _castSpell.WhatSpell(spellNb, manaCost);
        }
        else
        {
            animator.SetBool("isSpell", false);
        }
        
        image.fillAmount -= Time.deltaTime * 1 / (cooldown * player.attackCooldown);
    }
}
