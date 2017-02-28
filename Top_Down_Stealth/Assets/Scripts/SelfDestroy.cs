using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {
    //Attach this script to particle

    public float someTime; //This is duration of particle life span. after this amount of time, 

	// Use this for initialization
	void Start () {
        Invoke("DestroyGameObject", someTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void DestroyGameObject() {
        Destroy(this.gameObject);
    }
}
