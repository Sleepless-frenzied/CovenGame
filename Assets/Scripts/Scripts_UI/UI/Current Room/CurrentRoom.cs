using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class CurrentRoom : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private TMP_Text _roomname;

    [SerializeField]
    private TMP_FontAsset _fontAsset;

    [SerializeField]
    public TMP_Text Playernumber;

    [SerializeField]
    private GameObject _buttons;
    /*[SerializeField]
    private TMP_InputField _input;
    public TMP_InputField Roomname
    {
        get => _roomname;
        set => _roomname = value;
    }*/

    private SelectCanvas _canvas;
    public void Initialize(SelectCanvas canvas)
    {
        _canvas = canvas;
    }
    public void show()
    {
        this.gameObject.SetActive(true);
    }

    public void hide()
    {
        this.gameObject.SetActive(false);
    }

    public void changeinfo(RoomOptions options, string name)
    {
        var max = options.MaxPlayers;
        Playernumber.text = max.ToString();

        /*var tmp = gameObject.AddComponent<TMP_Text>();
        Debug.Log(tmp);
        tmp.text = name;*/
       _roomname.text = name;


        if (!PhotonNetwork.IsMasterClient)
            _buttons.SetActive(false);
    }

}
