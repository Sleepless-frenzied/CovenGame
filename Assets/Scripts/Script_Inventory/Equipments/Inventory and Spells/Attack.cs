using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public Image image;
    public Sprite[] allImage;
    public bool spell;
    public bool special;
    public EquipmentManager equipment;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spell)
            image.sprite = allImage[animator.GetInteger("Spell")];
        else if (special)
            image.sprite = allImage[animator.GetInteger("Weapon")];
        else if (equipment.currentEquipment[2] != null)
            image.sprite = equipment.currentEquipment[2].icon;
        else
            image.sprite = allImage[animator.GetInteger("Weapon")];
            
    }
}
