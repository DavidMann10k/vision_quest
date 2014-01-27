using UnityEngine;
using System.Collections;

public class Jar : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		gameObject.name = "Jar";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnClick()
	{
		var player = GameObject.Find("Player");
		var state = player.GetComponent<CharacterState>();
		state.Jar = true;
		Destroy(gameObject);
	}
}
