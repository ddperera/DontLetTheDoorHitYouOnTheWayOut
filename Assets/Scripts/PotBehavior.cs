using UnityEngine;
using System.Collections;

public class PotBehavior : MonoBehaviour {

	GameObject thePlayer;
	ParticleSystem myParticles;
	TextMesh myLootCount;
	bool waitingForDestruction = false;
	int breakPotAmount = 100;
	int myLootAmount = 1;
	public GameObject lootPickup;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		myParticles = gameObject.transform.GetComponentInChildren<ParticleSystem>();
		myLootCount = gameObject.transform.GetComponentInChildren<TextMesh>();
		myLootCount.gameObject.SetActive (false);
		myParticles.Stop();
		myParticles.enableEmission = false;
		myLootAmount = Mathf.RoundToInt(Random.Range(1000, 5000));
	}

	// Update is called once per frame
	void Update () {
		
		if (myLootCount.gameObject.activeInHierarchy) {
			// Set loot count to face the player
			myLootCount.gameObject.transform.LookAt(thePlayer.transform.position);
			myLootCount.gameObject.transform.Rotate (Vector3.up, 180);
			myLootCount.transform.position += Vector3.up * 0.01f;
		}
	}

	public void OnPlayerClicked(){
		
		if (!waitingForDestruction) {
			waitingForDestruction = true;
			thePlayer.GetComponent<AudioSource> ().PlayOneShot (gameObject.GetComponent<AudioSource>().clip);
			myParticles.enableEmission = true;
			myParticles.Play();
			myLootCount.gameObject.SetActive(true);
			myLootCount.text = "+$" + breakPotAmount.ToString();
			this.gameObject.GetComponent<Animator>().SetTrigger("isBroken");
			thePlayer.GetComponent<Inventory> ().AddMoney (breakPotAmount);
			PotRespawnTriggerBehavior.numPots -= 1;
			GenerateLootPickups();
			StartCoroutine (DestroyCountdown (0.9f));
		}
	}

	IEnumerator DestroyCountdown(float delay){
		yield return new WaitForSeconds (delay);
		Destroy (this.gameObject);
		yield return null;
	}


	void GenerateLootPickups(){
		int numberOfPickups = Random.Range (1, 5);
		for (int i = 0; i < numberOfPickups; i++) {
			GameObject theLoot = Instantiate (lootPickup, this.gameObject.transform.position + Vector3.up, Quaternion.identity) as GameObject;
			theLoot.GetComponent<LootPickupBehavior>().SetLootAmount(myLootAmount);
			theLoot.GetComponent<Rigidbody> ().AddForce(new Vector3(Random.Range (10, 50),Random.Range (10, 50),Random.Range (10, 50)));
		}
	}
}
