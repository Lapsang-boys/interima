using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementPrototype1 : MonoBehaviour {

	public Camera cam;
	private Ray currentFacing;
	private Vector3 newPosition;
    private float speedFactor = 0.5f;

	void Update () {
		newPosition = transform.position;
		Quaternion q = transform.rotation;
		Quaternion qNew = transform.rotation;
		currentFacing = cam.ScreenPointToRay (Input.mousePosition);
		q.SetLookRotation (currentFacing.direction, new Vector3 (0, 1, 0));
		qNew = Quaternion.Slerp (qNew, q, Time.deltaTime);
			
		if (Input.GetKey (KeyCode.W)) {
			newPosition += currentFacing.direction * speedFactor;
		}
		if (Input.GetKey (KeyCode.S)) {
			newPosition -= currentFacing.direction * speedFactor;
		}

		Vector3 v;

		if (Input.GetKey (KeyCode.A)) {
			v = transform.TransformDirection( new Vector3 (-1, 0, 0));
			newPosition += v * speedFactor;
		} 
		if (Input.GetKey (KeyCode.D)) {
			v = transform.TransformDirection( new Vector3 (1, 0, 0));
			newPosition += v * speedFactor;
		}

		transform.SetPositionAndRotation (newPosition, qNew);
	}
}