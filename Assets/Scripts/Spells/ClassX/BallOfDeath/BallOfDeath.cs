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
        // Postitions and directions required
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        position = caster.transform.position;
        Vector3 direction = Vector3.Normalize(ray.direction); // Front
        Quaternion particleOrientation = Quaternion.LookRotation(direction);
        
        // Create a GameObject (the prefab assigned in the inspector) 
        projectileBody = (GameObject)Instantiate(projectilePrefab, position, particleOrientation);

        // Attatch a spell info to the projectile
        SpellInfo si = projectileBody.AddComponent<SpellInfo>();
        // --- Add info needed for handeling the spell after launch (collisions etc) ---
        si.caster = caster;
        // ---
        Debug.Log(si);

        // TODO - answer if it would be possible to add an onimpact class to the projectila in the same way as we
        // attatch the spellinfo class

        // Apply force to the rigid body of the game object
        Rigidbody rb = projectileBody.GetComponent<Rigidbody>();
        //rb.useGravity = false;
        rb.position += direction * 0.2f;
        rb.AddForce(direction * 2000);
    }
		
    void Update () {
        // Listen for input (left mouse button)
		if (Input.GetMouseButtonDown(0)) {
			FireProjectile ();
		}
	}
}
