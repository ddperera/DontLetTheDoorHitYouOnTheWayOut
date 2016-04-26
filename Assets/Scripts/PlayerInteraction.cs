using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	public DialogManager dm;
	public bool shouldFollow;

	//Dialogs
	public string[] greeting;
	public string[] dialog;

	public float maxDistFromPlayer = 3;

	private bool isFollowing;
	private bool isTalking;
	private bool interactedBefore;

	private GameObject player;


	void Start () {
		isFollowing = false;
		interactedBefore = false;
		isTalking = false;

		dm = GameObject.FindGameObjectWithTag ("Dialogue").GetComponent<DialogManager>();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate (){
		if (isTalking) {
			Vector3 relativePos = player.transform.position - transform.position;
			Quaternion rot = Quaternion.LookRotation(relativePos);
			transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.time * 0.01f);
		}
	}

	public bool getIsFollowing () {
		return isFollowing;
	}

	public void ToggleIsFollowing(){
		isFollowing = !isFollowing;
	}

	public void Clicked(){
		if (!isTalking) {
			StartCoroutine("Talk");
		}
		if (shouldFollow) {
			ToggleIsFollowing ();
		}
	}

	IEnumerator Talk(){
		isTalking = true;
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
		isTalking = false;
	}
}
