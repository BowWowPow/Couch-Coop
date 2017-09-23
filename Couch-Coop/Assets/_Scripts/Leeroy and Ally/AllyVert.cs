using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyVert : MonoBehaviour {
	private GameManager gM;
	public float moveSpeed;
	private float t, cooldown;
	public GameObject Ball, XBarrel, BBarrel,Target;
	public static AllyVert _instance;
	public float velocity,moveZ;

	// Use this for initialization
	void Start () {
		velocity = .0f;
		moveSpeed = 50.0f;
	}	

	void Awake()
	{
		GameObject temp_gm = GameObject.FindGameObjectWithTag ("MainCamera");
		gM = temp_gm.GetComponent<GameManager> ();
		_instance = this;
	}

	void Update () {
		moveZ = moveSpeed * Input.GetAxis ("LeftJoystickVertical") * Time.deltaTime;
	}

	public void MoveVertical(){
		transform.Translate (0f,0f, moveZ);
		Vector3 temp_vect = new Vector3(transform.position.x,0.0f,Mathf.Clamp (transform.position.z, -5.25f, 5.25f));
		transform.position = temp_vect;
	}

	public void XFire(){
		GameObject Temporary_Bullet_Handler;
		Temporary_Bullet_Handler = Instantiate (Ball, XBarrel.transform.position, XBarrel.transform.rotation) as GameObject;
		gM.BallOff ();
	}

	public void BFire(){
		GameObject Temporary_Bullet_Handler;
		Temporary_Bullet_Handler = Instantiate (Ball, BBarrel.transform.position, BBarrel.transform.rotation) as GameObject;
		gM.BallOff ();
	}

}
	