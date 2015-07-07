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

	void Update() {
		// Check if the poi exists
		if(poi == null) {
			return;
		}

//		easing = easing + Time.deltaTime * lerpSpeed;
//		lerpSpeed = lerpSpeed - Time.deltaTime;

		Vector3 destination = poi.transform.position;

		destination.x = Mathf.Max (minXY.x, destination.x);
		destination.y = Mathf.Max (minXY.y, destination.x);

		destination = Vector3.Lerp(transform.position, destination, easing);

		destination.z = camZ;

		transform.position = destination;

		this.GetComponent<Camera>().orthographicSize = this.GetComponent<Camera>().orthographicSize + destination.y;

	}

}