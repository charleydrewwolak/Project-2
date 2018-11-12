using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
    public GameObject input;                                 //The acorn game object.
    public float spawnRate;                                    //How quickly acorns spawn.
    public float yMin;                                   //Minimum y value of the acorn position.
    public float yMax;                                  //Maximum y value of the acorn position.
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
            float spawnYPosition = Random.Range(yMin, yMax);

            //...then set the current acorn to that position.
            Instantiate(input, new Vector2(spawnXPosition, spawnYPosition), Quaternion.identity);

        }
    }
}