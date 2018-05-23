using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBoundaryScript : MonoBehaviour {

	public static bool middlelaneoccupied;

	// Use this for initialization
	void Start () {
		middlelaneoccupied = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		middlelaneoccupied = true;
		//Debug.Log ("middle lane true");
	}

	void OnTriggerExit(Collider other) {
		middlelaneoccupied = false;
		//Debug.Log ("middle lane false");
	}
}
