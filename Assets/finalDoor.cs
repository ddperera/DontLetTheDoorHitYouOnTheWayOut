using UnityEngine;
using System.Collections;

public class finalDoor : MonoBehaviour {

	private GameObject thePlayer;
	private bool locked = true;
	private bool needsKey = false;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPlayerClicked(){
		if (locked) {
			if (GameManager.gm != null && GameManager.gm.level1Cleared && GameManager.gm.level2Cleared) {
				locked = false;
				thePlayer.GetComponent<AudioSource> ().PlayOneShot (gameObject.GetComponent<AudioSource>().clip);
				// Lock visual effect (move lock part up)
				this.gameObject.tag = "Interactable";
			}
		} else {

			this.gameObject.GetComponent<Animator>().SetTrigger("openDoor");
			//this.gameObject.SetActive (false);
		}

	}
}
