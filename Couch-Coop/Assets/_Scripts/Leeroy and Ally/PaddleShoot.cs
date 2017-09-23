using UnityEngine;
using System.Collections;

public class PaddleShoot : MonoBehaviour
{
	//Drag in the Bullet Emitter from the Component Inspector.
	public GameObject p1_Bullet_Emitter,p2_Bullet_Emitter;

	//Drag in the Bullet Prefab from the Component Inspector.
	public GameObject p1_Bullet,p2_Bullet;
	private string kcode;
	//Enter the Speed of the Bullet from the Component Inspector.
	public float p1_Bullet_Forward_Force, p2_Bullet_Forward_Force;
	public float p1_cooldown, p1_t, p2_cooldown, p2_t;

	// Use this for initialization
	void Start ()
	{
		p1_cooldown = 1.0f;
		p1_t = 0.0f;
		p2_cooldown = 0.3f;
		p2_t = 0.0f;
		p1_Bullet_Forward_Force = 10.0f;
		p2_Bullet_Forward_Force = 10.0f;
	}

	// Update is called once per frame
	void Update ()
	{
//		if (p1_t >= p1_cooldown) 
//		{
//			PaddleFire ();
//		} else {
//			p1_t += Time.deltaTime;
//		}
//
//		if (p2_t >= p2_cooldown) 
//		{
//			PlayerFire ();
//		} else {
//			p2_t += Time.deltaTime;
//		}
	}

	private void ResetP1T(){
		p1_t = 0;
	}


	public void PaddleFire(){
			//The Bullet instantiation happens here.
			GameObject Temporary_Bullet_Handler;
			Temporary_Bullet_Handler = Instantiate (p1_Bullet, p1_Bullet_Emitter.transform.position, p1_Bullet_Emitter.transform.rotation) as GameObject;

			//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
			//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
			Temporary_Bullet_Handler.transform.Rotate (Vector3.left * 90);

			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody> ();

			//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
			Temporary_RigidBody.AddForce (transform.forward * p1_Bullet_Forward_Force);
			ResetP1T ();
			//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
			Destroy (Temporary_Bullet_Handler, 10.0f);
	}
		
}
