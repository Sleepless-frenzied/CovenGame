using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special4Collision : MonoBehaviour
{
    private float duration = 1;
    private UnarmedCharacter player;
    private Animator animator;
    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<CharacterController>().Move(col.transform.forward * 8 * Time.deltaTime);
        }
    }
}
