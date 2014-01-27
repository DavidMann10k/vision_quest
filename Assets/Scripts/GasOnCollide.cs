using UnityEngine;
using System.Collections;

public class GasOnCollide : MonoBehaviour {

	//SphereCollider remote_collider;

	// Use this for initialization
	void Start () {
		//remote_collider = gameObject.GetComponent<SphereCollider>();
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
