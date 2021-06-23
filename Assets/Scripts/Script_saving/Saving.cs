using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class Saving : MonoBehaviour
{
	public void Serialize(Player player)
	{
		var _name = player.NickName;
		var _properties = player.CustomProperties;
		
	}
}
