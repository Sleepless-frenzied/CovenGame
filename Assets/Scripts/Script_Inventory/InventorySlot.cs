using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviourPunCallbacks,IPointerEnterHandler ,IPointerExitHandler
{
    public Image icon;
    public Button removeButton;
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
        if (!_view.IsMine)
        {
            return;
        }
        if (item != null)
        {
            item.Use();
        }
    }
}
