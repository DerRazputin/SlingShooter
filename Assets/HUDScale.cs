using UnityEngine;
using System.Collections;

public class HUDScale : MonoBehaviour {

	GameObject camera;
	float startFactor;
	Vector3 targetScale;

	// Use this for initialization
	void Start () {
		camera = gameObject.transform.parent.gameObject;
		startFactor = camera.GetComponent<Camera>().orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		targetScale.x = camera.GetComponent<Camera>().orthographicSize / startFactor;
		targetScale.y = camera.GetComponent<Camera>().orthographicSize / startFactor;
		targetScale.z = camera.GetComponent<Camera>().orthographicSize / startFactor;

		transform.localScale = targetScale;
	}
}
