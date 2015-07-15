using UnityEngine;
using System.Collections;

public class BreakObject : MonoBehaviour {

	public GameObject fracturePrefab;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.collider.tag == "Projectile") {
			Destroy(gameObject);
			Instantiate(fracturePrefab, transform.position, transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
