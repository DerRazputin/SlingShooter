using UnityEngine;
using System.Collections;

public class CloudCrafter : MonoBehaviour {

	// Inspector fields
	public int numClouds = 40;

	public Vector3 cloudPosMin;
	public Vector3 cloudPosMax;

	public float cloudScaleMin = 1.0f;
	public float cloudScaleMax = 5.0f;

	public float cloudSpeedMult = 0.5f;
	
	public GameObject[] cloudPrefabs;


	// Internal fields
	private GameObject[] cloudInstances;

	void Awake() {
		// Create an array large enough to sttore all cloud instances
		cloudInstances = new GameObject[numClouds];

		// Find the cloud anchor in the hierarchy
		GameObject anchor = GameObject.Find("ShittyCloud");

		// Iterate through array and create a cloud for each slot
		GameObject cloud;
		for (int i = 0; i < cloudInstances.Length; i++) {

			// Randomly pick one of the cloud instances
			int prefabNum = Random.Range (0, cloudPrefabs.Length);

			// Create that instance
			cloud = Instantiate (cloudPrefabs[prefabNum]);

			// Position and scale the cloud (randomly)
			Vector3 cPos = Vector3.zero;
			cPos.x = Random.Range (cloudPosMin.x, cloudPosMax.x);
			cPos.y = Random.Range (cloudPosMin.y, cloudPosMax.y);

			float scaleU = Random.value;
			float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);

			cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);

			cPos.z = 100 - 90*scaleU;
			
			// Apply these changes to our instance
			cloud.transform.position = cPos;
			cloud.transform.localScale = Vector3.one * scaleVal;

			// Make the cloud a child of our anchor
			cloud.transform.parent = anchor.transform;

			// Put the cloud into our instances array
			cloudInstances[i] = cloud;
		}
	}
}