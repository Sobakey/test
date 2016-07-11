using UnityEngine;
using System.Collections;


public class CameraFollow : MonoBehaviour {
	public CircleCollider2D collider;   
	public Vector2 focusAreaSize;
	FocusArea focusArea;
	public float verticalOffset;



	void Start(){
		if(FindObjectOfType<CircleCollider2D> ().name == "player") collider = FindObjectOfType<CircleCollider2D> (); 
		focusArea = new FocusArea (collider.bounds, focusAreaSize);
		Bounds bounds = collider.bounds;

	}
		


	void LateUpdate(){
		focusArea.Update (collider.bounds);
		Vector2 focusPosition = focusArea.centr + Vector2.up * verticalOffset;
		transform.position = (Vector3)focusPosition + Vector3.forward * -10;
	}

	void OnDrawGizmos(){
		Gizmos.color = new Color (1,0,0,.5f);
		Gizmos.DrawCube (focusArea.centr, focusAreaSize);

	}

	public struct FocusArea{
		public Vector2 centr;
		public Vector2 velocity;
		float left,right;
		float top,bottom;

		public FocusArea(Bounds targetBounds, Vector2 size){

			left = targetBounds.center.x - size.x/2;
			right = targetBounds.center.x + size.x/2;
			bottom = targetBounds.min.y;
			top = targetBounds.min.y+size.y;

			centr = new Vector2((left+right)/2,(top+bottom)/2);
			velocity = Vector2.zero;
		}
	
	

	public void Update(Bounds targetBounds){
		float shiftX = 0;
			if (targetBounds.min.x < left) {
				shiftX = targetBounds.min.x - left;
			} else if (targetBounds.max.x > right) {
				shiftX = targetBounds.max.x - right;
			}
			left += shiftX;
			right += shiftX;

			float shiftY = 0;
			if (targetBounds.min.y < bottom&&targetBounds.min.y>=-2.5f) {
				shiftY = targetBounds.min.y - bottom;
			} else if (targetBounds.max.y > top) {
				shiftY = targetBounds.max.y - top;
			}
			top += shiftY;
			bottom += shiftY;
			centr = new Vector2((left+right)/2,(top+bottom)/2);
			velocity = new Vector2 (shiftX,shiftY);
		}
	}



}
