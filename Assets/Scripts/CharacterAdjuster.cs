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
		char_mot.movement.maxForwardSpeed = 24f;
		char_mot.movement.maxSidewaysSpeed = 24f;
		char_mot.movement.maxBackwardsSpeed = 24f;

		char_mot.jumping.baseHeight = 7f;
	}

	void cool_off()
	{
		char_mot.movement.maxForwardSpeed = 12f;
		char_mot.movement.maxSidewaysSpeed = 12f;
		char_mot.movement.maxBackwardsSpeed = 9f;
		
		char_mot.jumping.baseHeight = 1.5f;
	}
}
