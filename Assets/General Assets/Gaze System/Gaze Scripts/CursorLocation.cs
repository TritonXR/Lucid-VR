using UnityEngine;
using System.Collections;

public class CursorLocation : MonoBehaviour {

	public int distance = 5; //affects distance of 3D object from cam
	bool oculus; //is Oculus being used?
	
	public GameObject mainCameraCursor; //normal camera
	public GameObject ovrCursor; //OVR rig
	public GameObject leftAnchor;
	public GameObject rightAnchor;

	// Use this for initialization
	void Start () {
		if (Camera.main == null) { //checks for Oculus
			oculus = true;
		}

		transform.localPosition = new Vector3(0, 0, distance);
		transform.localRotation = new Quaternion (0, 0, 0, 0);

		
		if (Camera.main != null) //checks for Oculus
		{
			//turns off OVR Cursor Cam
			ovrCursor.SetActive(false);
			
			//sets the cursor camera as a child of main camera
			mainCameraCursor.transform.parent = Camera.main.transform;
			
			//places camera at same position of main camera:
			mainCameraCursor.transform.localPosition = new Vector3 (0, 0, 0);
			mainCameraCursor.transform.localRotation = new Quaternion (0, 0, 0, 0);
			
			//disables UI layer on Main Camera (Handled by Cursor Cam)
			Camera.main.cullingMask = ~(1 << LayerMask.NameToLayer ("UI"));
		}
		
		else { //if OVR is being used
			
			//turns off normal Cursor Cam to use OVR instead
			mainCameraCursor.SetActive(false);
			
			/*
			 * Unnecessary, but here just in case
			 *
			//disables UI layer on normal Oculus cams
			leftAnchor.GetComponent<Camera>().cullingMask = 
				~(1 << LayerMask.NameToLayer ("UI"));
			rightAnchor.GetComponent<Camera>().cullingMask = 
				~(1 << LayerMask.NameToLayer ("UI"));
			*/
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3(0, 0, distance);
		transform.localRotation = new Quaternion (0, 0, 0, 0);
	}
}
