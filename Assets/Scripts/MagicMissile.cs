using UnityEngine;
using UnityEngine.Events;
using Timers;

public class MagicMissile : MonoBehaviour
{
	// 创造器
	[SerializeField] private MissileCreator creator;
	[SerializeField] private UnityEvent missileLaunch;


	// 发射魔法飞弹
	private void LaunchMissile()
	{
		creator.CreateMissile();
		missileLaunch.Invoke();
	}

	private void Awake()
	{
		TimersManager.SetLoopableTimer(this, 1, LaunchMissile);
	}
}
