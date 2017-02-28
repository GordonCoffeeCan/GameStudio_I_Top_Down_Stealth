using UnityEngine;
using System.Collections;

public class LightBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Lighten up the spawner to let it stop chasing the player;
    private void OnTriggerEnter(Collider _tagret) {
        if (_tagret.tag == "Spawner") {
            GameData.playerSeeSpawner = true;
            Debug.Log("Spawner is seen!");
        }
    }

    //If spawner is not lightened, it will keep chasing or go back to its original position;
    private void OnTriggerExit(Collider _tagret) {
        if (_tagret.tag == "Spawner") {
            GameData.playerSeeSpawner = false;
            Debug.Log("Spawner is not seen!");
        }
    }
}
