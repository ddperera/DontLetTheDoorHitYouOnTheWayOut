using UnityEngine;
using System.Collections;

[System.Serializable]
public class MultiDimensionalString
{
	public string[] stringArray;
	public InteractionNPC.state stateAfterDialog;
	public int nextDialog;
	public int faceWhileTalking = 0;
	public int faceAfterTalking = 0;
}

public class InteractionNPC : MonoBehaviour {

	public enum state {FOLLOWING, IDLE, TALKING};
	public state currentState = state.IDLE;
	public float rotationSpeed = 1f;
	public bool looksAtTarget = false;
	public Transform defaultLookTarget;

	public bool NPCProducesSound = true;
	public float dialogTimer = 1f;
	public int currentDialog = 0;
	public MultiDimensionalString[] dialogs;
	private DialogManager dm;
	public float maxTalkingDistance = 3f;

	public Texture[] faces;
	private Renderer rend;

	public AudioClip[] voices;
	private AudioSource audio;


	private GameObject player;

	void Start (){
		rend = GetComponent<Renderer>();
		rend.material.mainTexture = faces[0];
		audio = GetComponent<AudioSource> ();
		dm = GameObject.FindGameObjectWithTag ("Dialogue").GetComponent<DialogManager>();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate (){
		if (currentState == state.TALKING) {
			Vector3 relativePos = player.transform.position - transform.position;
			Quaternion rot = Quaternion.LookRotation (relativePos);
			transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.time * 0.001f * rotationSpeed);
		} else if (currentState == state.IDLE && looksAtTarget) {
			Vector3 relativePos = defaultLookTarget.position - transform.position;
			Quaternion rot = Quaternion.LookRotation (relativePos);
			transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.time * 0.001f * rotationSpeed);
		}
	}

	public void OnPlayerClicked(){
		if (currentState != state.TALKING && dialogs.Length > currentDialog) {
			StartCoroutine("Talk");
		}
	}

	IEnumerator Talk(){
		currentState = state.TALKING;
		rend.material.mainTexture = faces[dialogs[currentDialog].faceWhileTalking];
		dm.ToggleActive ();
		int i = 0;
		foreach(string text in dialogs[currentDialog].stringArray){
			dm.UpdateDialog (text);
			float time = Time.time;
			if (!audio.isPlaying && NPCProducesSound) {
				audio.clip = voices[i % voices.Length];
				audio.Play ();
				i++;
			}
			do {
				yield return null;
			} while ((!Input.GetButtonDown ("Fire1") || (Time.time < (time + dialogTimer))) && Vector3.Distance (player.transform.position, transform.position) <= maxTalkingDistance);
			if (audio.isPlaying) {
				audio.Stop ();
			}
			if (Vector3.Distance (player.transform.position, transform.position) > maxTalkingDistance) {
				break;
			}
		}

		dm.UpdateDialog ("");
		dm.ToggleActive ();
		rend.material.mainTexture = faces[dialogs[currentDialog].faceAfterTalking];
		if (dialogs [currentDialog].stateAfterDialog == state.TALKING) {
			currentState = state.IDLE;
		} else {
			currentState = dialogs [currentDialog].stateAfterDialog;
		}
		currentDialog = dialogs [currentDialog].nextDialog;
	}
}
