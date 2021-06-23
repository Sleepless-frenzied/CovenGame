using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace classEnemyC {
public class HitboxHit : MonoBehaviour
{
    public GameObject purple;
    //public Vector3 decalage;
    protected bool IsHiting = false; 
    public void SetIsHiting(bool IsHiting)
    {
        this.IsHiting = IsHiting;
    }
    void OnTriggerStay(Collider collision) 
    {
        IA_Albinos_code script = purple.GetComponent<IA_Albinos_code>();
        if (IsHiting && collision.gameObject.tag == "Player")
        {
            IsHiting = false;
            Debug.Log("hit purple");
            script.ApplyDamage(collision.gameObject);
        }
    }
    void Update()
    {
        Debug.Log(IsHiting);
        //transform.position = purple.transform.position + decalage;
        IA_Albinos_code script = purple.GetComponent<IA_Albinos_code>();
        IsHiting = script.Getanimator().GetCurrentAnimatorStateInfo(0).IsName("Basic attack")|| 
        script.Getanimator().GetCurrentAnimatorStateInfo(0).IsName("Claw Attack");
    }
}
}
