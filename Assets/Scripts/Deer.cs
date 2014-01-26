using UnityEngine;
using System.Collections;

public class Deer : MonoBehaviour {

	Animator anim;
	int stage;

	//public Vector3 destination;
	public float speed;

	public Transform target;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = Vector3.Lerp(transform.position, target.position, speed);
	}

	void start_animation()
	{
		anim.SetInteger("stage", 1);
	}
}
