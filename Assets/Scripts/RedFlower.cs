using UnityEngine;
using System.Collections;

public class RedFlower : MonoBehaviour {

	void Start () {
		gameObject.name = "red_flowers";
	}
	
	void OnClick()
	{
		var player = GameObject.Find("Player");
		var state = player.GetComponent<CharacterState>();
		state.Trippin = true;
	}
}
