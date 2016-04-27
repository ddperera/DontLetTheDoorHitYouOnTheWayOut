using UnityEngine;
using System.Collections;

public class PotBehavior : MonoBehaviour {

	GameObject thePlayer;
	ParticleSystem myParticles;
	TextMesh myLootCount;
	bool waitingForDestruction = false;
	int myLootAmount = 1;

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
	
	}

	public void OnPlayerClicked(){
		//TODO play smashing sound
		myParticles.enableEmission = true;
		myParticles.Play();
		myLootCount.gameObject.SetActive(true);
		myLootCount.text = "+" + myLootAmount.ToString();
		if (!waitingForDestruction) {
			waitingForDestruction = true;
			thePlayer.GetComponent<Inventory> ().AddMoney (myLootAmount);
			PotRespawnTriggerBehavior.numPots -= 1;
			StartCoroutine (DestroyCountdown (0.9f));
		}
	}

	IEnumerator DestroyCountdown(float delay){
		yield return new WaitForSeconds (delay);
		Destroy (this.gameObject);
		
		yield return null;
	}

}
