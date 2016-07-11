using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject deathParticle;
	public GameObject respawnParticle;
	public GameObject currentCheckpoint;
	public int pointPenaltyOnDeath;
	public float respawnDelay;
	public HealthManager healthManager;


	PlayerController player;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		healthManager = FindObjectOfType<HealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer(){

		StartCoroutine("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){

		Debug.Log ("Player Respawn");
		Instantiate (deathParticle,player.transform.position,player.transform.rotation);
		player.enabled = false;
		player.gameObject.SetActive (false);
		player.knockbackCount = 0;
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
	
		yield return new WaitForSeconds (respawnDelay);
		player.transform.position = currentCheckpoint.transform.position;
		Instantiate (respawnParticle,currentCheckpoint.transform.position,currentCheckpoint.transform.rotation);
		player.enabled = true;
		player.gameObject.SetActive (true);
		healthManager.FullHealth ();
		healthManager.isDead = false;
	}
}
