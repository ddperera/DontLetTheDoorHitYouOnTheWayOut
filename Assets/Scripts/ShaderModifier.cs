using UnityEngine;
using System.Collections;

public class ShaderModifier : MonoBehaviour {

	public Texture texture;

	private Renderer rend;
	private float timer = 3.0f;
	void Start() {
		rend = GetComponent<Renderer>();

	}

	void Update (){
		if (Time.time > timer) {
			rend.material.mainTexture = texture;
		}
	}
}
