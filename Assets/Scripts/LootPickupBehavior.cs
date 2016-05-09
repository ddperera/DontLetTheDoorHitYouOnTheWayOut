using UnityEngine;
using System.Collections;

public class LootPickupBehavior : MonoBehaviour {

	GameObject thePlayer;
	int myLootAmount = 1;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Physics.Raycast (this.gameObject.transform.position, Vector3.down, 0.3f)) {
			this.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		} else {
			this.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		}
		this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.up, 5);
	}

	void OnTriggerEnter(Collider coll){
		Debug.Log (coll);
		if (coll.gameObject.tag == "Player") {
			thePlayer.GetComponent<AudioSource> ().PlayOneShot (gameObject.GetComponent<AudioSource>().clip);
			thePlayer.GetComponent<Inventory>().AddMoney(myLootAmount);
			Destroy (this.gameObject);
		}
	}

	public void SetLootAmount(int amount){
		myLootAmount = amount;
	}
}
