using UnityEngine;
using System.Collections;

public class LucidTimer : MonoBehaviour {

	public int sceneTime = 30;

	public GameObject blinkSystem;

	// Use this for initialization
	void Start () {
	
		StartCoroutine (SceneTimer ());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator SceneTimer() 
	{
		//waits for the normal warning message time to pass
		yield return new WaitForSeconds (sceneTime);

		blinkSystem.GetComponent<BlinkScript> ().Transition (0);
	}
}
