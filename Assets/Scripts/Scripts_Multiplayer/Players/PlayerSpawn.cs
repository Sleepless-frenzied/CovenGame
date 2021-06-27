using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpawn : MonoBehaviourPunCallbacks
{   
     void Start()
    {
        var pos = new Vector3(34,10,33);
        var rot = new Quaternion(0, 0, 0,0);

        PhotonNetwork.Instantiate("player",pos,rot);
    }

    // Start is called before the first frame update
    void Update()
    {
        //if (!photonView.IsMine && PhotonNetwork.IsConnected)
          //  return;
    }
}
