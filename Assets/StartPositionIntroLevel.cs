using UnityEngine;
using System.Collections;

public class StartPositionIntroLevel : MonoBehaviour {

	public Transform startPosition;

	void Awake () {
		if (GameManager.gm != null) {
			if (!GameManager.gm.firstTimePlaying) {
				transform.position = startPosition.position;
			}
		}
	}
}
