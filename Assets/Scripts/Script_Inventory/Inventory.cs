using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("");
            return;
        }

        instance = this;
        
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;
    
    public int space = 20;
    
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("");
                return false;
            }
            
            items.Add(item);
            if (OnItemChangedCallback != null)
            {
                OnItemChangedCallback.Invoke();
            }
            
        }

        return true;
    }
    public void Remove(Item item)
    {
        items.Remove(item); 
        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
    }
}
