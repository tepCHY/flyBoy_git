using UnityEngine;
using System.Collections;

public class cloudBe : MonoBehaviour {
	Animator anim;
	void Awake()
	{
		anim = gameObject.GetComponentInChildren<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D other) 
	{
		if(other.tag == "Player")
		{
			alert();
		}
	}
	void alert()
	{
		rigidbody2D.velocity = new Vector2 (Random.Range (3,6),0);
		anim.SetBool ("inRange",true);
	}
}
