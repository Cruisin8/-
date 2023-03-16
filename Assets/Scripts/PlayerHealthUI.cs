using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
	[SerializeField] private Slider healthBar;
	[SerializeField] private Health health;

	// 血条滑块变化
	public void UpdateUI()
	{
		healthBar.value = health.Value;
	}

	// 设置初始血量
	private void Awake()
	{
		healthBar.maxValue = health.Value;
		healthBar.value = health.Value;
	}
}
