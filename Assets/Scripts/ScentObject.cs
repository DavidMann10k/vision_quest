using UnityEngine;
using System.Collections;

public class ScentObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var player = GameObject.Find("Player");
		var state = player.GetComponent<CharacterState>();
		state.OnHuffin += OnHuffin;
	}

	void OnHuffin(bool state)
	{
		gameObject.SetActive(state);
	}
}
