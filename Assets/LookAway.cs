using UnityEngine;
using System.Collections;

public class LookAway : MonoBehaviour {

	public Transform lookTarget;

	private PlayerInteraction pi;

	void Start(){
		pi = GetComponent<PlayerInteraction> ();
	}

	void FixedUpdate(){
		if (pi.curState == PlayerInteraction.state.IDLE) {
			Vector3 relativePos = lookTarget.transform.position - transform.position;
			Quaternion rot = Quaternion.LookRotation(relativePos);
			transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.time * 0.01f);
		}
	}
}
