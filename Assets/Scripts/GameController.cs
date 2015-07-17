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
	public GameObject castle;
	public GameObject both;
	public GameObject slingshot;
	public GameObject camera;
	public GameObject arrow;
	public static Text scoreText;
	public static int score;
	public static Text shotsFiredText;
	public static int shotsFired;
	public float easing;
	public float gravityMultiplier;
	public GameObject Tutorial;
	public static bool TutorialSeen = false;
	

	// Internal fields
	private int shotsTaken;
	private Vector3 castlePos;
	private GameState state = GameState.idle;
	private Vector3 bothTransform;
	private float gameRotation;


	void Awake() {
		S = this;
		StartLevel();
	}

	void StartLevel() {
		slingshot.GetComponent<SlingshotScript>().enabled = false;
		scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
		shotsFiredText = GameObject.FindGameObjectWithTag("Shots").GetComponent<Text>();
		gameRotation = 0;
		RotateGame(gameRotation, easing);
		if (TutorialSeen == true) {
			Destroy(Tutorial);
			slingshot.GetComponent<SlingshotScript>().enabled = true;
			GameObject.Find("LaunchPoint").SetActive(true);
		} else {
			Tutorial.SetActive(true);
		}
	}
	

	void Update() {
		// Update our GUI texts
		scoreText.text = "Score: " + score.ToString();
		shotsFiredText.text = shotsFired.ToString();
		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
			if (gameRotation < 0.4f) {
				gameRotation += 0.2f;
			}
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
			if (gameRotation > -0.4f) {
				gameRotation -= 0.2f;
			}
		}
		if (Input.GetAxis("Vertical") < 0) {
			gameRotation = 0;
		}
	}

	void FixedUpdate() {
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
	
	public void CloseTutorial () {
		Tutorial.GetComponent<Animator>().SetTrigger("CloseTutorial");
		Destroy(Tutorial.transform.Find("ClickToContinue").gameObject);
		TutorialSeen = true;
		slingshot.GetComponent<SlingshotScript>().enabled = true;
		StartCoroutine("CloseAndDestroyTutorial");
	}

	// Destroy tutorial actor after delay
	public IEnumerator CloseAndDestroyTutorial () {
		yield return new WaitForSeconds(1);
		Destroy(Tutorial);
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
