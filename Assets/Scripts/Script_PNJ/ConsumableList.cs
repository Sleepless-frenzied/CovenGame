using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Equipment List",menuName = "Shop/ConsumableList")]
public class ConsumableList : ScriptableObject
{
    public Consumable[] ListConsumables;
}
