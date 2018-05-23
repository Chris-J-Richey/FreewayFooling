using UnityEngine;
using System.Collections;

public class Mover3 : MonoBehaviour {

	public float speed;

	void Start ()
	{
		//GetComponent<Rigidbody> ().velocity = transform.forward * speed;
		GetComponent<Rigidbody> ().velocity = transform.forward * GameController.movespeed;
	}
}
