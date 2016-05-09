using UnityEngine;
using System.Collections;

public class TurnToTrigger : MonoBehaviour {

	public float waitTime = 0.2f;

	public void turnToTrigger() {
		StartCoroutine("TTT");
	}

	IEnumerator TTT() {
		float time = Time.time;
		do {
			yield return null;
		} while (Time.time < time + waitTime);
		GetComponent<MeshCollider> ().isTrigger = true;
	}

}
