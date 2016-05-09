using UnityEngine;
using System.Collections;

public class Temp : MonoBehaviour {

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.CompareTag ("Player")) {
			Application.LoadLevel("Intro_Level");
		}
	}
}
