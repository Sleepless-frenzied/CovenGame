using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCanvas : MonoBehaviour
{
	[SerializeField] private CreateOrJoinRoom _createOrJoinRoom;
	public CreateOrJoinRoom CreateOrJoinRoom => _createOrJoinRoom;

	[SerializeField] private CurrentRoom _currentRoom;

	public CurrentRoom CurrentRoom => _currentRoom;

	private void Awake()
	{
		FirstInitialize();	
	}

	private void FirstInitialize()
	{
		CurrentRoom.Initialize(this);
	}
}
