using UnityEngine;
using System.Collections;

public class DoorBehavior : MonoBehaviour {

	private GameObject thePlayer;
	public GameObject myLock;
	private bool locked = true;
	private bool needsKey = false;
	public Vector3 unlockMoveOffset = new Vector3(0,0.05f,0);
	public GameObject myKey;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnPlayerClicked(){
		if (locked) {
			if (!needsKey || (needsKey && thePlayer.GetComponent<Inventory> ().OwnsObject (myKey))) {
				thePlayer.GetComponent<Inventory> ().RemoveObject (myKey);
				locked = false;
				thePlayer.GetComponent<AudioSource> ().PlayOneShot (gameObject.GetComponent<AudioSource>().clip);
				// Lock visual effect (move lock part up)
				myLock.transform.position += unlockMoveOffset;
				this.gameObject.tag = "Interactable";
			}
		} else {
			
			this.gameObject.GetComponent<Animator>().SetTrigger("openDoor");
			//this.gameObject.SetActive (false);
		}

	}
}
