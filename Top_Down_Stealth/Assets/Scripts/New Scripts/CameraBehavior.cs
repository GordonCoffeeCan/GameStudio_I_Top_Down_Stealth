using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {
    private Transform _trans;
    private Transform _target;
    private float _camSpeed = 3;
    private float _camHeight;

    private float deltaStep;

	// Use this for initialization
	void Start () {
        _trans = this.transform;
        _target = GameObject.Find("CameraCenter").transform;
        _camHeight = _trans.position.y;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate() {
        deltaStep = _camSpeed;
        _trans.position = Vector3.MoveTowards(_trans.position, _target.position, deltaStep);
        _trans.position = new Vector3(_trans.position.x, _camHeight, _trans.position.z);
		if (Input.GetKey(KeyCode.Escape))
			Application.Quit();
    }

}
