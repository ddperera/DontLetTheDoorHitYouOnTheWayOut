using UnityEngine;
using System.Collections;

public class AddForceTowardTarget : MonoBehaviour {

	public Transform target;

	private Rigidbody rb;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		rb.AddForce (target.position - transform.position);
	}
}
