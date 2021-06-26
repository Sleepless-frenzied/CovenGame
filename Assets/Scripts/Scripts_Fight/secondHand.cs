using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondHand : MonoBehaviour
{
    public EquipmentManager equipment;
    public GameObject[] allWeapons;

    private int whatWeapon;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (equipment.currentEquipment[2] != null)
        {
            whatWeapon = equipment.currentEquipment[2].idWeapon;
            if (equipment.changeWeapon && equipment.currentEquipment[2].weapontype == WeaponType.DoubleSword)
            {
                //destroy all child
                int childs = transform.childCount;
                for (int i = 0; i < childs; i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            
                //Instantiate the new weapon
                Instantiate(allWeapons[whatWeapon], transform);
            }
            else if (equipment.changeWeapon)
            {
                int childs = transform.childCount;
                for (int i = 0; i < childs; i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
        }
        else
        {
            int childs = transform.childCount;
            for (int i = 0; i < childs; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            equipment.changeWeapon = false;
        }
    }
}
