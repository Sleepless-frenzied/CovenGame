using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
[Serializable]
public class Saving : MonoBehaviourPunCallbacks
{
	/*public void save (UnarmedCharacter player, int slot)
	{
		var damagePower = player.damagePower;
		var armorPower = player.armorPower;
		var healt = player.health;
		var mana = player.mana;
		var status = (int) player.status;
		var inventory = player.inventoryUI.GetComponent<InventoryUI>().inventory;
		var items = inventory.items;
		for (int i = 0; i < items.Count; i++)
		{
			int type;
			int eqslot;
			int pos;
			if (items[i] is Equipment)
			{
				var eq = (Equipment) items[i];
				type = (int) eq.weapontype;
				eqslot = (int) eq.equipSlot;
			}
		}
	}*/

	public string Savejson(UnarmedCharacter player, int saveslot)
	{
		var res = JsonUtility.ToJson(player);
		Debug.Log(res);
		return res;
	}
}
