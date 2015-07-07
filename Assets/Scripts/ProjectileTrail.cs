using UnityEngine;
using System.Collections;

public class ProjectileTrail : MonoBehaviour {
	public static ProjectileTrail S;

	// Public inspector field
	public float minDist = 0.1f;



	// Internal fields
	private LineRenderer line;
	private GameObject _poi;
	private Vector3 lastPoint;
	private int pointsCount;


	// A Property: Looks like a field to the outside, but internally calls set/get
	public GameObject poi {
		get {
			return _poi;
		}

		set {
			// Use "value" to access the value to set the property to 
			_poi = value;

			// Check if the poi is set to something (and now to something new)

			// Reset the whole LineRenderer thingy

		}

	}


	void Awake() {
		S = this;

		line = GetComponent<LineRenderer>();

		// Initialize stuff

	}

	void FixedUpdate() {
		// Is there a poi

			// If not, try using the cameras POI (if its a projectile)

		// At this point the poi has a value and its a projectile

		AddPoint();

	}

	void AddPoint() {
		Vector3 pt = _poi.transform.position;

		// If the point isn't far enough from the last point, do nothing
		if(pointsCount > 0 && (pt - lastPoint).magnitude < minDist) {
			return;
		}

		// If out current point is the first (launch) point
		if(pointsCount == 0){
			line.enabled = true;
		}
		// Add first point
		pointsCount++;
		line.SetVertexCount (pointsCount);
		line.SetPosition (pointsCount - 1, pt);


		lastPoint = pt;
	}

	public void Clear() {
	}
	

}