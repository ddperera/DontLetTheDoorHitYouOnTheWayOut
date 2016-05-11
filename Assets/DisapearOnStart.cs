using UnityEngine;
using System.Collections;

public class DisapearOnStart : MonoBehaviour {

	public float waitTime = 0.4f;

	void Start() {
		gameObject.SetActive (true);
		StartCoroutine("Disapear");
	}

	IEnumerator Disapear() {
		float time = Time.time;
		do {
			yield return null;
		} while (Time.time < time + waitTime);
		transform.position = transform.position + Vector3.right * 40f;
		gameObject.SetActive (false);
	}
}
