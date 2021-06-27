using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour,IPointerEnterHandler ,IPointerExitHandler
{
    
    public Image icon;


    public TMP_Text Price_txt;
    private int Price;
    
    public TMP_Text Quantity_txt;
    private int Quantity;
    
    public TMP_Text pop_up;
    private Item item;
    
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
        pop_up.text = "Do you want to continue your purchases? \n Yes Or No";
    }

    public void Buy()
    {
        UnarmedCharacter player = ShopManager.GetPlayer();
        if (Quantity > 0)
        {
            if (player.Coins >= item.Price)
            {
                if (Inventory.instance.items.Count < Inventory.instance.space)
                {
                    item.Buy();
                    Quantity--;
                    player.Coins -= item.Price;
                    Quantity_txt.text = Quantity.ToString();
                }
                else
                {
                    pop_up.text = "Sadly, your inventory is full :(";
                }
            }
            else
            {
                pop_up.text = "YOU DON'T HAVE ENOUGH COINS!!!";
            }
        }
        else
        {
            pop_up.text = "Sorry we don't have this item anymore :')";
        }
    }
    
    public void AddItem(Item newItem, int quant)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

        Quantity = quant;
        Quantity_txt.text = Quantity.ToString();
        
        Price = item.Price;
        string test = Price.ToString();
        Price_txt.text =  test + " Coins";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
