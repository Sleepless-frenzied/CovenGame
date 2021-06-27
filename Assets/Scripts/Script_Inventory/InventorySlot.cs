using System;
using Photon.Pun;
using System.Diagnostics;
using TMPro;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class InventorySlot : MonoBehaviourPunCallbacks,IPointerEnterHandler ,IPointerExitHandler
{
    public Image icon;
    public Button removeButton;
    public Button AddRacc;
    public TMP_Text pop_up;
    private Item item;

    [SerializeField] private PhotonView _view;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            pop_up.enabled = true;
            pop_up.text = item.ToString();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        pop_up.enabled = false;
        pop_up.text = "";
    }
    /*private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            pop_up.enabled = true;
            pop_up.text = item.description;
        }
        else
        {
            pop_up.enabled = false;
            pop_up.text = "";
        }
    }*/
    
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        if (newItem.GetType() == typeof(Consumable))
        { 
            AddRacc.interactable = true;
        }
        else
        {
            AddRacc.interactable = false;
        }

    }
    
    public void AddToRacc()
    {
        for (int i = 0; i < 3; i++)
        {
            if (ConsumableSlotManager.instance.racc[i].Item == null)
            {
                ConsumableSlotManager.instance.racc[i].Item = item;
                ConsumableSlotManager.instance.racc[i].icon.enabled = true;
                ConsumableSlotManager.instance.racc[i].icon.sprite = item.icon;
                AddRacc.interactable = false;
                OnRemoveButton();
                return;
            }
        }
        
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite =null;
        icon.enabled =false;
        removeButton.interactable = false;
        AddRacc.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
        AddRacc.interactable = false;
    }

    public void UseItem()
    {
        if (!_view.IsMine)
        {
            return;
        }
        if (item != null)
        {
            item.Use();
        }
    }

    private void Update()
    {
        if (ConsumableSlotManager.instance.racc[0].Item != null &&ConsumableSlotManager.instance.racc[1].Item != null &&ConsumableSlotManager.instance.racc[2].Item != null )
        {
            AddRacc.interactable = false;
        }
    }
}
