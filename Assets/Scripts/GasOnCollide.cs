using UnityEngine;
using System.Collections;

public class GasOnCollide : MonoBehaviour {

	SphereCollider collider;

	// Use this for initialization
	void Start () {
		collider = gameObject.GetComponent<SphereCollider>();
	}

	void OnTriggerEnter(Collider collider) {
		///print ("ENTERING");
		//print (collider.gameObject.name);
		if(collider.gameObject.name == "Player")
		{
			var player = GameObject.Find("Player");
			var state = player.GetComponent<CharacterState>();
			state.Huffin = true;
			//print ("setting huffin true");
		}
	}
}
