using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class Saving : MonoBehaviour
{
	public void save (UnarmedCharacter player, int slot)
	{
		var damagePower = player.damagePower;
		var armorPower = player.armorPower;
		var healt = player.health;
		var mana = player.mana;
		int status = (int) player.status;
		
	}
}
