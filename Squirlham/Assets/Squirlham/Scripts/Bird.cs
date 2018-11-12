using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
    public float gravity;
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
        rb2d.gravityScale = gravity;

    }

    void Update()
    {
        if (anim.GetBool("glide")==false) 
        {
            //Look for input to trigger a "flap".
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                jump();
                anim.SetBool("glide", true);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (rb2d.velocity.y < 0)
                {
                    rb2d.velocity = Vector2.zero;
                }
            } 
            else 
            {
                anim.SetBool("glide", false);
            }
        }
    }

    void jump() {
        anim.SetTrigger("Flap");
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(new Vector2(0, upForce));
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Zero out the bird's velocity
        if (other.GetComponent<Acorn>() == null)
        {
            rb2d.velocity = Vector2.zero;
            // If the bird collides with something set it to dead...
            isDead = true;
            //...tell the Animator about it...
            anim.SetTrigger ("Die");
            //...and tell the game control about it.
            GameControl.instance.BirdDied ();
        }
    }
}