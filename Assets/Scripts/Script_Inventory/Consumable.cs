using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
            //RemoveFromInventory();
        }

        public void use2()
        {
            ConsumableManager.instance.What(this);
        }

        public override string ToString()
        {
            string eff = "";
            switch (effect)
            {
                case Effect.Potion:
                    eff = "Potion";
                    break;
                case Effect.Antidote:
                    eff = "Antidote";
                    break;
                case Effect.Revive:
                    eff = "Revive Potion";
                    break;
                case Effect.Buff:
                    eff = "Buff Potion";
                    break;
            }

            return base.ToString() + "Effect: " + eff + "\n" + description;
            
            
            
        }
    }
    
    

