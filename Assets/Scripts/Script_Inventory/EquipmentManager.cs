﻿using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun.Demo.SlotRacer;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion



    /*public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);

    public OnEquipmentChanged onEquipmentChanged;*/


    //modifiers
    public UnarmedCharacter player;

    public Transform itemsParent;
    private Inventory inventory;
    public Equipment[] currentEquipment;
    private EquipmentSlot[] slots;
    public bool changeWeapon;


    public TMP_Text Wallet_txt;
    public TMP_Text Stats_txt;
    
    

    private void Start()
    {
        inventory = Inventory.instance;
        //inventory.OnItemChangedCallback += ;
        int numSlots = System.Enum.GetNames(typeof(Equipments)).Length;
        currentEquipment = new Equipment[numSlots];
        slots = itemsParent.GetComponentsInChildren<EquipmentSlot>();
    }
    
    public void Equip(Equipment newItem)
    {
        int slotIndex = (int) newItem.equipSlot;
        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            ChangeStat(oldItem,false);
            inventory.Add(oldItem);
            Debug.Log("changé entre deux");
        }
        
        /*if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem,oldItem);
            ChangeStat(newItem,true);
            ChangeStat(oldItem,false);
            
        }*/
        
        if (slotIndex == 2)
        {
            changeWeapon = true;
        }
        ChangeStat(newItem,true);
        Debug.Log("changé seul");
        currentEquipment[slotIndex] = newItem;
        slots[slotIndex].AddItem(newItem);
        
    }

    public void UnEquip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            ChangeStat(currentEquipment[slotIndex], false);
            if (slotIndex == 2)
            {
                changeWeapon = true;
            }
            
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            /*if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null,oldItem);
            }*/
            currentEquipment[slotIndex] = null;
        }
        
        
        
    }
    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }

        foreach (var equip in slots)
        {
            equip.ClearSlot();
        }
    }


    public void ChangeStat(Equipment equipment, bool added)
    {
        if (added)
        {
            player.celerity += equipment.celerityModifier;
            player.attackCooldown -= equipment.cooldownModifier;
            player.MaxHealth += equipment.healthModifier;
            player.MaxMana += equipment.manaModifier;
            player.manaRegen += equipment.manaRegenModifier;
            player.healthRegen += equipment.healthRegenModifier;
            player.damagePower += equipment.damageModifier;
            player.armorPower += equipment.armorModifier;
        }
        else
        {
            player.celerity -= equipment.celerityModifier;
            player.attackCooldown += equipment.cooldownModifier;
            player.MaxHealth -= equipment.healthModifier;
            player.MaxMana -= equipment.manaModifier;
            player.manaRegen -= equipment.manaRegenModifier;
            player.healthRegen -= equipment.healthRegenModifier;
            player.damagePower -= equipment.damageModifier;
            player.armorPower -= equipment.armorModifier;
        }
    }
    
    private void Update()
    {
        Wallet_txt.text = player.Coins + " Coins";
        Stats_txt.text = "Health:\n " + player.health + "/" + player.MaxHealth + "\nMana:\n " + player.mana + "/" +
                         player.MaxMana
                         + "\nHealth regen:\n " + player.healthRegen + "\nMana regen:\n " + player.manaRegen +
                         "\nDamage power:\n " + player.damagePower +
                         "\nDefence:\n " + player.armorPower +
                         "\nCelerity:\n " + player.celerity;
        if (Input.GetKeyDown(KeyCode.U) && transform.GetChild(0).gameObject.activeSelf)
        {
            UnEquipAll();
        }
    }
}
