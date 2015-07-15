using UnityEngine;
using System.Collections;

public class Tomato : MonoBehaviour {

	public GameObject hitPrefab;
	public GameObject hitDecal;
	public float radius = 50.0F;
	public float power = 100.0F;

	
	// Update is called once per frame
	void Update () {
		this.transform.rotation = Quaternion.LookRotation(this.GetComponent<Rigidbody>().velocity);	
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.relativeVelocity.magnitude > 10) {
			ContactPoint contact = collision.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			Instantiate(hitPrefab, pos, rot);
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
			foreach (Collider hit in colliders) {
				Rigidbody rb = hit.GetComponent<Rigidbody>();
				
				if (rb != null)
					rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
				
			}
			Destroy(gameObject);
		}
	}
}
