using UnityEngine;
using System.Collections;
using UnityEngine.UI;


enum GameState {
	idle,
	playing,
	levelEnd

}

public class GameController : MonoBehaviour {
	public static GameController S;


	// Public inspector fields
	public GameObject[] castles;
	public Vector3 castlePos;
	public GameObject castle;
	public GameObject both;
	public GameObject slingshot;
	public static Text scoreText;
	public static int score;
	public static Text shotsFiredText;
	public static int shotsFired;

//	public Text gtLevel;
//	public Text gtShots;


	// Internal fields
	private int level;
	private int levelMax;
	private int shotsTaken;
	private string showing = "Slingshot";
	private GameState state = GameState.idle;
	private Vector3 bothTransform;



	void Awake() {
		S = this;

		bothTransform = slingshot.transform.position;
		bothTransform.x += (castle.transform.position.x - slingshot.transform.position.x) * 0.5f;
		bothTransform.y += ((castle.transform.position.y - slingshot.transform.position.x) * 0.5f) * 6;
		bothTransform.z = 0;
		level = 0;
		levelMax = castles.Length;
		scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
		shotsFiredText = GameObject.FindGameObjectWithTag("Shots").GetComponent<Text>();

		StartLevel();
	}

	void StartLevel() {

		both.transform.position = bothTransform;

		// if there is a castle, destroy it

		// Dewstroy all remaining projectiles

		// Instantiate a new castle

		// Switch the view to "Both"

		// Clear all projectile trails




	}
	

	void Update() {
		// Update our GUI texts
		scoreText.text = "Score: " + score.ToString();
		shotsFiredText.text = shotsFired.ToString();
		// Check for level end
	}

	public void RestartGame() {
		Application.LoadLevel (0);
		score = 0;
		shotsFired = 0;
	}

	public void SwitchView(string view) {

		// Switch overall possibilities "Castle", "Both", "SlingShot"

		switch(view) {
		case "Castle":
			Debug.Log("Castle");
			FollowCam.S.poi = castle;
			break;
		case "Both":
			Debug.Log ("Both");
			FollowCam.S.poi = both;
			break;
		case "Slingshot":
			Debug.Log ("Slingshot");
			FollowCam.S.poi = slingshot;
			break;

		}
			// Set the Followcams POI to the according value

			// followcam.poi

	}

}
