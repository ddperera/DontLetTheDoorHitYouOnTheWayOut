using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	public DialogManager dm;
	public bool shouldFollow;

	//Dialogs
	public string[] greeting;
	public string[] dialog;

	public float maxDistFromPlayer = 3;

	public enum state {FOLLOWING, IDLE, TALKING};
	public state curState;

	private state nextState;
	private bool interactedBefore;
	private GameObject player;


	void Start () {
		interactedBefore = false;
		curState = state.IDLE;
		nextState = state.IDLE;

		dm = GameObject.FindGameObjectWithTag ("Dialogue").GetComponent<DialogManager>();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate (){
		if (curState == state.TALKING) {
			Vector3 relativePos = player.transform.position - transform.position;
			Quaternion rot = Quaternion.LookRotation(relativePos);
			transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.time * 0.01f);
		}
	}

	public void Clicked(){
		if (curState != state.TALKING) {
			StartCoroutine("Talk");
		}
		if (shouldFollow) {
			nextState = state.FOLLOWING;
		} else {
			nextState = state.IDLE;
		}
	}

	IEnumerator Talk(){
		curState = state.TALKING;
		dm.ToggleActive ();
		if (!interactedBefore) {
			interactedBefore = true;

			foreach(string text in greeting){
				dm.UpdateDialog (text);
				do {
					yield return null;
				} while (!Input.GetButtonDown ("Fire1"));
				if (Vector3.Distance (player.transform.position, transform.position) > maxDistFromPlayer) {
					break;
				}
			}
			dm.UpdateDialog ("");
		} else {
			foreach(string text in dialog){
				dm.UpdateDialog (text);
				do {
					yield return null;
				} while (!Input.GetButtonDown ("Fire1"));
				if (Vector3.Distance (player.transform.position, transform.position) > maxDistFromPlayer) {
					break;
				}
			}
			dm.UpdateDialog ("");
		}
		dm.ToggleActive ();
		curState = nextState;
	}
}
