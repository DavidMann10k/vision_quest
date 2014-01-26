using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect((Screen.width - 100)/2, (Screen.height - 100) /2, 200, 200));
		GUILayout.Label("Visionsaga");
		if (GUILayout.Button("Start"))
		{
			Application.LoadLevel("Final");
		}
		GUILayout.EndArea();
	}
}
