using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special0Collision : MonoBehaviour
{
    
    private float duration = 6;
    private UnarmedCharacter player;
    private Animator animator;
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ninja-man");
            player = col.gameObject.GetComponent<UnarmedCharacter>();
            animator = col.gameObject.GetComponent<Animator>();
            player.attackCooldown -= 0.4f;
            player.celerity += 0.4f;
        }
    }

    private void Update()
    {
        if (animator.GetInteger("Weapon") == 0)
        {
            if (duration > 0)
            {
                duration -= Time.deltaTime;
            }
            else
            {
                duration = 6;
                player.attackCooldown += 0.4f;
                player.celerity -= 0.4f;
                Destroy(gameObject);
            }
        }
        else
        {
            duration = 6;
            player.attackCooldown += 0.4f;
            player.celerity -= 0.4f;
            Destroy(gameObject);
        }
    }
}
