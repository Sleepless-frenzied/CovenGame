using System;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName = "Inventory/Item")]
[Serializable]
public class Item : ScriptableObject
{
    public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public string description;
    

    public virtual void Use()
    {
        Debug.Log("using"+name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
