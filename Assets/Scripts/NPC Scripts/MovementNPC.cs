using UnityEngine;
using System.Collections;

public class MovementNPC : MonoBehaviour {

	public float speed;
	public float delta = 0.1f;

	private Rigidbody rb;
	private Transform target;

	public bool shouldMakeRollSound;

	public AudioClip rolling;
	private AudioSource audio;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		target = transform.parent.GetChild (0);
		audio = GetComponent<AudioSource> ();
	}

	void FixedUpdate(){
		if (Vector3.Magnitude (target.position - transform.position) > delta) {
			Vector3 movement = Vector3.Normalize (target.position - transform.position);
			rb.velocity = movement * speed;
			if ((target.position - transform.position).magnitude > 1.5f && shouldMakeRollSound) {
				if (!audio.isPlaying) {
					audio.clip = rolling;
					audio.Play ();
				}
			}
		} else {
			rb.velocity = Vector3.zero;
		}
	}
}
