using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chest : Interactable
{
    public Mesh mesh;
    public GameObject bagWeapon;
    public GameObject bagArmor;
    public GameObject bagItem;

    public override void Interact()
    {
        GetComponent<MeshFilter>().mesh = mesh;
        Destroy(transform.GetChild(0).gameObject);
        if (Random.Range(0,10) >= 3)
            Instantiate(bagWeapon, transform);
        if (Random.Range(0,10) >= 3)
            Instantiate(bagArmor, transform);
        if (Random.Range(0,10) >= 2)
            Instantiate(bagItem, transform);


        gameObject.layer = 9;
    }
}
