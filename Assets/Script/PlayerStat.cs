using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    protected int health=1000000;
    protected int damage;
    protected int allow_attack;
    protected int stability;
    protected int knockBack;
    public int GetDamage()
    {
        return damage;
    }
    public int GetKnockBack()
    {
        return knockBack;
    }
    public void TakeDamage(int dammage,int KB)
    {
        health-=dammage;
        if (health<=0)
        {
            //joue l'animation de mort
            Destroy(this.gameObject,3);
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(0,(KB-stability)/2,stability-KB,ForceMode.Impulse);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (/*bool anim attack is true*/true && collision.gameObject.tag=="mob")
        {
            ApplyDamage(collision.gameObject);
        }
    }
    public void ApplyDamage(GameObject OurTarget)
    {
        OurTarget.SendMessage("TakeDamage",this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
