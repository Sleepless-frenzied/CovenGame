using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField _roomName;
    public Toggle t2; // load toogle buttons
    public Toggle t3;
    public Toggle t4;

    [SerializeField] private TMP_FontAsset _fontAsset;

    [SerializeField] private GameObject _current;
    [SerializeField] private GameObject _old;

    [SerializeField] private CurrentRoom _currentRoom;
    
    private SelectCanvas _selectCanvas;
    private RoomOptions options = new RoomOptions();
    
    public void OnClick_CreateRoom()
    {
        //JoinOrCreateRoom -> Join la room si déjà existente

        if (!PhotonNetwork.IsConnected)
            return;// création options
        options.IsVisible = true;
        options.EmptyRoomTtl = 1000;
        
        if (_roomName.text.Trim() == "")
        {
            Debug.Log("invalid room name");
            return;
        }
        
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

        Debug.Log("CREATE ROOM PRESSED");
    }

    public void OnClick_LeaveRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        PhotonNetwork.LeaveRoom();
        Debug.Log("LEAVE ROOM PRESSED");
    }

    public void OnClick_StartGame()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            Debug.Log("Starting game ...");
            PhotonNetwork.LoadLevel("TUTORIAL_SCENE");
        }
    }
    
    public void OnClick_StartSolo()
    {
        PhotonNetwork.OfflineMode = true;
        options.MaxPlayers = 1;
        PhotonNetwork.JoinOrCreateRoom("solo",options , TypedLobby.Default);
        SceneManager.LoadSceneAsync("TUTORIAL_SCENE");
    }
    

    public override void OnCreatedRoom() // debug
    {
        Debug.Log("Room created succesfully.", this);
    }

    public override void OnJoinedRoom()
    {
        _currentRoom.changeinfo(options, _roomName.text);
         
        _current.SetActive(true);
        _old.SetActive(false);

    }

    public override void OnLeftRoom()
    {
        _current.SetActive(false);
        _old.SetActive(true);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("ROOM CREATION FAILED:" + message, this);
    }
}
