using UnityEngine;
using System.Collections;

public class SpawnScript_Cloud : MonoBehaviour {

	public GameObject[] obj;
	private float spawnMin = .07f;
	private float spawnMax = .5f;
	private float cloudPopup;

	// Use this for initialization
	void Start () {
		CloudySky ();
	}
	// Update is called once per frame
	void CloudySky () {
		cloudPopup = Random.Range (-5,5);
		if (transform.position.y >= 8f && transform.position.x > 27) 
		{
			Instantiate (obj [Random.Range (0, obj.Length)], new Vector3(transform.position.x ,transform.position.y - cloudPopup,0), Quaternion.identity);
		}
		Invoke ("CloudySky", Random .Range (spawnMin, spawnMax));
	}
}
