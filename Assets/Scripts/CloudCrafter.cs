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
	public GameObject cloudAnchor;
	
	
	// Internal fields
	private GameObject[] cloudInstances;
	
	void Awake() {
		// Create an array large enough to sttore all cloud instances
		cloudInstances = new GameObject[numClouds];
		
		// Find the cloud anchor in the hierarchy
		GameObject anchor = GameObject.Find("Clouds");

		// Iterate through array and create a cloud for each slot
		GameObject cloud;
		for (int i = 0; i < numClouds; i++) {
			
			// Randomly pick one of the cloud instances
			int random = Random.Range(0,5);
			
			float scaleU = Random.value;
			float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);

			Vector3 cPos = anchor.transform.position;
			cPos.x = Random.Range (cloudPosMin.x, cloudPosMax.x);
			cPos.y = Random.Range (cloudPosMin.y, cloudPosMax.y);
			cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);
			cPos.z = 100 - 90*scaleU;
			// Create that instance
			cloud = Instantiate (cloudPrefabs[random]) as GameObject;
			// Apply these changes to our instance
			cloud.transform.position = cPos;
			cloud.transform.localScale = Vector3.one * scaleVal;
			
			// Make the cloud a child of our anchor
			cloud.transform.parent = anchor.transform;
			
			// Put the cloud into our instances array
			cloudInstances[i] = cloud;
		}
	}
	
	void Update() {
		// Iterate through all cloud instance
		foreach (GameObject cloud in cloudInstances) {
			// Get the position and scale
			float scaleVal = cloud.transform.localScale.x;
			Vector3 cPos = cloud.transform.position;
			
			cPos.x -= Time.deltaTime * cloudSpeedMult * scaleVal;
			
			// Check if a clouds x position is too small
			if(cPos.x < cloudPosMin.x) {
				cPos.x = cloudPosMax.x;
			}
			cloud.transform.position = cPos;
			
		}
	}
}