﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	public GameObject Target;
	public float speed, maxSpeed, minSpeed;
	void Start(){
		speed = 200.0f;
		maxSpeed = 300.0f;
		minSpeed = 5.0f;
		GameObject temp = GameObject.FindGameObjectWithTag ("MainCamera");
		GameManager gM = temp.GetComponent<GameManager> ();
		Rigidbody t_Rigidbody = Target.GetComponent<Rigidbody> ();
		gM.BallOff ();
		Transform t_Transform = Target.GetComponent<Transform> ();
		transform.LookAt (t_Transform);
		this.GetComponent<Rigidbody> ().AddForce(this.transform.forward * speed);
	}

	void FixedUpdate(){
		if(this.GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
		{
			this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
		}

		if(this.GetComponent<Rigidbody>().velocity.magnitude < minSpeed)
		{
			this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity.normalized * minSpeed;
		}
	}

	void OnCollisionEnter(Collision collision){
		
		if (collision.gameObject.tag == "A") {
			float x_dist = DistanceX (collision.gameObject);
			float z_dist = DistanceZ (collision.gameObject);
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (x_dist * 2.0f, 0.0f, z_dist * 2.0f);
		}
		if (collision.gameObject.tag == "B") {
			float x_dist = DistanceX (collision.gameObject);
			float z_dist = DistanceZ (collision.gameObject);
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (x_dist * 2.0f, 0.0f, z_dist * 2.0f);
		}
		if (collision.gameObject.tag == "Y") {
			float x_dist = DistanceX (collision.gameObject);
			float z_dist = DistanceZ (collision.gameObject);
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (x_dist * 2.0f, 0.0f, z_dist * 2.0f);
		}
		if (collision.gameObject.tag == "X") {
			float x_dist = DistanceX (collision.gameObject);
			float z_dist = DistanceZ (collision.gameObject);
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (x_dist * 2.0f, 0.0f, z_dist * 2.0f);
		}

		speed += 3.0f;
		//this.GetComponent<Rigidbody> ().velocity = this.GetComponent<Rigidbody> ().velocity.normalized * speed;
	}

	public float DistanceX(GameObject obj){
		float x_dist = this.transform.position.x - obj.transform.position.x;
		return x_dist;
	}

	public float DistanceZ(GameObject obj){
		float z_dist = this.transform.position.z - obj.transform.position.z;
		return z_dist;
	}
}
		
