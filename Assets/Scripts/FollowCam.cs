using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public static FollowCam S; // Singleton Follow Cam Instance

	public GameObject poi;

	private float camZ;
	public float easing;

	public Vector2 minXY;

	private Vector3 start;
	private float startTime;
	public float lerpSpeed;

	void Awake() {
		S = this;
		camZ = transform.position.z;
		start = transform.position;
	}

	void Start() {
		startTime = Time.time;
	}

	void FixedUpdate() {

		Vector3 destination;

		// Check if the poi exists
		if(poi == null) {
			// set the poi to the slingshot (zero vector)
			destination = Vector3.zero;
		} else {
		// else (there is a poi)

		destination = poi.transform.position;

			// is the poi a projectile ?
			if(poi.tag == "Projectile") {

				//check if it is resting (sleeping)
				if(poi.GetComponent<Rigidbody>().IsSleeping()){
					// se tthe poi to default (null)
					poi = null;
					return;
				}
			}
		}

		destination.x = Mathf.Max (minXY.x, destination.x);
		destination.y = Mathf.Max (minXY.y, destination.y);

		destination = Vector3.Lerp(transform.position, destination, easing);

		destination.z = camZ;

		transform.position = destination;

		this.GetComponent<Camera>().orthographicSize = 10 + destination.y;
	}
}