using UnityEngine;
using System.Collections;

public class SignBehavior : MonoBehaviour {

	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnPlayerClicked() {
		rb.isKinematic = false;
		Debug.Log("sign fall", this);
	}
}
