using System;
using Photon.Realtime;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("interact");
    }
    /*private Transform Ybot;

    public Transform interactionTransform;

    private bool actif = false;
    
    private void Update()
    {
        if (actif && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distance = Vector3.Distance(Ybot.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            actif = true;
            //Physics.CheckSphere()
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            actif = false;
        }
    }*/
}
