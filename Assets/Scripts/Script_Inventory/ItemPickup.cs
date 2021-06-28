using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public possibleWeapon Possible;
    public override void Interact()
    {
        base.Interact();
        Pickup();
        
    }

    void Pickup()
    {
        if (Possible.weapons.Length != 0)
            item = Possible.weapons[Random.Range(0, Possible.weapons.Length)];
        else if (Possible.armor.Length != 0)
            item = Possible.armor[Random.Range(0, Possible.armor.Length)];
        else if (Possible.items.Length != 0)
            item = Possible.items[Random.Range(0, Possible.items.Length)];

        Debug.Log("picking "+item.name);
        bool wasPickedup = Inventory.instance.Add(item);
        if (wasPickedup)
        {
            Destroy(gameObject);
        }
    }
}
