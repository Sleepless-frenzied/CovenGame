using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    public Mesh mesh;

    public override void Interact()
    {
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
