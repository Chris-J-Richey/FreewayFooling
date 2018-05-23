using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMiddleBoundaryScript : MonoBehaviour {

	public static bool rightmiddlelaneoccupied;

	// Use this for initialization
	void Start () {
		rightmiddlelaneoccupied = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		rightmiddlelaneoccupied = true;
		//Debug.Log ("right middle lane true");

	}

	void OnTriggerExit(Collider other) {
		rightmiddlelaneoccupied = false;
		//Debug.Log ("middle middle lane false");

	}
}
