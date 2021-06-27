using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DialogueStart : Interactable
{
    public Dialogue dialogue;
    public override void Interact()
    {
        base.Interact();
        //dialoguebox.SetActive(true);
        GetComponentInChildren<DialogueManager>().StartDialogue(dialogue);
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        
    }
    
    
}
