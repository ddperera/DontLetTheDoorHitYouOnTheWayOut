using UnityEngine;
using System.Collections;

public class TeleporterBehaviour : MonoBehaviour {

	public Transform destination;
	private bool solvedPuzzle = false;
	private GameObject player;
	private Movement playerInfo;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInfo = player.GetComponent<Movement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.CompareTag ("Player")) {
			if (playerInfo.isGhost) {
				solvedPuzzle = true;
			}

			if (!solvedPuzzle) {
				player.transform.position = destination.position;
			}
		}
	}
}
