using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {


	public float moveSpeed;
	public bool moveRight;
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	public Transform edgeCheck;

	Rigidbody2D myRigitbody;
	bool hittindWall;
	bool notAtEdge;

	// Use this for initialization
	void Start () {
		myRigitbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		hittindWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);

		if (hittindWall||!notAtEdge) {
			moveRight = !moveRight;
		}

		if (moveRight) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			myRigitbody.velocity = new Vector2 (moveSpeed, myRigitbody.velocity.y);
		} else {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			myRigitbody.velocity = new Vector2 (-moveSpeed, myRigitbody.velocity.y);
		}

	}
}
