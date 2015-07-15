using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// Static field accessible from anywhere
	public GameObject ground;
	private AudioSource cheerSound;
	public AudioSource scoreSound;
	public Color color;

	void Start () {
		cheerSound = GetComponent<AudioSource>();
		scoreSound = GameObject.FindGameObjectWithTag("Score").GetComponent<AudioSource>();
	}

	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		// Check if the object is a projectile
		if (other.tag == "Food") {
			ScoreGoal();
//		cheerSound.Play();
		}
	}

	void ScoreGoal() {
		GameController.score += 100;
		scoreSound.Play ();
	}
}
