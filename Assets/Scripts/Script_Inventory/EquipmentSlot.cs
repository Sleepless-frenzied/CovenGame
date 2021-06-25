using System;
using UnityEngine.UI;
using UnityEngine;

public class EquipmentSlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    private Equipment item;

    public void AddItem(Equipment newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite =null;
        icon.enabled =false;
        removeButton.interactable = false;
        
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
