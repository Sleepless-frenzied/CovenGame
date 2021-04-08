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
    private GameObject _roomlisting;

    private List<GameObject> _listings = new List<GameObject>();


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (GameObject list in _listings)
        {
            Debug.Log("destroy the room", this);
            _listings.Remove(list);
            Destroy(list);
        }

        foreach (RoomInfo info in roomList)
        {
            Debug.Log("GET THE ROOM",this);
            GameObject room = Instantiate(_roomlisting, _content);
            room.transform.SetParent(_content);
            room.GetComponent<RoomListing>().SetRoomInfo(info);
            _listings.Add(room);


            /*if (info.RemovedFromList) // removed from rooms list
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
            }*/
        }
    }
}
