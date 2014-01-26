using UnityEngine;
using System.Collections;

public class PauseState : MonoBehaviour {

	private bool is_paused;
	private bool show_credits;
	private bool escape_down;
	public bool Paused {
		get {
			return is_paused;
		}
	}

	private Rect PauseMenu = new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 200, 100);
	private Rect CreditWindow = new Rect((Screen.width - 180) / 2, (Screen.height - 200) / 2, 180, 240);
	// Use this for initialization
	void Start () {
		is_paused = false;
		show_credits = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			is_paused = !is_paused;
			show_credits = false;
		}

		if (Paused) {
			Screen.lockCursor = false;
			Time.timeScale = 0;
		} else {
			Screen.lockCursor = true;
			Time.timeScale = 1;
		}
	}

	void OnGUI() {
		if(is_paused) {
			if (show_credits) {
				GUI.Window(1, CreditWindow, DrawCreditsWindow, "Credits");
			} else {
				GUI.Window(0, PauseMenu, DrawPauseMenu, "");
			}
		}
	}

	void DrawPauseMenu(int windowID) {

		if (GUILayout.Button("Resume")) {
			is_paused = false;
		}
		if (GUILayout.Button ("Credits")) {
			show_credits = true;
		}
		if (GUILayout.Button ("Quit")) {	
			Application.Quit();
		}

	}

	void DrawCreditsWindow(int windowID) {
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;

		GUI.Label(new Rect(20, 40, 140, 25), "Matthew Hagen", centeredStyle);
		GUI.Label(new Rect(20, 70, 140, 25), "Nick Malbraaten", centeredStyle);
		GUI.Label(new Rect(20, 100, 140, 25), "David Mann", centeredStyle);
		GUI.Label(new Rect(20, 130, 140, 25), "Corey Van Meekeren", centeredStyle);
		GUI.Label(new Rect(20, 160, 140, 25), "Heidi Neibert", centeredStyle);
		if (GUI.Button (new Rect(20, 190, 140, 25), "Back")) {
			show_credits = false;
		}
	}


}
