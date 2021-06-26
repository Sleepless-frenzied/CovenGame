using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public Animator animator;
    
    public override void Interact()
    {
        animator.SetTrigger("Door");
        Debug.Log("door");
    }
}
