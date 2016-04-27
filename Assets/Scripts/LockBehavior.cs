using UnityEngine;
using System.Collections;

public class LockBehavior : MonoBehaviour {

	private GameObject thePlayer;
	public GameObject myDoor;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlayerClicked(){
		myDoor.GetComponent<DoorBehavior>().OnPlayerClicked ();
	}
}
