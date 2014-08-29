using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	private float getDegree;
	public float launchForce;

	private float setRadial, forceX, forceY;
	public bool isBeginFlying = false;

	//flapping
	private float liftForce = 10f;
	private float lungCapacity = 100f;
	private float o2inTake = 10f;
	private float regainningStrength = .05f;
	private float currentInTake = 0f;
	private int flownRate = 5;
	private int stackflown;
	//

	//wind
	private float windSpeedCurrent50_40,windSpeedCurrent40_30,windSpeedCurrent30_20,windSpeedCurrent20_10;

	//
	void Start () 
	{
			InvokeRepeating ("transformForce", 0, 0.1f);
	}
	void OnGUI()
	{
		GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), currentInTake + " / " + (int)lungCapacity);
		GUI.Box (new Rect (Screen.width - 100,0,100,75),  windSpeedCurrent50_40 + "\n" + windSpeedCurrent40_30 + "\n"+ windSpeedCurrent30_20 + "\n"+ windSpeedCurrent20_10 + "\n");
		GUI.Box (new Rect (0,Screen.height - 50,100,50), "Ysp = " + (int)rigidbody2D.velocity.y+"\n" + " Xsp = "+ (int)rigidbody2D.velocity.x);
	}
	void FixedUpdate()
	{
		windSpeedCurrent50_40 = singletonController.instance.windSpeedCurrent50_40;
		windSpeedCurrent40_30 = singletonController.instance.windSpeedCurrent40_30;
		windSpeedCurrent30_20 = singletonController.instance.windSpeedCurrent30_20;
		windSpeedCurrent20_10 = singletonController.instance.windSpeedCurrent20_10;
		if(rigidbody2D.velocity.x > 0 && singletonController.instance.didLaunch )
		{
			if(transform.position.y >= 40)
			{
				if(rigidbody2D.velocity.x < 40 && rigidbody2D.velocity.x >1)
				{
					rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + windSpeedCurrent50_40,rigidbody2D.velocity.y);
				}
			}
			else if (transform.position.y >= 30 && transform.position.y < 40)
			{
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + windSpeedCurrent40_30,rigidbody2D.velocity.y);
			}
			else if(transform.position.y >= 20 && transform.position.y < 30)
			{
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + windSpeedCurrent30_20,rigidbody2D.velocity.y);
			}
			else if(transform.position.y >= 10 && transform.position.y < 20)
			{
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + windSpeedCurrent20_10,rigidbody2D.velocity.y);
			}
			else if (transform.position.y < 10)
			{
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x - 0.0001f,rigidbody2D.velocity.y);
			}
		}


		singletonController.instance.playerVerticalspeed = rigidbody2D.velocity.y;
		singletonController.instance.playerPosY = transform.position.y;
		singletonController.instance.playerPosX = transform.position.x;
		if (singletonController.instance.didLaunch && currentInTake < lungCapacity - o2inTake) 
		{

			if (Input.GetKeyUp (KeyCode.Space)) 
			{
				flap();
			}

			/*
			for (int i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);
				
				// -- Tap: quick touch & release
				// ------------------------------------------------
				if (touch.phase == TouchPhase.Ended && touch.tapCount == 1)
				{
					flap();
				}
			}
			*/
		
		}
		if(currentInTake > 0f)
		{
			currentInTake = currentInTake - regainningStrength;
		}
	}
	
	void transformForce()
	{
		getDegree = singletonController.instance.launchDegree;
		launchForce = singletonController.instance.launchForce;

		setRadial = getDegree * Mathf.Deg2Rad;
		forceX =  Mathf.Cos(setRadial) * launchForce;
		forceY = Mathf.Sin(setRadial) * launchForce;
		transform.rigidbody2D.AddForce(transform.right  * forceX);
		transform.rigidbody2D.AddForce(transform.up  * forceY);
	
		if (singletonController.instance.didLaunch) 
		{

			CancelInvoke("transformForce"); // InvokeRepeating
		}
	}
	void flap()
	{
		StartCoroutine (fadeFlapping());
		if(rigidbody2D.velocity.y < 0)
		{
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x,0);
		}
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x,liftForce);
		currentInTake = currentInTake + o2inTake;

	}

	IEnumerator fadeFlapping()
	{
		StartCoroutine(flownTime(flownRate));
		for(int i = 10; i >= 0; i-- )
		{
			singletonController.instance.flapInSec = i;
			yield return 0;
		}
	}
	IEnumerator flownTime(int num)
	{
		stackflown = stackflown + num;
		for(int i = stackflown ; i >= 0; i-- )
		{
			stackflown = i;
			rigidbody2D.gravityScale = 0.7f;
			yield return 0;
		}
		rigidbody2D.gravityScale = 1f;
	}
	/*
	void easeInOutQuad (float currentPosition , float start , float chage, float distace)
	{
		currentPosition /= distace / 2;
		if (currentPosition < 1)
			return chage / 2 * currentPosition * currentPosition + start;
		currentPosition--;
		return -chage / 2 * (currentPosition (currentPosition - 2) - 1) + start;
	}
	*/
}
