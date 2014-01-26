using UnityEngine;
using System.Collections;

public class YellowFlower : MonoBehaviour {

	void Start () {
		gameObject.name = "yellow_flowers";
	}
	
	void OnClick()
	{
		var player = GameObject.Find("Player");
		var state = player.GetComponent<CharacterState>();
		state.Trippin = true;
	}
}
