using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
	[SerializeField]
	private Transform _content;

	[SerializeField] 
	private PlayerListings _playerlistings;

	private List<PlayerListings> _listings = new List<PlayerListings>();
	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
		if (!PhotonNetwork.IsConnected)
			return;
		
		foreach(var player in PhotonNetwork.CurrentRoom.Players)
        {
			PlayerListings list = Instantiate(_playerlistings);
        }

		/*
		PlayerListings listing = Instantiate(_playerlistings);

		if (listing != null)
        {
			listing.SetPlayerInfo(newPlayer);
			_listings.Add(listing);
        }*/
	}


    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
		int index = _listings.FindIndex(x => x.Player == otherPlayer);
		if (index != -1)
        {
			Destroy(_listings[index].gameObject);
			_listings.RemoveAt(index);
        }
    }
}
