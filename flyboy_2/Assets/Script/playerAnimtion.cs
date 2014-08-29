using UnityEngine;
using System.Collections;

public class playerAnimtion : MonoBehaviour {
	
	Animator anim;

	void Awake () {
		anim = GetComponent<Animator> ();
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		anim.SetBool ("isLaunching",singletonController.instance.didLaunch); //start anime
		anim.SetFloat ("launchingFloat",singletonController.instance.launchForce); 
		anim.SetFloat ("velocityY",singletonController.instance.playerVerticalspeed);
		anim.SetFloat ("positionY", singletonController.instance.playerPosY);
		anim.SetInteger ("flapInSec",singletonController.instance.flapInSec);
	}
}
