using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoLife : MonoBehaviour {

	public float lifeTime, t;
	public
	// Use this for initialization
	void Start () {
		lifeTime = 10.0f;
		Color startingColor;
		t = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void resetT (){
		t = 0.0f;
	}

	public void Destroy(){

	}
}
