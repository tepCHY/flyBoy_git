using UnityEngine;
using System.Collections;

public class laurch_sequence : MonoBehaviour {

	private int maxAngularLaunch, minAngularLaunch;
	public float launchMomentum, finalMomentum;
	public float launchMomentumInserMin = 500f;
	public float launchMomentumInsertMax = 2000f;
	private bool isAugularDone, isLaunchDone = false;
	public int stepAugular  = 3;
	public float stepMomentum = 100f;
	public float stepInterval = .02f;
	public int pointedAugularLaunch;
	Animator anim;
	// Use this for initialization


	private bool tester1,tester2 = false;

	void Start () {
		anim = GetComponent<Animator> ();
		maxAngularLaunch = 70;
		minAngularLaunch = 20;
		pointedAugularLaunch = 21;
		InvokeRepeating("AugularLaunchScale",.1f,stepInterval);
	}

	void Update()
	{
		/*
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			
			// -- Tap: quick touch & release
			// ------------------------------------------------
			if (touch.phase == TouchPhase.Ended && touch.tapCount == 1)
			{

				if(tester1)
				{
					tester2 = true;
				}
				tester1 = true;
			}
		}
		*/
	}

	void AugularLaunchScale()
	{
		if(Input.GetKeyDown(KeyCode.Space))//(Input.GetKeyDown(KeyCode.Space))
		{
			isAugularDone = true;
			print("Final_Angle = " + pointedAugularLaunch);
			singletonController.instance.launchDegree = pointedAugularLaunch;
			CancelInvoke("AugularLaunchScale");
			InvokeRepeating("LaunchMomentumScale",.5f,stepInterval);
		}
		if (!isAugularDone) 
		{

			if (pointedAugularLaunch <= minAngularLaunch) 
						{
							pointedAugularLaunch = minAngularLaunch;
							stepAugular = Mathf.Abs(stepAugular);
							
						}
						if (pointedAugularLaunch >= maxAngularLaunch) 
						{
							pointedAugularLaunch = maxAngularLaunch;
							stepAugular = stepAugular * -1;
						} 
			pointedAugularLaunch = pointedAugularLaunch + stepAugular;
		}
	}

	void LaunchMomentumScale()
	{
		if(Input.GetKeyDown(KeyCode.Space))//(Input.GetKeyDown(KeyCode.Space))
		{
			isLaunchDone = true;
			singletonController.instance.didLaunch = isLaunchDone;
			print("Final_Momentim = " + launchMomentum);
			finalMomentum = launchMomentum;
			singletonController.instance.launchForce = finalMomentum;
			anim.SetBool ("didLaunch",isLaunchDone);
			CancelInvoke("LaunchMomentumScale");
		}
		if (!isLaunchDone) 
		{
			launchMomentum = launchMomentum + stepMomentum;
			if (launchMomentum <= launchMomentumInserMin) 
			{
				launchMomentum = launchMomentumInserMin;
				stepMomentum = Mathf.Abs(stepMomentum);
				
			}
			if (launchMomentum >= launchMomentumInsertMax) 
			{
				launchMomentum = launchMomentumInsertMax;
				stepMomentum = stepMomentum * -1;	
			} 
			
		}
		
	}

	
}



