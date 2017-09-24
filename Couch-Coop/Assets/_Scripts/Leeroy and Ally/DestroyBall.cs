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
		if (collide.gameObject.tag == "Player") {
			collide.gameObject.transform.position = new Vector3 (0, 0.25f, 0);
			collide.gameObject.GetComponent<Leeroy>().RemoveHealth ();
			collide.gameObject.GetComponent<Leeroy>().PlayerIsImmune ();
			collide.gameObject.GetComponent<Leeroy>().StartCoroutine("ColorLerp");
		}
	}
}
