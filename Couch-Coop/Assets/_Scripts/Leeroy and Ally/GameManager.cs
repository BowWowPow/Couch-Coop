using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject _ally_vert_,_ally_horz_,_walls_;
	public static GameObject _ALLY_VERT_,_ALLY_HORZ_,_WALLS_;
	public static GameManager _gm_instance;
	public static InputManager _input_instance;
	public Canvas _ui_,_UI_;
	public int n_Players;
	public GameObject _leeroy;
	public List<GameObject> Players = new List<GameObject>();
	public List<GameObject> HealthUI = new List<GameObject>();
	public ArrayList Colour = new ArrayList ();
	public bool ballCanFire,gameOver;
	public GameObject PlayerScoreUI;

	// Use this for initialization
	void Start () {
		ballCanFire = true;
		gameOver = false;
		_ALLY_VERT_ = Instantiate (_ally_vert_);
		_ALLY_HORZ_ = Instantiate (_ally_horz_);
		_WALLS_ = Instantiate (_walls_);
		_UI_ = Instantiate (_ui_);	
		n_Players = 2;
		int x = 2;
		int p = 0;
		for (int i = 0; i < n_Players; i++) {
			string leeroy = "leeroy_" + i.ToString (); 
			GameObject _Leeroy = new GameObject (leeroy);
			_Leeroy = Instantiate (_leeroy, new Vector3(x, 0.25f, 0.25f),  Quaternion.identity);
			x -= 2;
			Players.Add (_Leeroy);
			Debug.Log ("PLAYER VALUE : " + p.ToString());
			_Leeroy.gameObject.GetComponent<Leeroy> ().SetPlayer (p);
			p++;
			switch(i){
			case 0:
				_Leeroy.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				break;
			case 1:
				_Leeroy.gameObject.GetComponent<Renderer> ().material.color = Color.magenta;
				break;
			case 2:
				_Leeroy.gameObject.GetComponent<Renderer> ().material.color = Color.green;
				break;
			default:
				_Leeroy.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				break;
			}	
		}

	}
		 
	void Awake()
	{
		_gm_instance = this;
		_input_instance = InputManager._input_instance;
	}
	// Update is called once per frame
	void Update () {
		AnyoneLeft ();
	}

	public void AnyoneLeft ()
	{
		int p_aliveCount = 0;
		for (int i = 0; i < Players.Count; i++) {
			if (Players [i].gameObject.GetComponent<Leeroy> ().isPlayerAlive ()) {
				p_aliveCount++;
			}
		}
		if(p_aliveCount == 0){
			gameOver = true;
		}
	}

	public void BallOn(){
		ballCanFire = true;
	}

	public void BallOff(){
		ballCanFire = false;
	}

	public bool GetBallStatus(){
		return ballCanFire;
	}

	public List<GameObject> GetPlayers(){
		return Players;
	}

		
}
