using UnityEngine;
using System.Collections;

public class ElecSwitchBehaviour : MonoBehaviour {

	GameObject player;
	Movement playerInfo;
	Vector3 startPos;
	Vector3 endPos;
	Transform currentTrans;
	private float startTime;
	public AudioClip buttonPressSound;

	enum SwitchState {ON, OFF};

	SwitchState curState = SwitchState.OFF;

	public ParticleSystem electricityEffects;
	public GameObject electricity;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInfo = player.GetComponent<Movement> ();
		currentTrans = GetComponent<Transform> ();
		startPos = GetComponent<Transform> ().position;
		endPos = startPos + Vector3.forward*0.2f;
		if (electricityEffects.isPlaying) {
			electricityEffects.Stop ();
		}
		electricity.active = false;
	}
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime);
		float fracJourney = distCovered / 1.0f;
		Vector3 currentPos = currentTrans.position;
		if (curState == SwitchState.ON) {
			transform.position = Vector3.Lerp(currentPos, endPos, fracJourney);
		}
		else if (curState == SwitchState.OFF) {
			transform.position = Vector3.Lerp(currentPos, startPos, fracJourney);
		}
		 
	
	}

	// Interactable
	void OnPlayerClicked()
	{
		AudioSource.PlayClipAtPoint(buttonPressSound,transform.position);
		startTime = Time.time;
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
			electricity.active = true;

			// if (!playerInfo.isGhost) {
			// 	playerInfo.isGhost = true;
			// }
		} else {
			electricity.active = false;
			if (electricityEffects.isPlaying) {
				electricityEffects.Stop ();
			}
		}
			
	}
}
