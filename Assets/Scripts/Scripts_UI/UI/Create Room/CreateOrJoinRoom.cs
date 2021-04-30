using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoom : MonoBehaviour
{
	[SerializeField] private GameObject _this;
	
	private SelectCanvas _canvas;

	public void hide()
	{
		this.gameObject.SetActive(false);
	}
	
	public void show()
	{
		this.gameObject.SetActive(true);
	}
}
