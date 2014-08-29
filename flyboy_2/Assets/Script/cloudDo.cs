using UnityEngine;
using System.Collections;

public class cloudDo : MonoBehaviour {
	Animator anime;
	void OnTriggerEnter2D (Collider2D other) 
	{
		if(other.tag == "Player")
		{
			anime = other.GetComponentInChildren<Animator>();
			anime.Play("flappingWing");
			other.rigidbody2D.velocity = new Vector2(other.rigidbody2D.velocity.x, 0);
			other.rigidbody2D.velocity = new Vector2(other.rigidbody2D.velocity.x, other.rigidbody2D.velocity.y + 5); //speed to player
			Destroy(transform.parent.gameObject);
		}
	}
}
