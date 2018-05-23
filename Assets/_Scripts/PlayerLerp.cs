using UnityEngine;
using System.Collections;

public class PlayerLerp : MonoBehaviour {

	//The object you want to move
	public GameObject playercar;

	//current position and new position
	private Vector3 currentPos, newPos;

	//Distance to move
	private float distance = 2.75f;

	//time to take for moving between positions
	private float lerpTime = 0.1f;

	//this will update the lerp time
	private float currentLerpTime = 0;

	//boolean set to true if object is lerping
	private bool isMoving = false;

	//perc set to 1 if lerping complete
	private float Perc = 0;


	void Start ()
	{
		//initalize car to start in the middle lane
		playercar.transform.position = new Vector3 (0f, 0f, -2.89f);
		currentPos = playercar.transform.position;
		newPos = playercar.transform.position;
		Perc = 0;
		currentLerpTime = 0;
		isMoving = false;
		RightScreenScript.rightscreenclick = false;
		LeftScreenScript.leftscreenclick = false;

	}

	void Update ()		
	{

		//Debug.Log ("cp:" + currentPos);
		//Debug.Log ("right:" + RightScreenScript.rightscreenclick);
		//Debug.Log ("left:" + LeftScreenScript.leftscreenclick);
		//Debug.Log("moving:" + isMoving);
		//Debug.Log("perc:" + Perc);
		//Debug.Log ("newPos:" + newPos);

		//if lerping complete
		if (Perc == 1) 
		{
			RightScreenScript.rightscreenclick = false;
			LeftScreenScript.leftscreenclick = false;

			currentLerpTime = 0;
			isMoving = false;

			currentPos = playercar.transform.position;

			Perc = 0;

		}

		//if still lerping
		if (isMoving == true) {

			currentLerpTime += Time.deltaTime;
			if (currentLerpTime >= lerpTime) {
				currentLerpTime = lerpTime;
			}

			Perc = currentLerpTime / lerpTime;

			playercar.transform.position = Vector3.Lerp (currentPos, newPos, Perc);
		}

		//if not lerping and not on either the far right or left lanes
		if (RightScreenScript.rightscreenclick == true && playercar.transform.position.x < 5f && isMoving == false) {
			newPos = playercar.transform.position + Vector3.right * distance;
			isMoving = true;
		} 
		else if (LeftScreenScript.leftscreenclick == true && playercar.transform.position.x > -5f && isMoving == false) {
			newPos = playercar.transform.position + Vector3.left * distance;
			isMoving = true;
		} 
	}
}
