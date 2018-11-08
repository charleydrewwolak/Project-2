using UnityEngine;
using System.Collections;

public class Acorn : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Bird>() != null && this.GetComponent<Renderer>().enabled == true)
        {
            //If the bird hits the trigger collider in between the columns then
            //tell the game control that the bird scored.
            Destroy(this.gameObject);
            GameControl.instance.BirdScored();
            //this.GetComponent<Renderer>().enabled = false;
            
            
        }
    }
}