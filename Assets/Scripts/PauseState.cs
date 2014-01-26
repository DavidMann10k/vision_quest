using UnityEngine;
using System.Collections;

public class PauseState : MonoBehaviour {

	private bool is_paused;
	public bool Paused {
		get {
			return is_paused;
		}
	}

	private Rect PauseMenu = new Rect((Screen.width - 100)/2, (Screen.height - 50)/2, 200, 100);
	// Use this for initialization
	void Start () {
		is_paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape)) {
			is_paused = !is_paused;
//			var mouseLook = gameObject.GetComponent<MouseLook>();
//			mouseLook.enabled = !(mouseLook.enabled);
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
			GUI.Window(0, PauseMenu, DrawPauseMenu, "");
		}
	}

	void DrawPauseMenu(int windowID) {
		if (GUILayout.Button("Resume")) {
			is_paused = false;
		}
		if (GUILayout.Button ("Quit")) {	
			Application.Quit();
		}
	}


}
