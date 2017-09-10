using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOfDeath : MonoBehaviour {
	private Projectile p;
	Vector3 position;
	public GameObject caster;

	// Use this for initialization
	void Start () {
		
	}

	public void Shoot() {
		Camera cam = caster.GetComponent<Camera> ();
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);


		Vector3 towards = Input.mousePosition;

		position = caster.transform.position;
		Vector3 direction = towards - position;

		GameObject go = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		go.transform.position = position;
		SphereCollider col = go.AddComponent<SphereCollider> ();
		Rigidbody gameObjectsRigidBody = go.AddComponent<Rigidbody> ();

		gameObjectsRigidBody.position = position;
		gameObjectsRigidBody.mass = 1;
		gameObjectsRigidBody.detectCollisions = true;




		p = new Projectile(
			go: go,
		 	ttl: 5
		 );

		Debug.Log ("Before launch!");
		Debug.Log (position);
		Debug.Log (gameObjectsRigidBody.position);
		p.Launch(Vector3.Normalize(ray.direction), 2000);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log ("Shooting!");
			Shoot ();
		}
	}
}
