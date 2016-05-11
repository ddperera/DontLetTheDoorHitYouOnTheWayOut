using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager gm;

	//[HideInInspector]

	public bool level1Cleared;
	public bool level2Cleared;
	public bool firstTimePlaying;


	void Awake () {
		if (gm == null) {
			DontDestroyOnLoad (gameObject);
			gm = this;


		} else if (gm != this){
			Destroy (gameObject);
		}
	}

	void Start(){
		firstTimePlaying = false;
	}

	void Update (){
		if (Input.GetKeyDown (KeyCode.Q)) {
			Application.Quit ();
		}
	}
}
