﻿using UnityEngine;
using System.Collections;

public class ClearLevelOne : MonoBehaviour {

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.CompareTag ("Player")) {
			GameManager.gm.level1Cleared = true;
		}
	}
}
