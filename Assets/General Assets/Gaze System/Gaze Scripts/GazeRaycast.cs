﻿using UnityEngine;
using System.Collections;

public class GazeRaycast : MonoBehaviour 
{
	public int lookActivationDistance = 500; //change how long the ray is (How far does the user have to be to activate?)
	public string interactTag = "Interactable"; //must be specified in Inspector to change

	[HideInInspector]
	public string loadTag = "Loadable";

	private float loadSeconds = 2.5f;

	public GameObject cursorAnimation;

	[HideInInspector]
	public bool eyesOpen; //checks if the users eyes are open

	[HideInInspector]
	public GameObject BlinkSystem; //the blink system

	Ray gazeRay; // the ray that will be raycasted

	[HideInInspector]
	public GameObject centerAnchor; //the center Eye anchor on the Oculus

	bool oculus = false;

	Animator cursorAnimator;

	bool cursorLoading;
	bool cursorLoaded;

	// Use this for initialization
	void Start () 
	{
		if (centerAnchor != null) 
		{
			oculus = true;
		}

		cursorAnimator = cursorAnimation.GetComponent<Animator> ();

		cursorAnimator.StartPlayback ();
	}

	void Update () {

		RaycastHit hit;

		//creates the ray to be Raycasted:
		if (oculus) {
			gazeRay = new Ray (centerAnchor.transform.position, centerAnchor.transform.forward);
		} 
		else {
			gazeRay = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		}

		//the actual raycast, will only raycast if eyes are open
		if ((!BlinkSystem || BlinkSystem.GetComponent<BlinkScript> ().eyesOpen)) {
			if (Physics.Raycast (gazeRay, out hit, lookActivationDistance)) {
				//specifies the tag that it should activate:
				if (hit.collider.tag == interactTag) {

					//calls Activate method of that object
					startCursorLoad(hit.collider.gameObject);
				}
				
				else {
					stopCursorLoad ();
				}	
			} 

			else {
				cursorLoaded = false;
				stopCursorLoad();
			}
		}
	}

	void stopCursorLoad() {

		if (cursorLoading) {
			StopCoroutine("cursorLoad");
			cursorAnimator.Rebind ();
			cursorAnimator.StartPlayback ();
			cursorLoading = false;
		}
	}

	void startCursorLoad(GameObject hit) {

		if (!cursorLoading && !cursorLoaded ) {
			StartCoroutine("cursorLoad", hit);
			cursorAnimator.StopPlayback ();
		}
	}

	void activateObject(GameObject obj) {
		obj.SendMessage ("Activate");
	}


	IEnumerator cursorLoad(GameObject hit) {

		//if the cursor isn't already loading
		if (!cursorLoading) {

			//set cursor loading
			cursorLoading = true;

			//wait for the load time
			yield return new WaitForSeconds (loadSeconds);

			//activate the actual object script
			activateObject (hit);

			//set the cursor to loaded
			cursorLoaded = true;

			//stop the loading process
			stopCursorLoad ();
		}
	}
}
