using UnityEngine;
using System.Collections;


public class HurtPlaerOnContact : MonoBehaviour {

	public int damageToGive;




	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.name == "player") {
			
			HealthManager.HurtPlayer (damageToGive); 
			other.GetComponent<AudioSource>().Play();

			var player = other.GetComponent<PlayerController> ();
			player.knockbackCount = player.knockbackLong;
			if (other.transform.position.x < transform.position.x) {
				player.knockFromRight = true;
			} else
				player.knockFromRight = false;
		}
	}
}
