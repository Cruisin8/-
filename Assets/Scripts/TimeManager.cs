using UnityEngine;

public class TimeManager : MonoBehaviour
{
	// ֹͣʱ������
	public void Stop()
	{	
		Time.timeScale = 0;
	}

	// ʱ����������
	public void Resume()
	{
		Time.timeScale = 1;
	}
}
