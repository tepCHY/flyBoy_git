using UnityEngine;
using System.Collections;

public class CameraFlyerFollow : MonoBehaviour {

	// Use this for initialization
	private Transform player;		// Reference to the player's transform.
	private float camPosY;
	private float camPosX;
	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	// Update is called once per frame
	void Update () {
		moveCam ();
		//transform.position = new Vector3 (player.position.x + 6, player.position.y,-10);
	}
	void moveCam()
	{
		if (player.position.y >= 44) 
		{
			camPosY = 44;
		} 
		else if (player.position.y <= 5) 
		{
			camPosY = 5;
		} 
		else 
		{
			camPosY = player.position.y;
		}

		if (player.position.x < transform.position.x - 6) 
		{
			camPosX = transform.position.x;
		}
		else
		{
			camPosX = player.position.x + 5;
		}
		transform.position = new Vector3 (camPosX, camPosY,-10);
	}
}
