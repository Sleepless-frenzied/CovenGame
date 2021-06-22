using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace classEnemyC {
public class HitboxHit : MonoBehaviour
{
    public GameObject purple;
    public Vector3 decalage;
    protected bool IsHiting = false; 
    public void SetIsHiting(bool IsHiting)
    {
        this.IsHiting = IsHiting;
    }
    void OnCollisionEnter(Collision collision) 
    {
        IA_Albinos_code script = purple.GetComponent<IA_Albinos_code>();
        if (IsHiting && collision.gameObject == script.GetTarget())
        {
            Debug.Log("hit");
            script.ApplyDamage();
            IsHiting = false;
        }
    }
    void Update()
    {
        gameObject.transform.position = purple.transform.position + decalage;
        IA_Albinos_code script = purple.GetComponent<IA_Albinos_code>();
        IsHiting = script.Getanimator().GetCurrentAnimatorStateInfo(0).IsName("Basic attack")|| 
        script.Getanimator().GetCurrentAnimatorStateInfo(0).IsName("Claw Attack");
    }
}
}
