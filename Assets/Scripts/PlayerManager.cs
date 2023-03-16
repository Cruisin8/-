using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	[SerializeField] private Transform playerTransform;

	private static PlayerManager _instance;

	// µ±«∞Œª÷√
	public static Vector2 Position 
	{
		get { return _instance.playerTransform.position; }
	}

	private void Awake()
	{
		_instance = this;
	}
}
