using UnityEngine;
using System.Collections;

public class movingTile01 : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) 
	{
		if(other.tag == "Player")
		{
			gameObject.transform.position = new Vector3 (transform.position.x + 40f, transform.position.y,0f);
		}
	}
}
