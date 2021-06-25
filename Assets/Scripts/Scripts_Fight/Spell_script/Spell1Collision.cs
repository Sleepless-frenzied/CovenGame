using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell1Collision : MonoBehaviour
{
    private UnarmedCharacter ally;

    private float duration = 5;
    

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ally = col.gameObject.GetComponent<UnarmedCharacter>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ally != null && duration > 0)
        {
            duration -= 0.5f;
            ally.mana += 3;
        }
        else
        {
            duration = 5;
            ally = null;
        }
    }
}
