using UnityEngine;
using System.Collections;


public class LevelOver : MonoBehaviour {

	public string lvlToLoad;

	bool playerInZone;

	// Use this for initialization
	void Start () {
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W)&&playerInZone) {
			Application.LoadLevel(lvlToLoad);


		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "player") {
			playerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.name == "player") {
			playerInZone = false;
		}
	}
}
