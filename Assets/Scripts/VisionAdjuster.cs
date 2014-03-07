using UnityEngine;
using System.Collections;
using System;

public class VisionAdjuster: MonoBehaviour {

	Color NormalBackgroundColor;
	public Color TrippinBackgroundColor;
	public Color NotTrippinBackgroundColor = Color.black;
	public float NormalFieldOfView;
	public float TrippinFieldOfView;
	public float NormalSpeed = 1.0f;
	public float HighSpeed = 40.0f;

	private GameObject worldCenter;
	private DayCycle dayCycle;
	private CharacterState state;
	private Light sunLight;
	private Camera FXCam;
	
	void Start(){
		sunLight = GameObject.Find("SunLight").GetComponent<Light> ();
		var player = GameObject.Find("Player");
		state = player.GetComponent<CharacterState>();
		worldCenter = GameObject.Find ("WorldCenter");
		dayCycle = worldCenter.GetComponent<DayCycle> ();
		FXCam = GameObject.Find ("FXCamera").camera;
	}


	void Update () {

		if (state.Trippin && Camera.main.fieldOfView != TrippinFieldOfView) {
			// go to crazy FOV
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, TrippinFieldOfView, Time.deltaTime);
			//speed up DayCycle
			dayCycle.TargetSpeed = HighSpeed;
			dayCycle.TrippinColor = TrippinBackgroundColor;
			FXCam.clearFlags = CameraClearFlags.Depth;

		} else if (Camera.main.fieldOfView != NormalFieldOfView) {
			// go back to normal FOV
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, NormalFieldOfView, Time.deltaTime);
			//restore normal daycycle
			dayCycle.TargetSpeed = NormalSpeed;
			dayCycle.TrippinColor = NotTrippinBackgroundColor;
			FXCam.clearFlags = CameraClearFlags.Color;
			}

		if (state.Huffin) {
			sunLight.intensity = Mathf.Lerp (sunLight.intensity, 0.3f, Time.deltaTime);
		}else {
			sunLight.intensity = Mathf.Lerp (sunLight.intensity, 1.0f, Time.deltaTime);
		}
	} 
}



