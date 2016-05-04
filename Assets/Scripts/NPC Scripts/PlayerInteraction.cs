using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	//state related
	public enum state {FOLLOWING, IDLE, TALKING};
	public state curState;
	public bool shouldFollow;
	public float rotSpeed = 1f;
	private state nextState;

	//Dialogs
	public bool shouldTalk = true;
	public int curDialog;
	public MultiDimensionalString[] dialogs;
	public DialogManager dm;

	public AudioClip[] voices;
	private AudioSource audio;

	//player related
	public float maxDistFromPlayer = 3;
	private GameObject player;


	void Awake () {
		curState = state.IDLE;
		nextState = state.IDLE;
		curDialog = 0;

		audio = GetComponent<AudioSource> ();
		dm = GameObject.FindGameObjectWithTag ("Dialogue").GetComponent<DialogManager>();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate (){
		if (curState == state.TALKING) {
			Vector3 relativePos = player.transform.position - transform.position;
			Quaternion rot = Quaternion.LookRotation(relativePos);
			transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.time * 0.001f * rotSpeed);
		}
	}

	public void Clicked(){
		if (curState != state.TALKING && dialogs.Length > curDialog) {
			StartCoroutine("Talk");
		}
		if (shouldFollow) {
			nextState = state.FOLLOWING;
		}
	}

	IEnumerator Talk(){
		curState = state.TALKING;
		dm.ToggleActive ();
		int i = 0;
		foreach(string text in dialogs[curDialog].stringArray){
			dm.UpdateDialog (text);
			if (!audio.isPlaying && shouldTalk) {
				audio.clip = voices[i % voices.Length];
				audio.Play ();
				i++;
			}
			do {
				yield return null;

			} while (!Input.GetButtonDown ("Fire1") && Vector3.Distance (player.transform.position, transform.position) <= maxDistFromPlayer);
			if (audio.isPlaying) {
				audio.Stop ();
			}

			if (Vector3.Distance (player.transform.position, transform.position) > maxDistFromPlayer) {
				break;
			}
		}
		if (curDialog == 0 && dialogs.Length > 1) {
			curDialog = 1;
		}
		dm.UpdateDialog ("");
		dm.ToggleActive ();
		curState = nextState;
	}
}
/**
[System.Serializable]
public class MultiDimensionalString
{
	public string[] stringArray;
}*/