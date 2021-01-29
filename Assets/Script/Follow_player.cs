using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_player : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
   
    void Update()
    {
        this.transform.position = Player.position + offset;
    }
}
