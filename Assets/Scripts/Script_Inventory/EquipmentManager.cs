using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    
    

    public Transform itemsParent;
    private Inventory inventory;
    private Equipment[] currentEquipment;

    private void Start()
    {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        //currentEquipment= itemsParent.GetComponentsInChildren<Equipment>();

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
        
        currentEquipment[slotIndex] = newItem;
    }

    public void UnEquip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnEquipAll();
        }
    }
}
