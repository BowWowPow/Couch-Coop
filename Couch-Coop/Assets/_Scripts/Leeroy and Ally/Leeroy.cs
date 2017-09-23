using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leeroy : MonoBehaviour {

	public float moveSpeed;
	public bool canFire;
	private float t, cooldown;
	public GameObject Bullet,Barrel;
	public float velocity;
	public int player_n;
	// Use this for initialization
	void Start () {
		moveSpeed = 10.0f;
		velocity = 100.0f;
		cooldown = 1.0f;
		t = 0.0f;
		player_n = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (t <= cooldown) {
			t += Time.deltaTime;
		} else {
			canFire = true;
		}
	}

	public bool CanFire(){
		return canFire;
	}

	private void ResetT(){
		t = 0;
	}

	public void Fire(){
		GameObject Temporary_Bullet_Handler;
		Temporary_Bullet_Handler = Instantiate (Bullet, Barrel.transform.position, Barrel.transform.rotation) as GameObject;
		Temporary_Bullet_Handler.transform.Rotate (new Vector3(Input.GetAxis ("Horizontal_p2"),Input.GetAxis ("Vertical_p2"),0));
		Rigidbody Temporary_RigidBody;
		Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody> ();
		Temporary_RigidBody.AddForce (transform.forward * velocity);
		ResetT ();
		CantFire ();
		Destroy (Temporary_Bullet_Handler, 10.0f);
	}

	private void CantFire (){
		canFire = false;
	}

	public void SetPlayer(int i){
		player_n = i;
	}


	public void MovePlayer (){
		transform.Translate (moveSpeed * Input.GetAxis ("Horizontal_p2") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis ("Vertical_p2") * Time.deltaTime);
	}
}
