using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMiddleBoundaryScript : MonoBehaviour {

	public static bool leftmiddlelaneoccupied;

	// Use this for initialization
	void Start () {
		leftmiddlelaneoccupied = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		leftmiddlelaneoccupied = true;
		//Debug.Log ("left middle lane true");
	}

	void OnTriggerExit(Collider other) {
		leftmiddlelaneoccupied = false;
		//Debug.Log ("left middle lane false");
	}
}
