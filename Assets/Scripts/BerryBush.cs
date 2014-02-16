using UnityEngine;
using System.Collections;

public class BerryBush : MonoBehaviour {
	
	void OnClick()
	{
		var player = GameObject.Find("Player");
		var state = player.GetComponent<CharacterState>();
		state.Berried = true;
		Destroy (gameObject);
	}
}
