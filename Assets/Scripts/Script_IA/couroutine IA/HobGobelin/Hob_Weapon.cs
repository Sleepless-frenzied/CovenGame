using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Coven 
{ 
public class Hob_Weapon : MonoBehaviour
{
    public GameObject holder;
    protected bool IsHiting = false; 
    public void SetIsHiting(bool IsHiting)
    {
        this.IsHiting = IsHiting;
    }
    void OnTriggerStay(Collider collision) 
    {
        IA_Hob_Code script = holder.GetComponent<IA_Hob_Code>();
        if (IsHiting && collision.gameObject == script.GetTarget())
        {
            Debug.Log("hit");
            script.ApplyDamage(collision.gameObject);
            IsHiting = false;
        }
    }
    void Update()
    {
        IA_Hob_Code script = holder.GetComponent<IA_Hob_Code>();
        IsHiting = script.Getanimator().GetCurrentAnimatorStateInfo(0).IsName("attack02");
    }
}
}