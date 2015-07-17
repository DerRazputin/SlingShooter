using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// Static field accessible from anywhere
	private AudioSource cheerSound;
	AudioSource scoreSound;
	public Color color;
	public Animator scoreAnimator;
	public GameObject particleLocation;
	public GameObject dropParticlesPrefab;

	void Start () {
		particleLocation = GameObject.Find("FoodDropsLocation");
		cheerSound = GetComponent<AudioSource>();
		scoreSound = GameObject.FindGameObjectWithTag("Score").GetComponent<AudioSource>();
	}

	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		// Check if the object is a projectile
		if (other.tag == "Food") {
			ScoreGoal(100);
			if (!cheerSound.isPlaying) {
				cheerSound.Play();
			}
			Instantiate(dropParticlesPrefab, particleLocation.transform.position, particleLocation.transform.rotation);
		} else if (other.tag == "FoodSmall") {
			ScoreGoal(1);
		}
		Destroy(other.gameObject);
	}

	void ScoreGoal(int addScore) {
		GameController.score += addScore;
		scoreAnimator.SetTrigger("scored");
		scoreSound.Play ();
	}
}
