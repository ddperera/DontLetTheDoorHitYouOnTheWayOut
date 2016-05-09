using UnityEngine;
using System.Collections;

public class ClearLevelTwo : MonoBehaviour {

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.CompareTag ("Player")) {
			GameManager.gm.level2Cleared = true;
		}
	}
}
