using UnityEngine;
using System.Collections;

public class CharacterState : MonoBehaviour {

	public static string debug_message = "";
	
	public delegate void StateSender(bool state);
	
	public StateSender OnBerried;
	public StateSender OnTrippin;
	public StateSender OnHuffin;
	
	bool is_berried = false;
	bool is_trippin = false;
	bool is_huffin = false;
	bool has_jar = false;
	
	public float max_berried_duration = 5.0f;
	public float max_trippin_duration = 5.0f;
	public float max_huffin_duration = 5.0f;
	
	public float berried_duration = 0.0f;
	public float trippin_duration = 0.0f;
	public float huffin_duration = 0.0f;
	
	public Rect position;
	public Texture2D jar_tex;
	public Texture2D jar_tex_flower1;
	public Texture2D jar_tex_flower2;
	public Texture2D jar_tex_berries;
	public Texture2D jar_tex_bees;
	
	public Texture2D current_tex;
	public string contents = "";

	public bool Berried
	{
		get{
			return is_berried;
		}
		set{
			is_berried = value;
			InvokeStateSender(OnBerried, value);
			if(value)
				berried_duration = max_berried_duration;
		}
	}
	public bool Trippin
	{
		get{
			return is_trippin;
		}
		set{
			is_trippin = value;
			InvokeStateSender(OnTrippin, value);
			if(value)
			{
				trippin_duration = max_trippin_duration;
			}
		}
	}
	public bool Huffin
	{
		get{
			return is_huffin;
		}
		set{
			is_huffin = value;
			InvokeStateSender(OnHuffin, value);
			if(value)
			{
				debug_message = "STARTED HUFFING";
				huffin_duration = max_huffin_duration;
			}
		}
	}
	public bool Jar
	{
		get {
			return has_jar;
		}
		set{
			has_jar = value;
			current_tex = jar_tex;
		}
	}
	
	// Use this for initialization
	void Awake () {
		OnBerried += dummy;
		OnHuffin += dummy;
		OnTrippin += dummy;
	}
	
	void Start()
	{
		max_berried_duration = 60.0f;
		max_trippin_duration = 60.0f;
		max_huffin_duration = 60.0f;

		var left = (Screen.width - jar_tex.width - 5);
		var right = (Screen.height - jar_tex.height - 5);
		
		position = new Rect(left, right, jar_tex.width/2, jar_tex.height/2);
	}
	
	// Update is called once per frame
	void Update () {
		handle_durations ();
		if (Input.GetMouseButtonDown(1))
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width /2, Screen.height /2, 0));
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (contents == "")
				{
					switch_jar(hit.collider.gameObject.name);
				}
				else{
					use_jar();
				}
			}
		}
	}

	void use_jar()
	{
		switch (contents)
			{
			case "berries":
				Berried = true;
				contents = "";
				current_tex = jar_tex;
				break;
			case "red_flowers":
				Trippin = true;
				contents = "";
				current_tex = jar_tex;
				break;
			case "yellow_flowers":
				print ("END OF STORY IF YOU USE IT RIGHT");
				contents = "";
				current_tex = jar_tex;
				break;
			case "bees":
				print("RELEASE THE BEES");
				contents = "";
				current_tex = jar_tex;
				break;
			}
	}

	void switch_jar(string content_type)
	{
		switch (content_type)
		{
		case "berries":
			current_tex = jar_tex_berries;
			contents = "berries";
			break;
		case "red_flowers":
			current_tex = jar_tex_flower1;
			contents = "red_flowers";
			break;
		case "yellow_flowers":
			current_tex = jar_tex_flower2;
			contents = "berries";
			break;
		case "bees":
			current_tex = jar_tex_bees;
			contents = "bees";
			break;
		case "":
			current_tex = jar_tex;
			contents = "";
			break;
		default:
			break;
		}
	}

	void handle_durations ()
	{
		if (berried_duration > 0.0f) {
			berried_duration -= Time.deltaTime;
		}
		else {
			Berried = false;
		}
		if (huffin_duration > 0.0f) {
			huffin_duration -= Time.deltaTime;
		}
		else {
			Huffin = false;
		}
		if (trippin_duration > 0.0f) {
			trippin_duration -= Time.deltaTime;
		}
		else {
			Trippin = false;
		}
	}
	
	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(2, 2, 200, 400));
		GUILayout.Label("Character State:");
		if(is_trippin)
			GUILayout.Label("TRIPPIN BAWLS");
		if(is_huffin)
			GUILayout.Label("HIGH");
		if(is_berried)
			GUILayout.Label("BERRIED");
		if  (contents != "")
			GUILayout.Label("Contents of jar: " + contents);
		GUILayout.EndArea();

		
		GUILayout.BeginArea(new Rect(210, 2, 200, 400));
		GUILayout.Label(debug_message);
		GUILayout.Label("berried_duration: " + berried_duration);
		GUILayout.Label("huffin_duration: " + huffin_duration);
		GUILayout.Label("trippin_duration: " + trippin_duration);
		GUILayout.Label("max_berried_duration: " + max_berried_duration);
		GUILayout.Label("max_huffin_duration: " + max_huffin_duration);
		GUILayout.Label("max_trippin_duration: " + max_trippin_duration);
		GUILayout.EndArea();

		if (current_tex != null)
		{
			GUI.DrawTexture(position, current_tex);
		}
	}
	
	void dummy(bool state)
	{
		
	}
	
	private void InvokeStateSender(StateSender handler, bool state)
	{
		if (handler != null)
		{
			handler(state);
		}
	}
}
