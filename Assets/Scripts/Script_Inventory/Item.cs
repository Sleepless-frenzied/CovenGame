using System;
using Photon.Pun;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName = "Inventory/Item")]
[Serializable]
public class Item : ScriptableObject
{
    public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public string description;
    public int Price;
    

    public virtual void Use()
    {
        Debug.Log("using "+name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
    
    public virtual void Buy()
    {
        Debug.Log("Buying "+name);
        Inventory.instance.Add(this);
    }

    public override string ToString()
    {
        return "Name: " + name + "\n";
    }
}
