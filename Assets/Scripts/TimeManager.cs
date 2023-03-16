using UnityEngine;

public class TimeManager : MonoBehaviour
{
	// 停止时间流逝
	public void Stop()
	{	
		Time.timeScale = 0;
	}

	// 时间正常流逝
	public void Resume()
	{
		Time.timeScale = 1;
	}
}
