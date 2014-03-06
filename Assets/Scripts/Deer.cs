using UnityEngine;
using System.Collections;

public class Deer : MonoBehaviour {

	//Animator anim;
	//int stage;

	//public Vector3 destination;
	//public float speed;

	//public Transform target;

	// Use this for initialization
	//void Start () {
		//anim = GetComponent<Animator>();

	//}
	
	// Update is called once per frame
	//void Update () {
		//transform.position = Vector3.Lerp(transform.position, target.position, speed);
		
		//if (Input.GetKeyDown(KeyCode.K))
		//{
			//start_animation();
		//}
	//}

	//void start_animation()
	//{
		//anim.SetInteger("stage", 1);
	//}

	Color end_color;
	bool disappearing = false;

	Renderer rend;
	float alphaCutoff = 0.0f;

	void Start()
	{
		rend = gameObject.GetComponentInChildren<Renderer>();
		//end_color = new Color(rend.material.color.r, rend.material.color.b, rend.material.color.g, 0.0f);
		rend.material.SetFloat ("_Cutoff", 0.0f);

	}

	void Update()
	{
		if(disappearing)
		{
			//rend.material.color = Color.Lerp (rend.material.color, end_color, Time.deltaTime);
			rend.material.SetFloat ("_Cutoff", Mathf.Lerp (0.0f, 1.0f, alphaCutoff += (Time.deltaTime * 0.25f)));
		}
	}

	void OnTriggerEnter()
	{
		disappearing = true;
	}
}
