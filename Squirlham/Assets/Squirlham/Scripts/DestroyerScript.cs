﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyerScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
			if (other.gameObject){
				Destroy(other.gameObject);
			}
	}
}
