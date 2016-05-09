using UnityEngine;
using System.Collections;

public class EnterLevelTrigger : MonoBehaviour {

	public TurnToTrigger ttt;

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.CompareTag ("Player")) {
			ttt.turnToTrigger ();
		}
	}
}