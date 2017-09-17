using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleRotator : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		speed = 200.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.P)) {
			transform.Rotate(Vector3.up * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.O)) {
			transform.Rotate(-Vector3.up * speed * Time.deltaTime);
		}


	}
}
