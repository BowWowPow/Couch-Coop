using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoLife : MonoBehaviour {

	public float lifeTime, t;
	// Use this for initialization
	void Start () {
		lifeTime = 10.0f;
		t = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (t >= lifeTime) 
		{
			Destroy ();
		} 
			else 
		{
			t += Time.deltaTime;
		}
	}

	private void resetT (){
		t = 0.0f;
	}

	public void Destroy(){
		Transform.Destroy ();

	}
}
