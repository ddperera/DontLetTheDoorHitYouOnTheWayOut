using UnityEngine;
using System.Collections;

public class DisapearOnStart : MonoBehaviour {

	public float waitTime = 0.2f;

	void Start() {
		StartCoroutine("Disapear");
	}

	IEnumerator Disapear() {
		float time = Time.time;
		do {
			yield return null;
		} while (Time.time < time + waitTime);
		gameObject.SetActive (false);
	}
}
