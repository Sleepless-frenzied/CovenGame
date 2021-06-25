using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Coven {
public class PlayerWeapon : MonoBehaviour
{
    bool isHiting;
    GameObject player;
    IA_Albinos_code Dragon;
    IA_Hob_Code Hob;
    IA_Skeleton_code Skeleton;

    public void SetIsHiting(bool isHiting)
    {
        this.isHiting=isHiting;
    }
    public void SetPlayer(GameObject player)
    {
        this.player=player;
    }
    public string GetScript(GameObject mob)
    {
        try
        {
            Skeleton = mob.GetComponent<IA_Skeleton_code>();
            return "Skeleton";
        }
        catch (System.NullReferenceException)
        {
            try
            {
                Hob = mob.GetComponent<IA_Hob_Code>();
                return "Hob";
            }
            catch (System.NullReferenceException)
            {
                Dragon = mob.GetComponent<IA_Albinos_code>();
                return "Dragon";
            }
        }
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (isHiting && collider.gameObject.tag == "mob" )
        {
            PlayerStat playerStat = player.GetComponent<PlayerStat>();
            switch (GetScript(collider.gameObject))
            {
                case "Hob" : Hob.TakeDamage(playerStat);
                             break;
                case "Dragon" : Dragon.TakeDamage(playerStat);
                                break;
                case "Skeleton" : Skeleton.TakeDamage(playerStat);
                                  break;
                default: break;
            }
            isHiting = false;
        }
    }
}}
