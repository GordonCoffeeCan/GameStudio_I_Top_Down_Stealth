using UnityEngine;
using System.Collections;

public class CrossfadeManager : MonoBehaviour
{
	public AudioClip[] tracks;

	public float fadeTime = 1.0f;

	private int currentTrack = 0;

	// Use this for initialization
	void Start ()
	{

	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.T)) {


			currentTrack = 0;

			CrossfadeScript.Crossfade(tracks[currentTrack], fadeTime);
		}
		if (Input.GetKeyDown (KeyCode.Y)) {


			currentTrack = 1;

			CrossfadeScript.Crossfade(tracks[currentTrack], fadeTime);
		}
	}
	// Update is called once per frame
	void OnTriggerEnter (Collider col)
	{

		if (col.tag == "Spawner") {
			currentTrack = 2;
			CrossfadeScript.Crossfade(tracks[currentTrack], fadeTime);
		}
		if (col.tag == "sanctuary") {
			currentTrack = 0;
			CrossfadeScript.Crossfade(tracks[currentTrack], fadeTime);
		}

		//		switch (col.gameObject.tag) {
		//		case "Spawner":
		//			Debug.Log (currentTrack);
		//			currentTrack = 2;
		//			CrossfadeScript.Crossfade(tracks[currentTrack], fadeTime);
		//			break;
		//		case "sanctuary":
		//			Debug.Log (currentTrack);
		//			currentTrack = 0;
		//			CrossfadeScript.Crossfade(tracks[currentTrack], fadeTime);
		//			break;
		//
		//		default:
		//			Debug.Log (currentTrack);
		//			currentTrack = 1;
		//			CrossfadeScript.Crossfade(tracks[currentTrack], fadeTime);
		//			break;
		//		}
	}

	void OnTriggerExit (Collider col){
		if (col.tag == "sanctuary" || col.tag == "Spawner") {
			currentTrack = 1;
			CrossfadeScript.Crossfade(tracks[currentTrack], fadeTime);
		}
	}

}