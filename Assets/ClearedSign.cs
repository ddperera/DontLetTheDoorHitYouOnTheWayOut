using UnityEngine;
using System.Collections;

public class ClearedSign : MonoBehaviour {

	public enum level {LEVEL1, LEVEL2};
	public level lvl;

	public void Start() {
		if (lvl == level.LEVEL1) {
			gameObject.SetActive(GameManager.gm.level1Cleared);
		} else {
			gameObject.SetActive(GameManager.gm.level2Cleared);
		}
	}

}
