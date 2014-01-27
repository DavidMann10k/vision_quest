using UnityEngine;
using System.Collections;

public class ClickTrigger : MonoBehaviour {

	//SphereCollider remote_collider;
	public Texture2D tex;
	Rect position;

	bool show = false;

	// Use this for initialization
	void Start () {
		//remote_collider = gameObject.GetComponent<SphereCollider>();
		
		var left = ((Screen.width - tex.width) / 2);
		var right = ((Screen.height - tex.height) /2 +100);
		
		position = new Rect(left, right, tex.width/1.5f, tex.height/1.5f);
	}
	
	void OnTriggerEnter()
	{
		show = true;
	}

	void OnGUI()
	{
		if(show)
		{
			GUI.DrawTexture(position, tex);
			Invoke("no_show", 5.0f);
		}
	}

	void no_show()
	{
		show = false;
	}
}
