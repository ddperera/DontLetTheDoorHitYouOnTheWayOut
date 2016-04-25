using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	public string keyString;

	private bool isFollowing;

	void Start () {
		isFollowing = false;
	}

	void Update () {
		if (Input.GetKeyDown (keyString) && !isFollowing) {
			Debug.Log ("set to true");
			isFollowing = true;
		} else if (Input.GetKeyDown (keyString)) {
			Debug.Log ("set to false");
			isFollowing = false;
		}
	}

	public bool getIsFollowing () {
		return isFollowing;
	}
}
