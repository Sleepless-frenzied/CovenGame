using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;

    public void OnClick_CreateRoom()
    {
        //Create Room -> Erreur si la room existe
        //JoinOrCreateRoom -> Join la room si déjà existente
        if (!PhotonNetwork.IsConnected)
            return;
        RoomOptions options = new RoomOptions();
        options.IsVisible = true;
        while(_roomName.text.Trim(' ') == "")
        {

        }
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created succesfully.", this);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("ROOM CREATION FAILED:" + message, this);
    }
}
