using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightScreenScript : MonoBehaviour {

	public static bool rightscreenclick = false;

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
				if (hit.transform.name == "RightScreen") 
				{
					//Debug.Log ("RightScreen is clicked by mouse");
					rightscreenclick = true;
				}
				else
				{
					rightscreenclick = false;
					//Debug.Log ("RightScreen is false");
				}
			}
		}
	}
}
