using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun.Demo.SlotRacer;
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



    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);

    public OnEquipmentChanged onEquipmentChanged;


    //modifiers
    public UnarmedCharacter player;
    /*private float celerity = 0;
    private float cooldown = 0;
    private float maxHealth = 0;
    private float maxMana = 0;*/

    public Transform itemsParent;
    private Inventory inventory;
    public Equipment[] currentEquipment;
    private EquipmentSlot[] slots;
    
    

    

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
            inventory.Add(oldItem);
        }
        
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem,oldItem);
        }
        
        ChangeStat(newItem,true);
        currentEquipment[slotIndex] = newItem;
        Debug.Log(newItem.celerityModifier + "" + newItem.cooldownModifier + "" + newItem.healthModifier + "" + newItem.manaModifier);
        slots[slotIndex].AddItem(newItem);
        
    }

    public void UnEquip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            ChangeStat(currentEquipment[slotIndex], false);
            
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null,oldItem);
            }
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
        }
        else
        {
            player.celerity -= equipment.celerityModifier;
            player.attackCooldown += equipment.cooldownModifier;
            player.MaxHealth -= equipment.healthModifier;
            player.MaxMana -= equipment.manaModifier;
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnEquipAll();
        }
    }
}
