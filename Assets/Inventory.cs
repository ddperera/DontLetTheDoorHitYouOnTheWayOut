using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	// ! Inventory Items must be given unique names !
	Dictionary<string,GameObject> myItems = new Dictionary<string,GameObject>();
	int myMoney = 0;


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

	public bool OwnsObject(string name){
		return myItems.ContainsKey(name);
	}

	public bool OwnsObject(GameObject item){
		return myItems.ContainsValue(item);
	}

	public void AddMoney(int amount){
		myMoney += amount;
	}

	public void SubtractMoney(int amount){
		myMoney -= amount;
	}

	public bool HasEnoughMoney(int price){
		return myMoney >= price;
	}

	public void PurchaseFor(int price){
		if (HasEnoughMoney(price)) {
			SubtractMoney (price);
		}
	}
}
