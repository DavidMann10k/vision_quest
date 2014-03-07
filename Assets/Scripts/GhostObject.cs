using UnityEngine;
using System.Collections;

public class GhostObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var player = GameObject.Find("Player");
		var state = player.GetComponent<CharacterState>();
		state.OnTrippin += MyOnTrippin;
		gameObject.SetActive(false);
	}

	void MyOnTrippin(bool state)
	{
		gameObject.SetActive(state);
	}
}
