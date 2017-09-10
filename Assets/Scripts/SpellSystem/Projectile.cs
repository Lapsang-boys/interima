using UnityEngine;

public class Projectile : MonoBehaviour {
	GameObject go; // The body that will be sent in the trajectory.
	float ttl; // Time-to-live. Projectile will be garbage collected after ttl have elapsed.

	public Projectile(GameObject go, float ttl) {
		this.go = go;
		this.ttl = ttl;
	}

	public void Launch(Vector3 towards, float thrust) {
		Debug.Log ("Launching!");
		// go.GetComponent<Rigidbody>().AddForce (towards * thrust);
		go.GetComponent<Rigidbody>().velocity = towards * 10;
	}

	public void OnCollisionEnter(Collision collision) {
		Debug.Log ("Hit the ground!");
		Destroy (this);
	}
}
