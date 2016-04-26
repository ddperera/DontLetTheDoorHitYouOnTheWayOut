using UnityEngine;
using System.Collections;

public class DoorHandleBehavior : MonoBehaviour {

	GameObject thePlayer;s
	string myName = "Level2_DoorHandle_1";

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlayerClicked(){
		//play some acquiring sound
		thePlayer.GetComponent<Inventory>().AddObject(myName, gameObject);
		gameObject.SetActive (false);
	}
}
