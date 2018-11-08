using UnityEngine;
using System.Collections;

public class AcornPool : MonoBehaviour 
{
    public GameObject acorn;                                 //The acorn game object.
    public float spawnRate = 3f;                                    //How quickly acorns spawn.
    public float acornMin = -1f;                                   //Minimum y value of the acorn position.
    public float acornMax = 3.5f;                                  //Maximum y value of the acorn position.
    private float spawnXPosition = 25f;
    private float timeSinceLastSpawned;
    

    void Start()
    {
        timeSinceLastSpawned = 0f;
    }


    //This spawns acorns as long as the game is not over.
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
        {   
            timeSinceLastSpawned = 0f;

            //Set a random y position for the acorn
            float spawnYPosition = Random.Range(acornMin, acornMax);

            //...then set the current acorn to that position.
            Instantiate(acorn, new Vector2(spawnXPosition, spawnYPosition), Quaternion.identity);

        }
    }
}