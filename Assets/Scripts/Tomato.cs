using UnityEngine;
using System.Collections;

public class Tomato : MonoBehaviour {

	public GameObject hitPrefab;
	public GameObject hitDecal;

	
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
			pos.z -= 0.5f;
			rot = Quaternion.LookRotation(this.GetComponent<Rigidbody>().velocity);
			rot.y += 90;
			Instantiate(hitDecal, pos, rot);
			Destroy(gameObject);
		}
	}
}
