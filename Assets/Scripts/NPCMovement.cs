using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour {

	public float walkSpeed = 2f;
	public float idleSpeed = 0.1f;
	//minimum distance that NPC will leave between player and itself when following
	public float minDistToPlayer = 3f;
	//distance from player after which NPC will stop following player
	public float maxDistToPlayer = 10f;
	public float chaseTimeout;

	private PlayerInteraction playerInteraction;
	private NavMeshAgent nav;
	private GameObject player;
	private float endChaseTimer;
	private float patrolTimer;

	void Awake() {
		playerInteraction = GetComponent<PlayerInteraction> ();
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update() {
		float distToPlayer = Vector3.Distance (player.transform.position, transform.position);

		if (playerInteraction.getIsFollowing () && distToPlayer > minDistToPlayer && distToPlayer < maxDistToPlayer) {
			follow ();
		} else {
			idle ();
		}
		
	}

	void follow () {
		nav.speed = walkSpeed;
		nav.destination = player.transform.position;
	}

	void idle () {
		nav.speed = idleSpeed;
		nav.destination = transform.position;
	}

}
