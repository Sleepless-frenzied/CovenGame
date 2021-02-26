using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    public RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roominfo)
    {
        RoomInfo = roominfo;
        _text.text = roominfo.Name + " / " + roominfo.MaxPlayers;
    }

}
