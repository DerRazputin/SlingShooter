using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	public static Pause S;

	public static bool pauseGame = false;
	private bool showPause = false;
	public GameObject pause;

	// Use this for initialization
	void Awake() {
		S = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			pauseGame = !pauseGame;
			if (pauseGame == true) {
				Time.timeScale = 0;
				pauseGame = true;
				GameObject.FindGameObjectWithTag("Slingshot").GetComponent<SlingshotScript>().enabled = false;
				showPause = true;
			} else if (pauseGame == false) {
				Time.timeScale = 1;
				pauseGame = false;
				GameObject.FindGameObjectWithTag("Slingshot").GetComponent<SlingshotScript>().enabled = true;
				showPause = false;
			}
	
			if(showPause == true) {
				pause.SetActive(true);
			} else {
				pause.SetActive(false);
			}
		}
	}
}
