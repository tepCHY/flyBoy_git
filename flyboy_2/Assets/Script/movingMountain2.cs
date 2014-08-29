using UnityEngine;
using System.Collections;

public class movingMountain2 : MonoBehaviour {
	void OnTriggerEnter2D (Collider2D other) 
	{
		if(other.tag == "Player")
		{
			gameObject.transform.position = new Vector3 (transform.position.x + 136f, transform.position.y,0f);
		}
	}

}
