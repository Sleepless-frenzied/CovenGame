using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSlot : MonoBehaviour
{
    public Animator player;
    public GameObject contour;
    public void SpellNumber(int spellNb)
    {
        player.SetInteger("Spell", spellNb);
        contour.transform.position = transform.position;
    }
}
