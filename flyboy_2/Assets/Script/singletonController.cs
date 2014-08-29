using UnityEngine;
using System.Collections;

public class singletonController : MonoBehaviour {

	public static singletonController instance;
	public float playerVerticalspeed,launchForce, launchDegree, playerPosX, playerPosY;
	public bool didLaunch;
	public int score,flapInSec;
	public float windSpeedCurrent50_40,windSpeedCurrent40_30,windSpeedCurrent30_20,windSpeedCurrent20_10;

	void Awake()
	{
		instance = this;
	}
	public void addScore(int num)
	{
		score += num;
	}

}
