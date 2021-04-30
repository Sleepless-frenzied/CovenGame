using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using System;


    public class PlayerListings : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _text;

        /*[SerializeField]
        private PlayerStat _stats;*/

        public Player Player { get; private set; }

        public void SetPlayerInfo(Player player)
        {
            Player = player;
            player.CustomProperties["health"] = 100;
            Debug.Log(player.CustomProperties["health"]);
            _text.text = Player.NickName;
        }
    }