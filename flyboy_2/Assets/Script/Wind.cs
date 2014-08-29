using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {
	private float weatherChangesDuration01;

	//private float[][][] windSpeed; // [LV][hight][max /min]
	private float windSpeedMax = 3f;
	private float windSpeedMin = -3f;
	//private float windSpeedCurrent50_40,windSpeedCurrent40_30,windSpeedCurrent30_20,windSpeedCurrent20_10;


	// Use this for initialization
	void Start () 
	{
		windGenerate50_40 ();
		windGenerate40_30 ();
		windGenerate30_20 ();
		windGenerate20_10 ();
	}	
	void windGenerate50_40()
	{
		singletonController.instance.windSpeedCurrent50_40 = Random.Range (-.1f,.10f);
		float weatherChangesDuration = Random.Range (7f, 15f);
		Invoke ("windGenerate50_40", weatherChangesDuration);
	}
	void windGenerate40_30()
	{
		singletonController.instance.windSpeedCurrent40_30 = Random.Range (-.02f,.02f);
		float weatherChangesDuration = Random.Range (10, 20);
		Invoke ("windGenerate40_30", weatherChangesDuration);
	}
	void windGenerate30_20()
	{
		singletonController.instance.windSpeedCurrent30_20 = Random.Range (-.004f,.004f);
		float weatherChangesDuration = Random.Range (12, 25);
		Invoke ("windGenerate30_20", weatherChangesDuration);
	}
	void windGenerate20_10()
	{
		singletonController.instance.windSpeedCurrent20_10 = Random.Range (-.0008f,.0008f);
		float weatherChangesDuration = Random.Range (15, 30);
		Invoke ("windGenerate20_10", weatherChangesDuration);
	}
	
}


