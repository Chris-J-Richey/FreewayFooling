using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	void Start ()
	{
		//GetComponent<Rigidbody> ().velocity = transform.right * speed;
		GetComponent<Rigidbody> ().velocity = transform.right * GameController.movespeed;
	}
}
