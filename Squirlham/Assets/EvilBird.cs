using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBird : MonoBehaviour {
	public float upForce;
	private Rigidbody2D rb2d;  
	private float startY;
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		startY = rb2d.transform.position.y;
		print(startY);
	}

	void Update () {
		if (rb2d.transform.position.y <= startY && rb2d != null){
			rb2d.velocity = (new Vector2(rb2d.velocity.x, 0));
        	rb2d.AddForce(new Vector2(0, upForce));
		}
	}
}
