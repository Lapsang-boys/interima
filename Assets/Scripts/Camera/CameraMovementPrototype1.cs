using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementPrototype1 : MonoBehaviour {

	public Camera cam;
	private Ray currentFacing;
	private Vector3 newPosition;

	void Update () {
		newPosition = transform.position;
		Quaternion qNew = transform.rotation;
		if (Input.GetMouseButton (1)) {
			Quaternion q = transform.rotation;
			currentFacing = cam.ScreenPointToRay (Input.mousePosition);
			q.SetLookRotation (currentFacing.direction, new Vector3 (0, 1, 0));
			qNew = Quaternion.Slerp (qNew, q, Time.deltaTime);
		}
			
		if (Input.GetKey (KeyCode.W)) {
			newPosition += currentFacing.direction;
		}
		if (Input.GetKey (KeyCode.S)) {
			newPosition -= currentFacing.direction;
		}

		Vector3 v;

		if (Input.GetKey (KeyCode.A)) {
			v = transform.TransformDirection( new Vector3 (-1, 0, 0));
			newPosition += v;
		} 
		if (Input.GetKey (KeyCode.D)) {
			v = transform.TransformDirection( new Vector3 (1, 0, 0));
			newPosition += v;
		}

		transform.SetPositionAndRotation (newPosition, qNew);
	}
}