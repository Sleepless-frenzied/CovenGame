using System.Collections;
using System.Collections.Generic;
using Coven;
using UnityEngine;


    [CreateAssetMenu(fileName ="New Consumable",menuName = "Inventory/Consumable")]
    public class Consumable : Item
    {
        public Effect effect;
    
        public Grade grade;

        public Buffs buff;
        // Start is called before the first frame update
        
        public override void Use()
        {
            base.Use();
            ConsumableManager.instance.What(this);
            RemoveFromInventory();
        }
    
        
    }
    
    

