using UnityEngine;
using System.Collections;

public class GazeConfigure : MonoBehaviour {
	
	public bool enableGazeSystem;
	public bool enableBlinkSystem;

	public int interactDistance = 500;
	public string interactTag = "Interactable";
	public int cursorDistance = 0;

	public GameObject centerAnchor;
	public GameObject gazeObject;
	public GameObject blinkObject;
	

	// Use this for initialization
	void Awake () {

		GazeRaycast gazeScript = gazeObject.GetComponent<GazeRaycast> ();
	

		gazeScript.interactTag = interactTag;
		gazeScript.centerAnchor = centerAnchor;
		gazeScript.BlinkSystem = blinkObject;




	}

	void Start() {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
