using UnityEngine;
using System.Collections;

public class MinionBehavior : MonoBehaviour {
    private UnityEngine.AI.NavMeshAgent _navAgent;
    private Transform target;

	public int damage = 1;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player").transform;
        _navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate() {
        _navAgent.SetDestination(target.position);
    }

	void OnTriggerEnter(Collider _player)
	{
		if (_player.tag == "Player")
		{
			Debug.Log("player hit");
			_player.GetComponent<PlayerControl>().health -= 1;
		}
	}
}
