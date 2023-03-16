using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
	[SerializeField] private int health;
	[SerializeField] private UnityEvent<int> healthChanged;

	// 获取当前血量
	public int Value 
	{
		get { return health; }
	}

	// 受伤
	public void DecreaseHealth(int amount)
	{
		health -= amount;
		healthChanged.Invoke(health);
	}
}
