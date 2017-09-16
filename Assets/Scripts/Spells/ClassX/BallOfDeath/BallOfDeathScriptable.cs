using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/ClassX/BallOfDeath")]
public class BallOfDeathScriptable : Ability {
    // Spell parameters (set here)
    public float COOLDOWN = 3f;
    private int FORCE = 2000;


    //Needs to be set in inspector
    public GameObject projectilePrefab;
    public string aName = "New Ability";
    public Sprite aIcon;
    

    //Used in local scope
    private GameObject projectileBody;
    private GameObject caster;
    private Camera cam;
    private Vector3 position;

    public override void Initialize(GameObject caster) {
        this.caster = caster;
        this.setCoolDown(COOLDOWN);
        Debug.Log(COOLDOWN);
        this.setAbilityIcon(aIcon);
        //Camera used to get ray
        cam = caster.GetComponentInChildren<Camera>();
   }

    public override void TriggerAbility() {
        // Postitions and directions required
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        position = caster.transform.position;
        Vector3 direction = Vector3.Normalize(ray.direction); // Front
        Quaternion particleOrientation = Quaternion.LookRotation(direction);
        
        // Create a GameObject (the prefab assigned in the inspector)
        // - this prefab needs to have an onImpact script attatched to handle collisions etc
        projectileBody = (GameObject)Instantiate(projectilePrefab, position, particleOrientation);

        // Attatch a spell info to the projectile
        SpellInfo si = projectileBody.AddComponent<SpellInfo>();
        // --- Add info needed for handeling the spell after launch (collisions etc) ---
        si.caster = caster;
        // ---

        // TODO - answer if it would be possible to add an onimpact class to the projectila in the same way as we
        // attatch the spellinfo class

        // Apply force to the rigid body of the game object
        Rigidbody rb = projectileBody.GetComponent<Rigidbody>();
        //rb.useGravity = false;
        rb.position += direction * 0.2f;
        rb.AddForce(direction * FORCE);
    }
}
