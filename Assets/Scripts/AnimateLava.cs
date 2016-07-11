using UnityEngine;
using System.Collections;

public class AnimateLava : MonoBehaviour {
	float translation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
		if (transform.position.x < -13f) {
			
		
			translation = Time.deltaTime * 0.6f;
			transform.Translate (translation, 0, 0);

		} else {
			translation = -0.99f;
			transform.Translate (translation, 0, 0);
		}
			

	}
}
