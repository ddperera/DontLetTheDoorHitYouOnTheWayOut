using UnityEngine;
using System.Collections;

public class SignBehavior : MonoBehaviour {

	public Rigidbody rb;
	AudioSource aSource;
	
	private bool hasFallen;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		hasFallen = false;
		aSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnPlayerClicked() {
		rb.isKinematic = false;
		if (!hasFallen) {
			aSource.Play(44100/4);
			hasFallen = true;
		}
		
	}
}
