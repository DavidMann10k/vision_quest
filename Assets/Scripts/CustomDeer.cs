using UnityEngine;
using System.Collections;

public class CustomDeer : MonoBehaviour {

	public BoxCollider collider;
	public GameObject deer;

	void Start()
	{
		collider = gameObject.GetComponentInChildren<BoxCollider>();
	}

	void Update()
	{

	}
	
	void OnTriggerEnter(Collider collider)
	{
		print ("hit");
		if( collider.gameObject.name == "Player")
		{
			print ("playuer here");
			deer.SetActive(true);
		}
	}
}
