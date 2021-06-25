using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class healthAfficher : MonoBehaviour
{
    public UnarmedCharacter player;
    public TMP_Text healthText;
    public TMP_Text manaText;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = Math.Ceiling(player.health) + "/" + player.MaxHealth;
        manaText.text = Math.Ceiling(player.mana) + "/" + player.MaxMana;
    }
}
