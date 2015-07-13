﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlingshotScript : MonoBehaviour {

	public GameObject[] prefabProjectile = new GameObject[1];
	public float velocityMult = 10.0f;
	
	public Animator shotsFiredAnimator;
	private AudioSource ropeAudio;
	public AudioClip dragClip;
	public AudioClip shotClip;

	private GameObject launchPoint;
	private bool aimingMode;

	private GameObject projectile;
	private Vector3 launchPos;

	void Awake() {
		Transform launchPointTrans = transform.Find("LaunchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive (false);
		launchPos = launchPointTrans.position;
		ropeAudio = GetComponent<AudioSource>();
	}

//	void OnMouseEnter() {
		//print ("Slingshot.MouseEnter");
//		launchPoint.SetActive (true);
//	}

	
	void OnMouseOver() {
		launchPoint.SetActive(true);
	}
 
	void OnMouseExit() {
		launchPoint.SetActive(false);

	}

	void OnMouseDown() {
		//Set the game to aiming mode
		aimingMode = true;

		// Instantiate a projectile at launchPoint
		projectile = Instantiate ( prefabProjectile[Random.Range(0, prefabProjectile.Length)] ) as GameObject;
		projectile.transform.position = launchPos;
		ropeAudio.clip = dragClip;
		ropeAudio.Play();

		// Switch of physics during aiming mode
		projectile.GetComponent<Rigidbody>().isKinematic = true;
	}

	// Update is called once per frame
	void Update () {
		// Check for aiming mode
		if (!aimingMode) return;

		// Get our mouse position and convert to 3D
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = - Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		// Calculate delta between launch position
		Vector3 mouseDelta = mousePos3D - launchPos;

		// Constrain the delta to the radius of the sphere collider
		float maxMagnitude = this.GetComponent<SphereCollider>().radius;
		mouseDelta = Vector3.ClampMagnitude(mouseDelta, maxMagnitude);

		// Set projectile position to new position and fire it
		projectile.transform.position = launchPos + mouseDelta;

		if(Input.GetMouseButtonUp (0)) {
			aimingMode = false;
			// Switch on Gravity
			projectile.GetComponent<Rigidbody>().isKinematic = false;

			projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;

			FollowCam.S.poi = projectile;

			GameController.shotsFired++;

			shotsFiredAnimator.SetTrigger("ShotFired");
			if (ropeAudio.isPlaying) {
				ropeAudio.Stop();
			}
			ropeAudio.clip = shotClip;
			ropeAudio.Play();
		}
	}
}