﻿using UnityEngine;
using System.Collections;

public class DayCycle : MonoBehaviour {


	public Color TrippinColor = Color.black;
	public Color LerpedLight;
	public Color LerpedDawn;

	public float y, z;
	public Color Day = Color.white;
	public Color Night = Color.black;
	public Color Dawn = Color.red;
	public float Speed = 2.0f;
	public float TargetSpeed = 2.0f;

	Camera FXCam;
	void Start(){
		FXCam = GameObject.Find ("FXCamera").camera;
		}

	void Update () {
		//Rotate sun and moon directional lights
		transform.Rotate (Vector3.right, Speed * Time.deltaTime);

		//Lerp Speed change from Vision Adjuster script
		if (Speed != TargetSpeed)
						Speed = Mathf.Lerp (Speed, TargetSpeed, Time.deltaTime);


		//get y, z positions of sun to time ambientLight, camera background, FogColor thru Lerped variables
		y = gameObject.transform.GetChild(0).position.y;
		z = 2 * gameObject.transform.GetChild(0).position.z;

		//Color current = Color.Lerp (LerpedLight + LerpedDawn - Color.gray, 

		LerpedLight = Color.Lerp(Day, Night, y);
		LerpedDawn = Color.Lerp (Night, Dawn,(z * z * z));
	
		RenderSettings.ambientLight = LerpedLight;
		RenderSettings.fogColor = LerpedLight - Color.gray;
		FXCam.backgroundColor = LerpedLight + LerpedDawn + TrippinColor;


	}
}