using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment List",menuName = "Shop/EquipmentList")]
public class EquipmentList : ScriptableObject
{
    public Equipment[] ListEquipments;
}
