using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell3Collision : MonoBehaviour
{
    public float spellDamage;
    //tu peux rajouter la varible knockback s'il en faut une
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("mob"))
        {
            Debug.Log("Ennemi touché ! spell 3"); //il faut appliquer les dégâts
            Debug.Log("Knockback !"); //il faut appliquer le knockback
        }
    }
}
