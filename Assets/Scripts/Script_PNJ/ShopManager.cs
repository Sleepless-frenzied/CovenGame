using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class ShopManager : MonoBehaviour
{
    
    /*#region Singleton

    public static ShopManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("");
            return;
        }

        instance = this;
        
    }

    #endregion*/

    private  static UnarmedCharacter player;
    
    public EquipmentList EquipmentList;
    public ConsumableList ConsumableList;
    
    private Inventory inventory;
    private ShopSlot[] slots;

    public TMP_Text Wallet_txt;
    // Start is called before the first frame update
    void Awake()
    {
        Random rnd = new Random();
        inventory = Inventory.instance;
        player = GameObject.FindWithTag("Player").GetComponentInChildren<UnarmedCharacter>();
        
        slots = GetComponentsInChildren<ShopSlot>();
        
        //Consumable tmpCons = GetCons();
        int tmpQuanti = rnd.Next(10);
        //slots[0].AddItem(tmpCons,tmpQuanti);
        int tmpCons = rnd.Next(ConsumableList.ListConsumables.Length);
        Consumable SellCons = ConsumableList.ListConsumables[tmpCons];
        slots[0].AddItem(SellCons,tmpQuanti);
        
        //tmpCons = GetCons();
        tmpQuanti = rnd.Next(10);
        //slots[1].AddItem(tmpCons,tmpQuanti);
        tmpCons = rnd.Next(ConsumableList.ListConsumables.Length);
        SellCons = ConsumableList.ListConsumables[tmpCons];
        slots[1].AddItem(SellCons,tmpQuanti);
        
        //tmpCons = GetCons();
        tmpQuanti = rnd.Next(10);
        //slots[2].AddItem(tmpCons,tmpQuanti);
        tmpCons = rnd.Next(ConsumableList.ListConsumables.Length);
        SellCons = ConsumableList.ListConsumables[tmpCons];
        slots[2].AddItem(SellCons,tmpQuanti);
        
        //tmpCons = GetCons();
        tmpQuanti = rnd.Next(10);
        //slots[3].AddItem(tmpCons,tmpQuanti);
        tmpCons = rnd.Next(ConsumableList.ListConsumables.Length);
        SellCons = ConsumableList.ListConsumables[tmpCons];
        slots[3].AddItem(SellCons,tmpQuanti);
        
        Equipment eq = GetEq();
        slots[4].AddItem(eq,1);
    }
    
    public static UnarmedCharacter GetPlayer()
    {
        return player;
    }
    
    public Equipment GetEq()
    {
        //int test = rand.Next();
        Random rand =new Random();
        int tmpEq = rand.Next(EquipmentList.ListEquipments.Length);
        var SellEq = EquipmentList.ListEquipments[tmpEq];
        return SellEq;
    }

    public Consumable GetCons()
    {
        Random rand =new Random();
        int tmpCons = rand.Next(ConsumableList.ListConsumables.Length);
        var SellCons = ConsumableList.ListConsumables[tmpCons];
        Debug.Log("one two three");
        return SellCons;
    }


    

    private void Update()
    {
        Wallet_txt.text = player.Coins.ToString() + " Coins";
    }
}
