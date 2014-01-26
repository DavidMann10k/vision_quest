using UnityEngine;

public class Reticle : MonoBehaviour
{

	public Texture2D crosshairTexture;

	Rect position;

	void Start()
	{
		var left = ((Screen.width - crosshairTexture.width) / 2);
		var right = ((Screen.height - crosshairTexture.height) /2);

		position = new Rect(left, right, crosshairTexture.width/2, crosshairTexture.height/2);
		Screen.lockCursor = true;
	}

	void OnGUI()
	{
		GUI.DrawTexture(position, crosshairTexture);
	}

	void Update() {
		//if (Input.GetKeyDown("escape"))
		//	Screen.lockCursor = false;

		if (Input.GetKey(KeyCode.Escape))
			Screen.lockCursor = false;
		else
			Screen.lockCursor = true;
	}

	void OnMouseDown() {
		Screen.lockCursor = true;
	}
}