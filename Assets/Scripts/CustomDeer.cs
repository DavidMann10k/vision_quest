using UnityEngine;
using System.Collections;

public class CustomDeer : MonoBehaviour {

	//public BoxCollider collider;
	public GameObject deer;

	void Start()
	{
		//collider = gameObject.GetComponentInChildren<BoxCollider>();
	}

	void Update()
	{

	}
	
	void OnTriggerEnter(Collider collider)
	{
		if( collider.gameObject.name == "Player")
		{
			deer.SetActive(true);
			
			var player = GameObject.Find("Player");
			var state = player.GetComponent<CharacterState>();
			state.perma_tripping();
		}
	}
}
