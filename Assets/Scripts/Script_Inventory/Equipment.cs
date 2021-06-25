using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment",menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public Equipments equipSlot;
    public WeaponType weapontype = WeaponType.None;
    public int armorModifier;
    public int damageModifier;
    public float celerityModifier;
    public float cooldownModifier;
    public float manaModifier;
    public float healthModifier;
    public float manaRegenModifier;
    public float healthRegenModifier;
    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        Debug.Log("Equiped" + this);
        RemoveFromInventory();
    }
}

public enum WeaponType
{
    None,
    Sword,
    Spear,
    Hammer,
    DoubleSword
}
public enum Equipments
{
    Head,
    Chest,
    Weapon,
    Shield,
    Feet
}
