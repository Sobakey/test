using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed = 5f;
	public float jumpHeight = 10f;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public Transform firePoint;
	public GameObject bulletCoin;
	public float shotDelay;

	public float knockback;
	public float knockbackCount;
	public float knockbackLong;
	public bool knockFromRight;


	Rigidbody2D myRigitbody;
	bool grounded;
	bool doubleJumped;
	Animator anim;
	float moveVelocity;
	float shotDelayCounter;

	// Use this for initialization
	void Start () {
		myRigitbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}

	void FixedUpdate(){
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

	}

	void Jump (){
		myRigitbody.velocity = new Vector2 (myRigitbody.velocity.x,jumpHeight);
	}

	// Update is called once per frame
	void Update () {
		if (grounded) {
			doubleJumped = false;

		}

		if (Input.GetKeyDown(KeyCode.Space) && grounded) {
			Jump ();
		}

		if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded) {
			Jump ();
			doubleJumped = true;

		}

		moveVelocity = 0f;


		if (Input.GetKey(KeyCode.D)) {
			
			moveVelocity = moveSpeed;
		}

		if (Input.GetKey(KeyCode.A)) {
			
			moveVelocity = -moveSpeed;
		}

		if (knockbackCount <= 0) {
			myRigitbody.velocity = new Vector2 (moveVelocity, myRigitbody.velocity.y);
		} else {
			if (knockFromRight) {
				myRigitbody.velocity = new Vector2 (-knockback, knockback);
			}
			if (!knockFromRight) {
				myRigitbody.velocity = new Vector2 (knockback,knockback);
			}
			knockbackCount -= Time.deltaTime;
		}


		anim.SetFloat ("Speed", Mathf.Abs(myRigitbody.velocity.x));
		anim.SetBool ("Grounded", grounded);

	

		if (myRigitbody.velocity.x > 0) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if (myRigitbody.velocity.x < 0)
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		
		if(Input.GetKeyDown(KeyCode.Mouse1)){
			//shotDelayCounter = -1;
			//for (int i = 0; i < shotDelay; i++) {
			//	shotDelayCounter -= Time.deltaTime;
		//	}

			//Debug.Log (shotDelayCounter);
			if (ScoreManager.score>0) {
				if (shotDelayCounter >= 0) {
					shotDelayCounter = shotDelay;
					Instantiate (bulletCoin, firePoint.position, firePoint.rotation);
					ScoreManager.AddPoints (-1);
				}
			}

		}
		if (anim.GetBool("Sword")) {
			anim.SetBool ("Sword",false);
		}

		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			anim.SetBool ("Sword",true);
		}

		if (Input.GetKey(KeyCode.Mouse1)) {
			shotDelayCounter -= Time.deltaTime;
			if (ScoreManager.score>0) {
				if (shotDelayCounter <= 0) {
					shotDelayCounter = shotDelay;
					Instantiate (bulletCoin, firePoint.position, firePoint.rotation);
					ScoreManager.AddPoints (-1);
				}
			}
		}
	}


}
