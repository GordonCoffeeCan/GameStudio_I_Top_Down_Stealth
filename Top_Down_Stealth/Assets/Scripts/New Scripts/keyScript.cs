using UnityEngine;
using System.Collections;

public class keyScript : MonoBehaviour {
	public AudioClip keyAudio;
	AudioSource audio;
	public bool key1Collected = false;
	public bool key2Collected = false;
	public bool key3Collected = false;
	public bool key4Collected = false;
	public bool key5Collected = false;
	public GameObject Icon3;
	public GameObject Icon4;
	public GameObject Icon1;
	public GameObject Icon2;
	public GameObject FinalIcon_Left;
	public GameObject FinalIcon_Right;


	void Start ()
	{
		audio = GetComponent<AudioSource>();
//		Icon3 = GameObject.Find ("Icon3");
//		Icon4 = GameObject.Find ("Icon4");
//		Icon1 = GameObject.Find ("Icon1");
//		Icon2 = GameObject.Find ("Icon2");
//		FinalIcon_Left = GameObject.Find ("FinalIcon_Left");
//		FinalIcon_Right = GameObject.Find ("FinalIcon_Right");
	}

	void OnTriggerEnter (Collider col)
	{
		switch (col.gameObject.tag)
		{
		case "key1":
			
			audio.PlayOneShot (keyAudio, 1f);
			key1Collected = true;
			Debug.Log ("key touched");
			Destroy (col.gameObject);
			Icon3.gameObject.SetActive (true);
			break;

		case "key2":

			audio.PlayOneShot(keyAudio, 1f);
				key2Collected = true;
			Destroy (col.gameObject);
			Icon4.gameObject.SetActive (true);
			break;

		case "key3":

			audio.PlayOneShot(keyAudio, 1f);
				key3Collected = true;
			Destroy (col.gameObject);
			Icon2.gameObject.SetActive (true);
			break;

		case "key4":
			
			audio.PlayOneShot(keyAudio, 1f);
				key4Collected = true;
			Destroy (col.gameObject);
			Icon1.gameObject.SetActive (true);
			break;

		case "key5":
			
			audio.PlayOneShot(keyAudio, 1f);
				key5Collected = true;
			Destroy (col.gameObject);
			FinalIcon_Left.gameObject.SetActive (true);
			FinalIcon_Right.gameObject.SetActive (true);
			break;


		}
	}
}
