using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBoundaryScript : MonoBehaviour {

	public static bool leftlaneoccupied;

	// Use this for initialization
	void Start () {
		leftlaneoccupied = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		leftlaneoccupied = true;
		//Debug.Log ("left lane true");
	}

	void OnTriggerExit(Collider other) {
		leftlaneoccupied = false;
		//Debug.Log ("left lane false");
	}
}
