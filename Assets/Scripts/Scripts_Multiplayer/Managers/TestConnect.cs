using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Realtime;
using Photon.Pun;

public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start() // connecte au serveur Photon
    {
        print("connecting ...");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.Username; // définie le username a partir du script GameSettings
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion; // définie la version du jeu a partir du script GameSettings
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() // si succes
    {
        print("connected");
        print(PhotonNetwork.LocalPlayer.NickName); // affiche le username depuis le serveur distant

        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause) // retourne les causes de déconncetions
    {
        print("disconnected :" + cause.ToString());
    }

}
