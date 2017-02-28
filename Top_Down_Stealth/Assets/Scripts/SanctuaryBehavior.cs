using UnityEngine;
using System.Collections;

public class SanctuaryBehavior : MonoBehaviour {

    //Attach this script to SafeZoneTrigger in hierarchy.

	public Transform destroyParticle; //Assign this with particle

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider _col) {
        if (_col.tag == "Spawner" || _col.tag == "Minion") {
            if(destroyParticle != null){
                Instantiate(destroyParticle, _col.transform.position, Quaternion.identity); //Generate Particle Here;
            }

            Debug.Log("Destroyed!");
            Destroy(_col.gameObject);
        }
    }
}
