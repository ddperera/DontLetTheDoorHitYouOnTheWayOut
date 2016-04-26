using UnityEngine;
using System.Collections;

public class NPCOnClick : MonoBehaviour {

	private PlayerInteraction pi;

	void Start () {
		pi = GetComponentInParent<PlayerInteraction> ();
	}
	
	public void OnPlayerClicked(){
		pi.Clicked();
	}
}
