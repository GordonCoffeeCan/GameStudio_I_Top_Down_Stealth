﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			SceneManager.LoadScene ("gameScreen");	
		}
	}
}
