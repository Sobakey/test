using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour {


	public int damageToGive;
	public float bounceOnEnemy;

	Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
		myRigidbody = transform.parent.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealthManager> ().GiveDamage (damageToGive);
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, bounceOnEnemy);
		}
	}
}
