using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject platformPrefab;
    //public GameObject acorn;

    public int numberOfPlatforms;
    //public int numberOfAcorns;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    
	// Use this for initialization
	void Start () {

        Vector3 spawnPosition = new Vector3();
        Vector3 acornPosition = new Vector3();


        for (int i = 0; i< numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(levelWidth, -levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            /*acornPosition.y = spawnPosition.y + 0.4f;
            acornPosition.x = spawnPosition.x;
            Instantiate(acorn, acornPosition, Quaternion.identity);
            */
        }
	}
	
	
}
