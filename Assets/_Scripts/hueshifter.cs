using UnityEngine;
using System.Collections;

public class hueshifter : MonoBehaviour {

	public float Speed = 1;
	private Renderer rend;

	void Start()
	{
		rend = GetComponent<Renderer>();
		rend.material.SetColor("_Color", HSBColor.ToColor(new HSBColor( Mathf.PingPong(Time.time * Speed, 1), 1, 1)));

	}

	void Update()
	{
		//rend.material.SetColor("_Color", HSBColor.ToColor(new HSBColor( Mathf.PingPong(Time.time * Speed, 1), 1, 1)));
	}
}