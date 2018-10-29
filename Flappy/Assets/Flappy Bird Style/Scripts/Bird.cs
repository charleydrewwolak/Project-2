using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
    public float upForce;                   //Upward force of the "flap".
    private bool isDead = false;            //Has the player collided with a wall?

    private Animator anim;                  //Reference to the Animator component.
    private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.

    void Start()
    {
        //Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator> ();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (isDead == false) 
        {
            //Look for input to trigger a "flap".
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                jump();
            }
            if (Input.GetKey(KeyCode.Space) && rb2d.velocity.y < 0)
            {
                rb2d.velocity = Vector2.zero;
                //rb2d.velocity.y = -.5;
                rb2d.gravityScale = .9f;
            } else { 
                rb2d.gravityScale = 1;
            }
        }
    }

    void jump() {
        anim.SetTrigger("Flap");
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(new Vector2(0, upForce));
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Zero out the bird's velocity
        rb2d.velocity = Vector2.zero;
        // If the bird collides with something set it to dead...
        isDead = true;
        //...tell the Animator about it...
        anim.SetTrigger ("Die");
        //...and tell the game control about it.
        GameControl.instance.BirdDied ();
    }
}