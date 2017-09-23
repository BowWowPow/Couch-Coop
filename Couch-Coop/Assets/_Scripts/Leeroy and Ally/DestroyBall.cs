using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour {
	private GameManager gM;
	// Use this for initialization
	void Start () {
		gM = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<GameManager> ();
	}

	void OnTriggerEnter(Collider collide){	
		if (collide.gameObject.tag == "Ball") {
			Destroy (collide.gameObject);
			gM.BallOn ();
		}
	}
}
