using UnityEngine;
using System.Collections;

public class ResetIntroText : MonoBehaviour {

	public GameObject theText;
	Vector3 resetPosition;

	// Use this for initialization
	void Start () {
		resetPosition = theText.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		Debug.Log ("l");
		if (coll.gameObject.transform.parent.gameObject == theText) {
			theText.transform.position = resetPosition;
			theText.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
	}
}
