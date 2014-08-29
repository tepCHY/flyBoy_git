using UnityEngine;
using System.Collections;

public class DestroyerFront : MonoBehaviour {
	private Transform cam;
	// Use this for initialization
	void Awake ()
	{
		cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	void Update()
	{
		gameObject.transform.position = new Vector3 (cam.transform.position.x + 20, transform.position.y,0);
	}
	void OnTriggerEnter2D (Collider2D other) 
	{
		if(other.tag == "minion")
		{
			if (other.gameObject.transform.parent) 
			{
				Destroy (other.gameObject.transform.parent.gameObject);
			} 
			else 
			{
				Destroy (other.gameObject);
			}		
		}
			
	}

}
