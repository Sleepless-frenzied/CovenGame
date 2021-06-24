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
            if (Random.Range(0,10)==1)
            {
                collision.gameObject.GetComponent<UnarmedCharacter>().status = Status.Stunned;
            }
            StopCoroutine(collision.gameObject.GetComponent<PlayerStat>().coroutine);
            collision.gameObject.GetComponent<PlayerStat>().SetDOT_Time(2);
            collision.gameObject.GetComponent<PlayerStat>().coroutine = StartCoroutine(collision.gameObject.GetComponent<PlayerStat>().GetOverTime());
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