using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
   public override void Interact()
    {
        base.Interact();
        Pickup();
        
    }

    void Pickup()
    {
        
        Debug.Log("picking"+item.name);
        bool wasPickedup = Inventory.instance.Add(item);
        if (wasPickedup)
        {
            Destroy(gameObject);
        }
    }
}
