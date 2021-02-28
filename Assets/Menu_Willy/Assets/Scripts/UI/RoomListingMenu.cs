using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{    
    [SerializeField]
    private Transform _content;

    [SerializeField]
    private RoomListing _roomlisting;


    private List<RoomListing> _listings = new List<RoomListing>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            if (info.RemovedFromList) // removed from rooms list
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name); // room name are unique donc on trouve la room
                if (index != -1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
            }
            else // added to room list 
            {   
                RoomListing listing = Instantiate(_roomlisting, _content);
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                    _listings.Add(listing);
                }
            }
        }
    }
}
