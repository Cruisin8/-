using UnityEngine;
using UnityEngine.Events;
using Timers;

public class MagicMissile : MonoBehaviour
{
	// ������
	[SerializeField] private MissileCreator creator;
	[SerializeField] private UnityEvent missileLaunch;


	// ����ħ���ɵ�
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
