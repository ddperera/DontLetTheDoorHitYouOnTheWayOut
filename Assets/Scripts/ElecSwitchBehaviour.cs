using UnityEngine;
using System.Collections;

public class ElecSwitchBehaviour : MonoBehaviour {

	GameObject player;
	Movement playerInfo;

	enum SwitchState {ON, OFF};

	SwitchState curState = SwitchState.OFF;

	public ParticleSystem electricityEffects;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInfo = player.GetComponent<Movement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Interactable
	void OnPlayerClicked()
	{
		switch (curState) 
		{
		case SwitchState.ON:
			curState = SwitchState.OFF;
			break;
		case SwitchState.OFF:
			curState = SwitchState.ON;
			break;
		default:
			Debug.Log ("Reached default case of switch statement for elec switch!");
			break;
		}

		if (curState == SwitchState.ON) {
			if (!electricityEffects.isPlaying) {
				electricityEffects.Play ();
			}

			if (!playerInfo.isGhost) {
				playerInfo.isGhost = true;
			}
		} else {
			if (electricityEffects.isPlaying) {
				electricityEffects.Stop ();
			}
		}
			
	}
}
