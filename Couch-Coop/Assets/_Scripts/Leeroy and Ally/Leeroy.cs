using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leeroy : MonoBehaviour {

	public float moveSpeed;
	public bool canFire;
	private float t_fire, t_damageImmune, cd_fire, cd_damageImmune;
	public GameObject Bullet,Barrel;
	public float velocity;
	public int player_n =-1;
	public int health;
	private string playerName;
	public bool noDamage, isAlive;
	public GameObject healthUIWigit, HealthLayout;
	private GameObject _health_wigit_;
	public List<GameObject> HealthUI = new List<GameObject>();
	private HealthUIController _healthUI_;
	// Use this for initialization
	void Start () {
		moveSpeed = 10.0f;
		velocity = 100.0f;
		cd_fire = 1.0f;
		t_fire = 0.0f;
		t_damageImmune = 0.0f;
		cd_damageImmune = 10.0f;
		health = 3;
		noDamage = false;
		isAlive = true;
		playerName = "PLAYER " + player_n.ToString ();
		GameObject temp = Instantiate (healthUIWigit);
		HealthLayout = GameObject.FindGameObjectWithTag ("UI");
		temp.transform.parent = HealthLayout.transform;
		_healthUI_ = temp.gameObject.GetComponent<HealthUIController> ();
		_healthUI_.SetUIHealthBar (playerName, health);
	}
	
	// Update is called once per frame
	void Update () {
			if (t_fire <= cd_fire) {
				t_fire += Time.deltaTime;
			} else {
				canFire = true;
			}

		if (noDamage == true) {
			t_damageImmune += Time.deltaTime;

			if (t_damageImmune >= cd_damageImmune) {
				noDamage = false;
				ResetDamageImmuneTimer ();
			}
		}	
	}

	public bool CanFire(){
		return canFire;
	}

	private void ResetFireTimer(){
		t_fire = 0;
	}

	private void ResetDamageImmuneTimer(){
		t_fire = 0;
	}

	public void Fire(){

	}

	private void CantFire (){
		canFire = false;
	}

	public void SetPlayer(int i){
		player_n = i;
	}

	public int GetPlayer(){
		return player_n;
	}

	void OnCollisionEnter() {
		if (noDamage == false) {
			RemoveHealth ();
			PlayerIsImmune ();
			StartCoroutine("ColorLerp");
		}
	}

	public void PlayerIsImmune(){
		noDamage = true;
	}

	public int GetHealth(){
		return health;
	}

	IEnumerator ColorLerp(){
		int total_loops = 6;
		int n_loops = 0;
		float totalTimeToLerp = 1.0f;
		float t = 0.0f;
		Renderer rend = this.transform.GetComponent<Renderer> ();
		Color startColour = rend.material.color;
		Color endColour = Color.white;

		while (n_loops < total_loops) {
			t += Time.deltaTime;
			float lerpPercent = Mathf.Clamp (t / totalTimeToLerp, 0, 1);
			rend.material.color = Color.Lerp (startColour, endColour, lerpPercent);
			if (lerpPercent == 1) {
				Color nextColor = startColour;
				startColour = endColour;
				endColour = nextColor;
				t = 0;
				n_loops++;
				if (n_loops >= total_loops) {
					yield return true;
				}
			} else {
				yield return false;
			}
		}
			
	}
	public bool isPlayerAlive(){
		if (health == 0) {
			isAlive = false;
		}
		return isAlive;
	}
	public void Dead(){
		Destroy (this.gameObject);
	}
	public void RemoveHealth(){
		health -= 1;
		_healthUI_.RemoveHeart ();
	}
	public void MovePlayer(){
		//Debug.Log ("Moving Player : " + player_n.ToString ());
		string horz = "LeeroyHorizontal_" + player_n.ToString ();
		string vert = "LeeroyVertical_" + player_n.ToString ();
		//Debug.Log (Input.GetAxis (vert));
		transform.Translate (moveSpeed * Input.GetAxis (horz) * Time.deltaTime, 0f, moveSpeed * Input.GetAxis (vert) * Time.deltaTime);
	}
}
