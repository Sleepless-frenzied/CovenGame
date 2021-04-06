using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField _roomName;

    public Toggle t2; // load toogle buttons
    public Toggle t3;
    public Toggle t4;

    public void OnClick_CreateRoom()
    {
        //JoinOrCreateRoom -> Join la room si déjà existente

        if (!PhotonNetwork.IsConnected)
            return;
        RoomOptions options = new RoomOptions(); // création options
        options.IsVisible = true;

        if (t2.isOn) // selection le nbr de joueur pour la room
        {
            options.MaxPlayers = 2;
        }
        if (t3.isOn)
        {
            options.MaxPlayers = 3;
        }
        if (t4.isOn)
        {
            options.MaxPlayers = 4;
        }
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default); // créer la room
    }

    public override void OnCreatedRoom() // debug
    {
        Debug.Log("Room created succesfully.", this);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("ROOM CREATION FAILED:" + message, this);
    }
}
