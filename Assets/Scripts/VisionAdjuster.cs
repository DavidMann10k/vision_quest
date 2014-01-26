using UnityEngine;
using System.Collections;
using System;

public class VisionAdjuster: MonoBehaviour {

	public Color NormalBackgroundColor;
	public Color TrippinBackgroundColor;
	public float NormalFieldOfView;
	public float TrippinFieldOfView;

	private CharacterState state;
	// Use this for initialization
	void Start () {
		var player = GameObject.Find("Player");
		state = player.GetComponent<CharacterState>();
	}

	// Update is called once per frame
	void Update () {
		if (state.Trippin && Camera.main.backgroundColor != TrippinBackgroundColor) {
			// go to crazy skybox color and FOV
			float deltaTime = Time.deltaTime;
			Camera.main.backgroundColor = Color.Lerp (Camera.main.backgroundColor, TrippinBackgroundColor, deltaTime);
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, TrippinFieldOfView, deltaTime);
		} else if (Camera.main.backgroundColor != NormalBackgroundColor) {
			// go back to normal color and FOV
			float deltaTime = Time.deltaTime;
			Camera.main.backgroundColor = Color.Lerp (Camera.main.backgroundColor, NormalBackgroundColor, deltaTime);
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, NormalFieldOfView, deltaTime);
			
		} 
	}

}

