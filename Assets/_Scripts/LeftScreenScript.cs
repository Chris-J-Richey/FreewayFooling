using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftScreenScript : MonoBehaviour {

	public static bool leftscreenclick = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//var hit : RaycastHit;
			//var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.name == "LeftScreen")
					//Debug.Log ("LeftScreen is clicked by mouse");
					leftscreenclick = true;
				else
					leftscreenclick = false;
			}
		}
	}
}
