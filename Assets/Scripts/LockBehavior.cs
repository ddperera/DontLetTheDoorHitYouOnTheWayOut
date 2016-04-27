using UnityEngine;
using System.Collections;

public class LockBehavior : MonoBehaviour {

	private GameObject thePlayer;
	public GameObject myDoor;
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
				// Lock visual effect (move lock part up)
				this.gameObject.transform.position += unlockMoveOffset;
				myDoor.tag = "Interactable";
			}
		} else {
			//TODO play some opening sound
			myDoor.gameObject.SetActive (false);
		}

	}
}
