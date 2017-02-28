using UnityEngine;
using System.Collections;

public class TriggerBehavior : MonoBehaviour {
    public SpawnerBehavior spawner; //Attach "SpawnerBehavior" script in the inspector, so we can change variable and call method in this script;

    private int minionNumber;
    private string _objectName; //distinguish trigger's name (For example: "DetectingTrigger") with this variable;

	public AudioClip spawnerChase;
	public AudioClip spawnerWalk;
	public AudioClip monsterSpawn;
	AudioSource audio;

	// Use this for initialization
	void Start () {
        _objectName = this.gameObject.name; //Get trigger's name;

		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    //When player enter a trigger, something decided by Trigger's name will happen;
    private void OnTriggerEnter(Collider _target) {
        //If player entered "DetectingTrigger", the spawner will wake up and chasing the player;
        if (_objectName == "DetectingTrigger" && _target.tag == "Player" && _target.GetComponent<PlayerControl>().isSneak == false) {
            spawner.setAnimState(true); //Set setAnimState method in "SpawnerBehavior" script;
            spawner.playerIsLost = false; //Set player is not lost;
            spawner.player = _target.transform; //Set spawner's destination is player; When player enters trigger, "_target" is player.

            GameData.spawnerSeePlayer = true;
            if (GameData.playerSeeSpawner == false) {
                GameData.canSpawnerChasePlayer = true;
            }
				

			audio.Stop ();
			audio.PlayOneShot (spawnerChase, 1f);

        } else if (_objectName == "SpawningTrigger" && _target.tag == "Player") { //If player entered "SpawningTrigger", the spawner will destory and minions (small enemies) will spawn on spawner's position;
            spawner.setAnimState(true, true); //Set setAnimState method in "SpawnerBehavior" script;

            //Enter spawn minions code here;
            Invoke("SpawnMinions", 0.3f);

			if (spawner.playerIsLost = true) {
				audio.PlayOneShot (spawnerWalk, 1f);
			}
        }
    }
    
    //When player leves a trigger, spawner will lost the player if longer than some time;
    private void OnTriggerExit(Collider _target) {
        if (_objectName == "DetectingTrigger" && _target.tag == "Player") {
            spawner.setAnimState(false, false); //Set setAnimState method in "SpawnerBehavior" script;
            spawner.backToPath(); //Set spawner's timer for how long time it is going to lost the player;

            GameData.spawnerSeePlayer = false;
            Debug.Log("Player is not seen!");
        }
    }

    private void SpawnMinions() {
        Debug.Log("Minions are spawned!");
        GameData.playerSeeSpawner = false;
        minionNumber = Random.Range(3, 8);

		audio.Stop ();
		audio.PlayOneShot (monsterSpawn, 1f);

        for (int i = 0; i < minionNumber; i++) {
            Transform _minion = Instantiate(spawner.minion, spawner.transform.position, Quaternion.identity) as Transform;
            Destroy(spawner.gameObject);
        }
    }
}
