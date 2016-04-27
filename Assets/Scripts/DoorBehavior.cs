using UnityEngine;
using System.Collections;

public class DoorBehavior : MonoBehaviour {

	public GameObject myLock;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlayerClicked(){
		myLock.GetComponent<LockBehavior>().OnPlayerClicked ();
	}
}
