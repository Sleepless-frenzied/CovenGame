using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        print("connecting ...");
        PhotonNetwork.GameVersion = "0.0";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("connected");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("disconnected :" + cause.ToString());
    }

}
