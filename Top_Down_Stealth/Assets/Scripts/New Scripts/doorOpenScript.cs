using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class doorOpenScript : MonoBehaviour {

	private Animator door1_Anim;
	private Animator door2_Anim;
	private Animator door3_Anim;
	private Animator door4_Anim;
	private Animator finalDoor_Anim;
	private Animator gameEnder_Anim;
	public AudioClip doorAudio;
	public AudioClip finalDoorOpen;
	AudioSource audio;
	public keyScript keyScript;
	private AudioSource[] allAudioSources;


	// Use this for initialization
	void Start () 
	{
		door1_Anim = GameObject.Find ("Gate1").GetComponent<Animator> ();
		door2_Anim = GameObject.Find ("Gate2").GetComponent<Animator> ();
		door3_Anim = GameObject.Find ("Gate3").GetComponent<Animator> ();
		door4_Anim = GameObject.Find ("Gate4").GetComponent<Animator> ();
		finalDoor_Anim = GameObject.Find ("FinalGate").GetComponent<Animator> ();
		finalDoor_Anim = GameObject.Find ("FinalGate").GetComponent<Animator> ();
		gameEnder_Anim = GameObject.Find ("Main Camera").GetComponent<Animator> ();
		audio = GetComponent<AudioSource>();

	}
	void StopAllAudio() {
		allAudioSources = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];
		foreach (AudioSource audioS in allAudioSources) {
			audioS.Stop ();
		}
	}
	void OnTriggerEnter (Collider col)
	{
		Debug.Log (col.gameObject.tag);
		switch (col.gameObject.tag) {
		case "door1":
			Debug.Log ("is Player");
			if (keyScript.key1Collected == true) {
				door1_Anim.SetBool ("Open", true);
				audio.PlayOneShot (doorAudio, 1f);
				Debug.Log ("door opening");
				keyScript.key1Collected = false;
			}
			break;

		case "door2":
			if (keyScript.key2Collected == true) {
				door2_Anim.SetBool ("Open", true);
				audio.PlayOneShot (doorAudio, 1f);
				keyScript.key2Collected = false;
			}
			break;

		case "door3":
			if (keyScript.key3Collected == true) {
				door3_Anim.SetBool ("Open", true);
				audio.PlayOneShot (doorAudio, 1f);
				keyScript.key3Collected = false;
			}
			break;

		case "door4":
			if (keyScript.key4Collected == true) {
				door4_Anim.SetBool ("Open", true);
				audio.PlayOneShot (doorAudio, 1f);
				keyScript.key4Collected = false;
			}
			break;
		case "door5":
			if (keyScript.key5Collected == true) {
				StopAllAudio ();
				finalDoor_Anim.SetBool ("Open", true);
				audio.PlayOneShot (finalDoorOpen, 1f);
				gameEnder_Anim.enabled = true;
				gameEnder_Anim.SetBool ("gameEnd", true);
				Invoke ("gameEnd", 10f);
			}
			break;


		}

	}
	IEnumerator gameEndTrue ()
	{
		float fadeTime = GameObject.Find ("Fader").GetComponent<fadeScript> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene("WinScreen");
	}

	void gameEnd ()
	{
		StartCoroutine (gameEndTrue());
	}

}
