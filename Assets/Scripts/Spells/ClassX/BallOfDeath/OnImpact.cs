using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpact : MonoBehaviour {
    public GameObject projectileBody;
    public GameObject onHitEffect;
    private Rigidbody rb;

    //private void Start() {
    //    Rigidbody rb = projectileBody.GetComponent<Rigidbody>();
    //}

    public void OnCollisionEnter(Collision collision)
    {
        SpellInfo si = projectileBody.GetComponent<SpellInfo>();

        if (collision.gameObject != si.caster) {
            Destroy(projectileBody);
            ContactPoint cp = collision.contacts[0];
            Quaternion rot = Quaternion.LookRotation(new Vector3(0, 0, 0), cp.normal);
            GameObject effect = (GameObject)Instantiate(onHitEffect, cp.point, rot);
            Destroy(effect, 1f);
        } 
    }

    private void HitPlayer() {
        // TODO Write case for hitting player, eg damage single target etc
    }

    private void HitOther() {
      // TODO Write case for hitting other projectile or environment, damage area etc
    }

    private void FixedUpdate() {
        // Need to fix a better reference instead of get componenet each fixed update
        projectileBody.transform.rotation = Quaternion.LookRotation(projectileBody.GetComponent<Rigidbody>().velocity);
        //projectileBody.transform.rotation = Quaternion.LookRotation(rb.velocity);
        //projectileBody.GetComponent<Rigidbody>().AddForce(new Vector3(0, -7, 0));

        // TODO implement ttl timer and destroy
    }

}
