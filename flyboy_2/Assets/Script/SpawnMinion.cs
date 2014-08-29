using UnityEngine;
using System.Collections;

public class SpawnMinion : MonoBehaviour {

	public GameObject[] obj;
	private float spawnMin = .1f;
	private float spawnMax = .2f;
	private float cloudPopup;

	
	// Use this for initialization
	void Start () {
		CloudySpawn ();
	}
	
	// Update is called once per frame
	void CloudySpawn () {
		cloudPopup = Random.Range (-5,5);
		if (transform.position.y >= 8f && transform.position.x > 27) 
		{
			GameObject temporary = Instantiate (obj [Random.Range (0, obj.Length)], new Vector3(transform.position.x ,transform.position.y - cloudPopup,0), Quaternion.identity) as GameObject;
			//temporary.gravityScale = 0;
			temporary.rigidbody2D.velocity = new Vector2 (-2,0);
		}
		Invoke ("CloudySpawn", Random .Range (spawnMin, spawnMax));
	}
}
