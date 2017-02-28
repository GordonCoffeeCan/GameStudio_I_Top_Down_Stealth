using UnityEngine;
using System.Collections;

public class EyeDetectionScript : MonoBehaviour {
	public float growTime = 1f;
	// Use this for initialization
	void Start () {
		//y transform starts at 0
	}
	
	// Update is called once per frame
	void Update () {

		//set growTime to time.deltaTime
		//if circle of view has playerInRange == true, then increase y transform by 
		//growTime with a clamp at 1.
		//else, decrease y transform by growTime.
		//if y transform >= 1
		//enemySpawning = true
		//else enemySpawning = false
	
	}
}
