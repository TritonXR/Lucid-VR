/*
 * Description: This script will place either a normal camera
 * or an OVR camera as a child of either the main camera or the
 * main OVR camera. This new camera only renders the UI layer - 
 * which contains the cursor. Therefore, the user will always
 * be able to see the UI layer from the perspective of this camera,
 * which is overlayed onto the main camera being used
 * */

using UnityEngine;
using System.Collections;

public class RenderCursor : MonoBehaviour {

	public GameObject mainCameraCursor; //normal camera
	public GameObject ovrCursor; //OVR rig
	public GameObject leftAnchor;
	public GameObject rightAnchor;

	// Use this for initialization
	void Start () {

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
	void Update () 
	{
	}
}
