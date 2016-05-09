using UnityEngine;
using System.Collections;

public class TeleporterBehaviour : MonoBehaviour {

	public Transform destination;
	public Transform NPC;

	private bool solvedPuzzle = false;
	private GameObject player;
	private Transform NPCTarget;
	private Transform NPCBody;
	private Movement playerInfo;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		NPCTarget = NPC.GetChild(0);
		NPCBody = NPC.GetChild(1);
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
				NPCTarget.GetComponent<TargetMovementNPC> ().enabled = false;
				NPCTarget.GetComponent<NavMeshAgent> ().enabled = false;


				NPCTarget.position += destination.position - transform.position;
				NPCBody.position += destination.position - transform.position;

				//NPCTarget.position = NPCTarget.transform.position + (destination.position - player.transform.position);
				//NPCBody.position = NPCTarget.position + Vector3.up * 2f;
				//NPC.transform.position = NPC.transform.position + (destination.position - player.transform.position);


				NPCTarget.GetComponent<NavMeshAgent> ().enabled = true;
				NPCTarget.GetComponent<TargetMovementNPC> ().enabled = true;


				player.transform.position += destination.position - transform.position;
				//player.transform.position = player.transform.position + Vector3.forward * 100f;
				//player.transform.position = destination.position;
			}
		}
	}
}
