using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
	[SerializeField] private Slider healthBar;
	[SerializeField] private Health health;

	// Ѫ������仯
	public void UpdateUI()
	{
		healthBar.value = health.Value;
	}

	// ���ó�ʼѪ��
	private void Awake()
	{
		healthBar.maxValue = health.Value;
		healthBar.value = health.Value;
	}
}
