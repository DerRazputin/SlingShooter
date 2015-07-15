using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// Static field accessible from anywhere
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
			ScoreGoal(100);
//		cheerSound.Play();
		} else if (other.tag == "FoodSmall") {
			ScoreGoal(1);
		}
	}

	void ScoreGoal(int addScore) {
		GameController.score += addScore;
		scoreSound.Play ();
	}
}
