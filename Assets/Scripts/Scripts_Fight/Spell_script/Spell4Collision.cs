using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell4Collision : MonoBehaviour
{

    private float duration = 9;
    private UnarmedCharacter player;
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("AAAAHHHHHHHHHHHHH");
            player = col.gameObject.GetComponent<UnarmedCharacter>();
            player.damagePower += 15;
        }
    }

    private void Update()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
        else
        {
            duration = 9;
            player.damagePower -= 15;
            Destroy(gameObject);
        }
    }
}
