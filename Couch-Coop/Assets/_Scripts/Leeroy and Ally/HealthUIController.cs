using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour {

	public GameObject HeartWigit; 
	public Transform HeartLayout;
	public Text playerName;
	private string p_name;
	private int n_health;
	private List<GameObject> hearts = new List<GameObject>();

	public void SetUIHealthBar(string name, int health){
		p_name = name;
		n_health = health;
		playerName.text = p_name;
		for (int i = 0; i < n_health; i++) {
			hearts.Add(GameObject.Instantiate (HeartWigit, HeartLayout.transform)) ;
		}
	}

	public void RemoveHeart(){
		n_health -= 1;
		//hearts.Remove (n_health);
	}
}
