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
	public GameObject camera;
	public GameObject arrow;
	public static Text scoreText;
	public static int score;
	public static Text shotsFiredText;
	public static int shotsFired;
	public float heightOffset;
	private float gameRotation;
	public float easing;
	public float gravityMultiplier;

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
		heightOffset = 1;
		bothTransform = slingshot.transform.position;
		bothTransform.x += (castle.transform.position.x - slingshot.transform.position.x) * 0.5f;
		bothTransform.y = ((castle.transform.position.y - slingshot.transform.position.y) * 0.5f) * -heightOffset;
		bothTransform.z = 0;
		level = 0;
		levelMax = castles.Length;
		scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
		shotsFiredText = GameObject.FindGameObjectWithTag("Shots").GetComponent<Text>();
		gameRotation = 0;
		RotateGame(gameRotation, easing);
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
		bothTransform.y = ((castle.transform.position.y - slingshot.transform.position.y) * 0.5f) * -heightOffset;
		both.transform.position = bothTransform;
	}

	void FixedUpdate() {
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if (gameRotation < 0.5f) {
				gameRotation += 0.2f;
			}
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if (gameRotation > -0.5f) {
				gameRotation -= 0.2f;
			}
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			gameRotation = 0;
		}
		RotateGame(gameRotation, easing);
	}

	public void RotateGame (float addRot, float ease) {
		Quaternion rot = transform.rotation;
		Quaternion destination = rot;
		rot.z = addRot;
		transform.rotation = Quaternion.Lerp(rot, destination, easing);
		Quaternion arrowRot = transform.rotation;
		arrowRot.z *= 2;
		Physics.gravity = -transform.up * gravityMultiplier;
		camera.transform.rotation = transform.rotation;
		arrow.transform.rotation = arrowRot;
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
