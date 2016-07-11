using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth,pointsOnDeath;
	public GameObject deathEffect;
	public AudioSource aud;

	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth<=0) {
			Instantiate (deathEffect, transform.position, transform.rotation);
			ScoreManager.AddPoints (pointsOnDeath);
			Destroy (gameObject);
		}
	}

	public void GiveDamage(int damageToGive){

		enemyHealth -= damageToGive;
		aud.Play ();
	}


}
