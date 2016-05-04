using UnityEngine;
using System.Collections;

public class ExitDoorLevelTwoBehavior : MonoBehaviour {

	GameObject thePlayer;
	string requiredObjectName = GameConstants.LEVEL_TWO_DOOR_HANDLE_NAME;
	bool openable = false;
	public GameObject theMissingHandle;

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
			theMissingHandle.SetActive (true);
			Vector3 initialPosition = theMissingHandle.transform.localPosition;
			Quaternion initialRotation = theMissingHandle.transform.localRotation;
			Vector3 initialScale = theMissingHandle.transform.localScale;
			//GameObject newShape = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			//gameObject.transform.FindChild("Pull Area").GetComponent<MeshFilter>().mesh = newShape.GetComponent<MeshFilter>().mesh;
			/*theMissingHandle.transform.SetParent(gameObject.transform.FindChild("Pull Area"));
			theMissingHandle.transform.position = initialPosition;
			theMissingHandle.transform.rotation = initialRotation;
			theMissingHandle.transform.localScale = initialScale;*/
				
			//Destroy (newShape);
		}
		else if (openable) {
			this.gameObject.GetComponent<Animator>().SetTrigger("openDoor");
		}
	}
}
