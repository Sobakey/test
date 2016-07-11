using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;
	public PlayerController player;
	public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	public int damageToGive;
	public float rotationSpeed;
	//public float shutingDistance;

	Rigidbody2D myRigitbody;

	// Use this for initialization
	void Start () {
		myRigitbody = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<PlayerController> ();

		if (player.transform.localScale.x <0) {

			rotationSpeed = -rotationSpeed;
			speed = -speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		myRigitbody.velocity = new Vector2 (speed, myRigitbody.velocity.y);
		myRigitbody.angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {

			other.GetComponent<EnemyHealthManager> ().GiveDamage (damageToGive);
		}

		Instantiate (impactEffect, transform.position, transform.rotation);

		Destroy (gameObject);





	}
}
