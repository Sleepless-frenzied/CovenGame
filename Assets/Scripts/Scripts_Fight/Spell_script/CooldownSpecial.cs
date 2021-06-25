using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownSpecial : MonoBehaviour
{
    private float cooldown;
    private float manaCost;
    public Image image;
    public GameObject ThePlayer;
    private UnarmedCharacter player;
    private CastSpecial _castSpecial;
    private Animator animator;
    private int specialNb;
    
    // Start is called before the first frame update
    void Start()
    {
        player = ThePlayer.GetComponent<UnarmedCharacter>();
        animator = ThePlayer.GetComponent<Animator>();
        image.fillAmount = 0;
        _castSpecial = ThePlayer.GetComponent<CastSpecial>();
        specialNb = animator.GetInteger("Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        specialNb = animator.GetInteger("Weapon");
        //update the spell
        switch (specialNb)
        {
            case 0:
                cooldown = 15;
                manaCost = 20;
                break;
            case 1:
                cooldown = 15;
                manaCost = 50;
                break;
            case 2:
                cooldown = 10;
                manaCost = 35;
                break;
            case 3:
                cooldown = 6;
                manaCost = 40;
                break;
            case 4:
                cooldown = 2;
                manaCost = 10;
                break;
        }

        if (Input.GetKeyDown(KeyCode.A) && image.fillAmount <= 0 && player.mana >= manaCost && animator.GetBool("CanAttack") && !animator.GetBool("isInTheAir"))
        {
            animator.SetBool("isSpecial", true);
            image.fillAmount = 1;
            _castSpecial.WhatSpecial(specialNb, manaCost);
        }
        else
        {
            animator.SetBool("isSpecial", false);
        }
        
        image.fillAmount -= Time.deltaTime * 1 / cooldown;
    }
}
