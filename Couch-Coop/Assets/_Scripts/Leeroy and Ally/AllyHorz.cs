using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHorz : MonoBehaviour {

	private GameManager gM;
	public float moveSpeed;
	private float t, cooldown;
	public GameObject Ball, YBarrel, ABarrel,Target;
	public static AllyHorz _instance;
	public float velocity,moveX;

	// Use this for initialization
	void Start () {
		moveSpeed = 50.0f;
	}

	void Awake()
	{
		GameObject temp_gm = GameObject.FindGameObjectWithTag ("MainCamera");
		gM = temp_gm.GetComponent<GameManager> ();
		_instance = this;
	}
	// Update is called once per frame
	void Update () {
		velocity = 10.0f;
		moveX = moveSpeed * Input.GetAxis ("LeftJoystickHorizontal") * Time.deltaTime;
	}

	public void MoveHorizontal(){
		transform.Translate (new Vector3(moveX, 0f, 0f));
		Vector3 temp_vect = new Vector3 (Mathf.Clamp (transform.position.x, -5.25f, 5.25f),0.0f,transform.position.z);
		transform.position = temp_vect;
	}


	public void YFire(){
		GameObject Temporary_Bullet_Handler;
		Temporary_Bullet_Handler = Instantiate (Ball, YBarrel.transform.position, YBarrel.transform.rotation) as GameObject;
		gM.BallOff ();
	}

	public void AFire(){
		GameObject Temporary_Bullet_Handler;
		Temporary_Bullet_Handler = Instantiate (Ball, ABarrel.transform.position, ABarrel.transform.rotation) as GameObject;
		gM.BallOff ();
	}
}
