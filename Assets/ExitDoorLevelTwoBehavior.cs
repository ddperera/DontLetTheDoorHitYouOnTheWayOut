using UnityEngine;
using System.Collections;

public class ExitDoorLevelTwoBehavior : MonoBehaviour {

	GameObject thePlayer;
	string requiredObjectName = "Level2_DoorHandle_1";
	bool openable = false;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPlayerClicked(){
		//play some acquiring sound
		if (thePlayer.GetComponent<Inventory> ().OwnsObject (requiredObjectName)) {
			// Internal changes
			thePlayer.GetComponent<Inventory> ().RemoveObject (requiredObjectName);
			openable = true;
			// Effects of change
			GameObject newShape = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			gameObject.transform.FindChild("Pull Area").GetComponent<MeshFilter>().mesh = newShape.GetComponent<MeshFilter>().mesh;
			Destroy (newShape);
		}
		else if (openable) {
			gameObject.SetActive (false);
		}
	}
}
