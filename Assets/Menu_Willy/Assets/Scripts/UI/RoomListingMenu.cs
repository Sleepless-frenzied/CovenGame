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

    //private List<RoomInfo> _listings = new List<RoomListing>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
           /* if (info.RemovedFromList) // removed from rooms list
            {
                int index = _listings.FindIndex(x => x. == info.Name);
            }
            else // add to room list */
            //{   
                RoomListing listing = Instantiate(_roomlisting, _content);
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                }
            //}
        }
    }
}
