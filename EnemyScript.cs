using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	private Animator myAnimator;
	private float movementSpeed;
	private bool facingRight;
	private Vector2 startPos;

	// Use this for initialization
	void Start () {
		facingRight = true;
		myAnimator = GetComponent<Animator> ();
		startPos = transform.Position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeDirection(){
		facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
	}
}
