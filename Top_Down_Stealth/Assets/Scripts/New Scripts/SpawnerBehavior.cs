using UnityEngine;
using System.Collections;

public class SpawnerBehavior : MonoBehaviour {
	public float idleSpeed = 5; //Spawner's idle speed when it is waling on its own path;
	public bool ReversePath = false; //Reverse path if needed;
    public string SpawnerPath = null; //Spawner's path. Set it with the name of "SpawnerPath1". We have 8 path in the scene;
    public Transform minion;

    //"[HideInInspector]" means you can hide this public variable from inspector;
    [HideInInspector]public Transform player; //Player transform. This is used for set spawner's destination when player is detected;
    [HideInInspector]public bool playerIsLost = false; //Is player lost when spawner chasing the player;

	private Transform _trans; //Spawner's transform;
    private Animator _anim; //Spawner's Animator;
    private UnityEngine.AI.NavMeshAgent _navAgent; //Spawner's Navigation Agent; this is the component for Spawner chasing the player; I've already baked Nav Mesh in the scene;

    private float backPathTimer = 0; //Timer for how long time the spawner will lost the player;
    private Vector3 originalPathPosition; //Original path start position for this spawner;
    private bool isTweenStopped = false;

	// Use this for initialization
	void Start () {
        _trans = this.transform; //Get spawner's transform;
        _anim = _trans.FindChild("SpawnerShape").GetComponent<Animator>(); //Get spawner's animator so that code can control its animation;
        _navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); //Get spawner NavigationMeshAgent;

        //Start ------ Check if there is set path for this spawner while it is in idle state;
		if (SpawnerPath != null) {
			moveOnPath ();
        }
        //End ------ Check if there is set path for this spawner while it is in idle state;
	}
	
	// Update is called once per frame
	void Update () {

        //Start ------ Timer counting down. If timer lest than 0, the spawner will lost the player;
        if (backPathTimer > 0) {
            backPathTimer -= Time.deltaTime;
            if (backPathTimer < 0.2) {
                GameData.canSpawnerChasePlayer = false;
                playerIsLost = true;
            }
        }
        //End ------ Timer counting down. If timer lest than 0, the spawner will lost the player;
	}

    void FixedUpdate() {
        //Start ------ Set the spawner to chase the player;
		if (GameData.canSpawnerChasePlayer == true) {
			
			if (player != null) {
				_navAgent.SetDestination (player.position);
				_navAgent.Resume ();
				if (isTweenStopped == false) {
					isTweenStopped = true;
					stopTween ();
				}
			} else {
				return;
			}
		} else if (GameData.pauseTween == true) {
			if (player != null) {
				_navAgent.SetDestination (player.position);
				_navAgent.Stop ();
				if (isTweenStopped == false) {
					isTweenStopped = true;
					stopTween ();
				}
			} else {
				return;
			}
		}
				
		else if (GameData.pauseTween == false) {
				_navAgent.Stop();
				iTween.Resume(_trans.gameObject);
				isTweenStopped = false;
			}
		 else {
			_navAgent.Stop();
		}
		
        if (playerIsLost == true) {
            player = null;
            if (Vector3.Distance(_trans.position, originalPathPosition) > 0.1f) {
                _navAgent.Resume();
                _navAgent.SetDestination(originalPathPosition);
            } else {
                _navAgent.Stop();
                iTween.Resume(_trans.gameObject);
                isTweenStopped = false;
            }
        }
  
    }


    //This method is using for set spawner's animation state; This method is called in "TriggerBehavior" script;
    public void setAnimState(bool isWake = false, bool isStunned = false) {
        _anim.SetBool("wakedUp", isWake);
        _anim.SetBool("stunned", isStunned);
    }

    //In idle state spawner is walking on its own path;
	private void moveOnPath(){
		iTween.MoveTo (_trans.gameObject, iTween.Hash ("path", iTweenPath.GetPath (SpawnerPath),"orienttopath", true, "speed", idleSpeed, "easetype", iTween.EaseType.linear, "oncomplete", "moveBackOnPath"));
	}

    //Reverse the path if this spawner is walking back and forth;
	private void moveBackOnPath(){
        if (ReversePath == true) {
			iTween.MoveTo (_trans.gameObject, iTween.Hash ("path", iTweenPath.GetPathReversed (SpawnerPath), "orienttopath", true, "speed", idleSpeed, "easetype", iTween.EaseType.linear, "oncomplete", "moveOnPath"));
		} else {
			moveOnPath ();
		}
	}

    //Stop this spawner's idle state if it detects the player;
    private void stopTween() {
        iTween.Pause(_trans.gameObject);
        originalPathPosition = _trans.position;
    }

    //This method is called in "TriggerBehavior" script. It will set the timer that how long time this spawner will lost the player;
    public void backToPath() {
        backPathTimer = 7;
    }
}

