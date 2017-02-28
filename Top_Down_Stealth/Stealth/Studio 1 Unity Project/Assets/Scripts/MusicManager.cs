﻿using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip mainTheme;
	public AudioClip menuTheme;

	void Start () {
		AudioManager.instance.PlayMusic(menuTheme,2);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			AudioManager.instance.PlayMusic(mainTheme,3);
		}
	
	}
}
