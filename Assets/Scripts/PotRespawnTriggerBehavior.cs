using UnityEngine;
using System.Collections;

public class PotRespawnTriggerBehavior : MonoBehaviour {
	
	public static int numPots = 4;
	public GameObject pot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if (numPots == 0) {
			numPots = 4;
			Instantiate(pot, new Vector3(-5.813f, 0.462f, 2.729f), Quaternion.identity);
			Instantiate(pot, new Vector3(-7.54f, 0.462f, 3.2f), Quaternion.identity);
			Instantiate(pot, new Vector3(-8.62f, 0.462f, 4.33f), Quaternion.identity);
			Instantiate(pot, new Vector3(-8.81f, 0.462f, 5.69f), Quaternion.identity);
		}
	}
}
