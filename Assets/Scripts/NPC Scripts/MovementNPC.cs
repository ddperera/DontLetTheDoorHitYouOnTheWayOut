using UnityEngine;
using System.Collections;

public class MovementNPC : MonoBehaviour {

	public float speed;
	public float delta = 0.1f;

	private Rigidbody rb;
	private Transform target;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		target = transform.parent.GetChild (0);
		//target = GameObject.FindGameObjectWithTag ("NPCTarget").transform;
	}

	void FixedUpdate(){
		if (Vector3.Magnitude (target.position - transform.position) > delta) {
			Vector3 movement = Vector3.Normalize (target.position - transform.position);
			rb.velocity = movement * speed;
		} else {
			rb.velocity = Vector3.zero;
		}
	}
}
