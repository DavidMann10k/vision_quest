using UnityEngine;

public class Reticle : MonoBehaviour
{

	public Texture2D crosshairTexture;

	Rect position;

	void Start()
	{
		var left = ((Screen.width - crosshairTexture.width) / 2);
		var right = ((Screen.height - crosshairTexture.height) /2);

		position = new Rect(left, right, crosshairTexture.width/1.5f, crosshairTexture.height/1.5f);
		Screen.lockCursor = true;
	}

	void OnGUI()
	{
		GUI.DrawTexture(position, crosshairTexture);
	}

	void Update() {
		//if (Input.GetKeyDown("escape"))
		//	Screen.lockCursor = false;

//		if (Input.GetKey(KeyCode.Escape)) {
//			Screen.lockCursor = false;
//			Time.timeScale = 0;
//		}
//		else {
//			Screen.lockCursor = true;
//			Time.timeScale = 1;
//		}
	}

	void OnMouseDown() {
		//Screen.lockCursor = true;
	}
}