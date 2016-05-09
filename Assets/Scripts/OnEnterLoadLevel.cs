using UnityEngine;
using System.Collections;

public class OnEnterLoadLevel : MonoBehaviour {

	public string levelName;

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.CompareTag ("Player")) {
			GameManager.gm.firstTimePlaying = false;
			Application.LoadLevel(levelName);
		}
	}
}