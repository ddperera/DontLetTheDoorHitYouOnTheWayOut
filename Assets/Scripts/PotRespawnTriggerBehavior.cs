using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PotRespawnTriggerBehavior : MonoBehaviour {
	
	public List<GameObject> respawnPots = new List<GameObject>(){};
	private List<Vector3> respawnLocations = new List<Vector3>(){};
	private List<Quaternion> respawnRotations = new List<Quaternion>(){};
	public GameObject pot;
	public static int numPots;

	// Use this for initialization
	void Start () {
		foreach (GameObject pot in respawnPots) {
			respawnLocations.Add(pot.transform.position);
			respawnRotations.Add(pot.transform.rotation);
		}
		numPots = respawnPots.Count;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if (numPots == 0) {
			numPots = respawnPots.Count;
			for (int i = 0; i < respawnPots.Count; i++) {
				Instantiate(pot, respawnLocations[i], respawnRotations[i]);
			}
		}
	}
}
