using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// Static field accessible from anywhere
	public static bool goalMet;
	private AudioSource audio;
	public AudioSource scoreSound;
	public Color color;

	void Start () {
		audio = GetComponent<AudioSource>();
		scoreSound = GameObject.FindGameObjectWithTag("Score").GetComponent<AudioSource>();
	}

	void Update () {
		GetComponent<Renderer>().material.color = color;
		if (GameController.score >= 9000) {
		CancelInvoke("ScoreGoal");
		}
	}

	void OnTriggerEnter(Collider other) {
		// Check if the object is a projectile
		if (other.gameObject.tag == "Projectile") {
			// If so, set goalMet to true
			goalMet = true;

			// Also set the goals alpha to a higher opacity
			// (Use Renderer component)
			Color c = this.GetComponent<Renderer>().material.color;
			c.a += 0.5f;
			GetComponent<Renderer>().material.color = c;
			audio.Play();

			InvokeRepeating("ScoreGoal", 0.04F, 0.04F);
		}
	}

	void ScoreGoal() {
		GameController.score += 100;
		scoreSound.Play ();
	}

}
