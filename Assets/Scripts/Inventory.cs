using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	// ! Inventory Items must be given unique names !
	Dictionary<string,GameObject> myItems = new Dictionary<string,GameObject>();
	int myMoney = 0;
	public Text moneyAmountUI;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddObject(string name, GameObject item){
		myItems.Add(name,item);
	}

	public void RemoveObject(string name){
		myItems.Remove(name);
	}

	public void RemoveObject(GameObject item){
		if (OwnsObject (item)) {
			foreach (string key in myItems.Keys) {
				if (myItems [key] == item) {
					myItems.Remove (key);
				}
			}
		}
	}

	public bool OwnsObject(string name){
		return myItems.ContainsKey(name);
	}

	public bool OwnsObject(GameObject item){
		return myItems.ContainsValue(item);
	}

	public void AddMoney(int amount){
		myMoney += amount;
		StartCoroutine(updateMoneyUI());
	}

	public void SubtractMoney(int amount){
		myMoney -= amount;
		StartCoroutine(updateMoneyUI());
	}

	public bool HasEnoughMoney(int price){
		return myMoney >= price;
	}

	public void PurchaseFor(int price){
		if (HasEnoughMoney(price)) {
			SubtractMoney (price);
		}
	}

	IEnumerator updateMoneyUI(){
		float TIMER = 2.5f; // duration of effect and seconds until auto-destroy coroutine (in case of infinite loops)
		float START_TIME = Time.time;
		while (int.Parse(moneyAmountUI.text.Substring(1)) != myMoney || Time.time - START_TIME <= TIMER) {
			int intermediateAmount = int.Parse(moneyAmountUI.text.Substring(1));
			float lerpFraction = (Time.time - START_TIME) / TIMER;
			intermediateAmount = Mathf.RoundToInt(Mathf.Lerp(int.Parse(moneyAmountUI.text.Substring(1)), myMoney, lerpFraction));
			moneyAmountUI.text = "$" + intermediateAmount.ToString();
			yield return null;
		}
		moneyAmountUI.text = "$" + myMoney.ToString();
		yield return null;
	}
}
