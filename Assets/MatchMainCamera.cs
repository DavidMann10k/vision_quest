using UnityEngine;
using System.Collections;

public class MatchMainCamera : MonoBehaviour {

	GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation = mainCamera.transform.rotation;
		//gameObject.transform.rotation.y = mainCamera.transform.rotation.y;
		//gameObject.transform.rotation.z = mainCamera.transform.rotation.z;

	}
}
