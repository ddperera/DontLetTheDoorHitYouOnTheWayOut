using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	private Text dialog;
	private GameObject dialogBox;
	private bool isDialogActive;

	void Start (){
		dialogBox = transform.GetChild (0).gameObject;
		dialog = transform.GetChild (0).GetChild (0).GetComponent<Text> ();
		UpdateDialog ("");
		isDialogActive = false;
		dialogBox.SetActive (isDialogActive);
	}

	public void UpdateDialog(string text){
		dialog.text = text;
	}

	public void ToggleActive () {
		isDialogActive = !isDialogActive;
		dialogBox.SetActive (isDialogActive);
	}

}