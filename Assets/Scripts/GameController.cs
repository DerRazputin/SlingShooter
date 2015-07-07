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

	public Text gtLevel;
	public Text gtShots;


	// Internal fields
	private int level;
	private int levelMax;
	private int shotsTaken;
	private GameObject castle;
	private string showing = "Slingshot";
	private GameState state = GameState.idle;



	void Awake() {
		S = this;

		level = 0;
		levelMax = castles.Length;

		StartLevel();

	}

	void StartLevel() {
		// if there is a castle, destroy it

		// Dewstroy all remaining projectiles

		// Instantiate a new castle

		// Switch the view to "Both"

		// Clear all projectile trails


	}

	void Update() {
		// Update our GUI texts

		// Check for level end
	}



	public void SwitchView(string view) {

		// Switch overall pussybilities "Castle", "Both", "SlingShot"

		switch(view) {
		case "Castle":
			Debug.Log("Castle");
			break;
		case "Both":
			Debug.Log ("Both");
			break;
		case "Slingshot":
			Debug.Log ("Slingshot");
			break;
		}
			// Set the Followcams POI to the according value

			// followcam.poi

	}

}
