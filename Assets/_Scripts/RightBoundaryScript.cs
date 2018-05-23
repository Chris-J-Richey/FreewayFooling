using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBoundaryScript : MonoBehaviour {

	public static bool rightlaneoccupied;

	// Use this for initialization
	void Start () {
		rightlaneoccupied = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		rightlaneoccupied = true;
		//Debug.Log ("right lane true");
	}

	void OnTriggerExit(Collider other) {
		rightlaneoccupied = false;
		//Debug.Log ("right lane false");
	}
}
