using UnityEngine;
using System.Collections;

public class DoorHandleBehavior : MonoBehaviour {

	GameObject thePlayer;
	string myName = GameConstants.LEVEL_TWO_DOOR_HANDLE_NAME;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlayerClicked(){
		thePlayer.GetComponent<AudioSource> ().PlayOneShot (gameObject.GetComponent<AudioSource>().clip);
		thePlayer.GetComponent<Inventory>().AddObject(myName, gameObject);
		gameObject.SetActive (false);
	}
}
