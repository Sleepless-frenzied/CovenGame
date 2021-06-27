using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
[Serializable]
public class Saving : MonoBehaviourPunCallbacks
{
	public void save (UnarmedCharacter player, int slot)
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
	}

	public void Savejson(UnarmedCharacter player, int saveslot = 0)
	{
		
		var res = JsonUtility.ToJson(player);
		Debug.Log(res);
		var path = "/save" + saveslot.ToString();
		if (File.Exists(path))
		{
			throw new NotImplementedException();
		}

		using (var sw = new StreamWriter(path))
		{
			sw.Write(res);
			Debug.Log("");
			sw.Close();
		}
	}

	public UnarmedCharacter LoadJson(string path, int slot)
	{
		var file = path + slot.ToString();
		
		try
		{
			var reader = new StreamReader(file);
			var json = reader.ReadToEnd();
			var player = JsonUtility.FromJson<UnarmedCharacter>(json);
			return player;
		}
		catch
		{
			Debug.Log("Saving.cs : Error loadjson");
		}

		return new UnarmedCharacter();
	}
	
}
