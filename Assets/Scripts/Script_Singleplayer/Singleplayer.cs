using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class Singleplayer : MonoBehaviourPunCallbacks
{
	public void OnClick_StartSolo()
	{
		Debug.Log("1");
		PhotonNetwork.OfflineMode = true;
		if(PhotonNetwork.IsMasterClient)
		{
			Debug.Log("2");
			PhotonNetwork.LoadLevel("Level_1");
		}
	}
}
