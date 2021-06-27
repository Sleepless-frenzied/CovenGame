using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PlayerBug : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
