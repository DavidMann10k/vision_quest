using UnityEngine;
using System.Collections;

public class CharacterAdjuster : MonoBehaviour {

	CharacterMotor char_mot;

	bool is_berried;

	// Use this for initialization
	void Start () {
		var player = GameObject.Find("Player");
		var state = player.GetComponent<CharacterState>();

		char_mot = gameObject.GetComponent<CharacterMotor>();
		state.OnBerried += OnBerried;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBerried(bool state)
	{
		is_berried = state;
		if (state)
			pump_up();
		else
			cool_off();
	}

	void pump_up()
	{
		char_mot.movement.maxForwardSpeed = 20f;
		char_mot.movement.maxSidewaysSpeed = 20f;
		char_mot.movement.maxBackwardsSpeed = 20f;

		char_mot.jumping.baseHeight = 5f;
	}

	void cool_off()
	{
		char_mot.movement.maxForwardSpeed = 6f;
		char_mot.movement.maxSidewaysSpeed = 6f;
		char_mot.movement.maxBackwardsSpeed = 6f;
		
		char_mot.jumping.baseHeight = 1f;
	}
}
