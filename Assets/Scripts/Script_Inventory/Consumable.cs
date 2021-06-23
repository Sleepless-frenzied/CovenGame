using System.Collections;
using System.Collections.Generic;
using Coven;
using UnityEngine;

[CreateAssetMenu(fileName ="New Consumable",menuName = "Inventory/Consumable")]
public class Consumable : Item
{
    public Effect effect;

    public Grade grade;
    
    // Start is called before the first frame update
    public override void Use()
    {
        base.Use();
        
        RemoveFromInventory();
    }

    /*public int GetPV(this)
    {
        int pv = 0;
        if (!(effect == Effect.Buff && effect == Effect.Antidote))
        {
            switch (grade)
            {
                case Grade.Low:
                    TODO
                case Grade.Middle:
                    TODO
                case Grade.High:
                    TODO
                case Grade.God:
                    TODO
            }
        }
        else
        {
            if (sw)
            {
                
            }
        }
        switch (effect)
        {
            case Effect.Potion:
                
        }
    }*/
}

public enum Effect
{
    PotionHP,
    PotionMana,
    Antidote,
    Revive,
    Buff
}

public enum Grade
{
    Low,
    Middle,
    High,
    God
}
