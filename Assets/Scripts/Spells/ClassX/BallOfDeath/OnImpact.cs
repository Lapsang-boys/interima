using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpact : MonoBehaviour {
    public GameObject projectileBody;
    public GameObject onHitEffect;

    public void OnCollisionEnter(Collision collision)
    {
        SpellInfo si = projectileBody.GetComponent<SpellInfo>();
        Debug.Log("Hit:");
        Debug.Log(collision.gameObject);
        Debug.Log("Caster:");
        Debug.Log(si.caster);
        if (collision.gameObject != si.caster) {
            Destroy(projectileBody);
            ContactPoint cp = collision.contacts[0];
            Quaternion rot = Quaternion.LookRotation(new Vector3(0, 0, 0), cp.normal);
            GameObject effect = (GameObject)Instantiate(onHitEffect, cp.point, rot);
            Destroy(effect, 1f);
        } 
    }
}
