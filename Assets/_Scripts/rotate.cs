﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (new Vector3 (0, 90, 0) * Time.deltaTime / 2f);
		transform.Rotate (GameController.rotateVal);
	}
}
