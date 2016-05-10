using UnityEngine;
using System.Collections;

public class ElectricityTriggerBehavior : MonoBehaviour {
	
	public GameObject electricity;
	
	GameObject player;
	Movement playerInfo;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInfo = player.GetComponent<Movement> ();
	}
	
	void OnTriggerEnter(Collider other) {
		if (electricity.active == true) {
			if (!playerInfo.isGhost) {
				playerInfo.isGhost = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
