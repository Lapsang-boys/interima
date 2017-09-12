using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOfDeath : MonoBehaviour {
	Vector3 position;
	public GameObject caster;
    private Camera cam;
    private GameObject projectileBody;
    public GameObject projectilePrefab;

    private void Awake() {
        // Camera used to get ray
        cam = caster.GetComponentInChildren<Camera>();
    }

    public void FireProjectile() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        // Postition derived from caster and direction derived from ray
        position = caster.transform.position;
        Vector3 direction = Vector3.Normalize(ray.direction);

        // Create a GameObject (the prefab assigned in the inspector) 
        projectileBody = (GameObject)Instantiate(projectilePrefab, position, Quaternion.identity);

        // Attatch a spell info to the projectile
        SpellInfo si = projectileBody.AddComponent<SpellInfo>();
        // --- Add info needed for handeling the spell after launch (collisions etc) ---
        si.caster = caster;
        // ---
        Debug.Log(si);

        // Apply force to the rigid body of the game object
        Rigidbody rb = projectileBody.GetComponent<Rigidbody>();
        rb.position += direction * 2;
        rb.AddForce(direction * 1000);
    }
		
    void Update () {
        // Listen for input (left mouse button)
		if (Input.GetMouseButtonDown(0)) {
			FireProjectile ();
		}
	}
}
