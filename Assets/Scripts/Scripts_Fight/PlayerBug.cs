using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PlayerBug : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
        {
            camera.GetComponent<CameraFollow>().enabled = false;
            player.GetComponent<UnarmedCharacter>().enabled = false;
            UI.GetComponent<InventoryUI>().enabled = false;
            UI.GetComponent<EquipmentManager>().enabled = false;
            UI.GetComponent<Inventory>().enabled = false;
            UI.GetComponent<ConsumableManager>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.FindWithTag("Player").transform.position;
    }
}
