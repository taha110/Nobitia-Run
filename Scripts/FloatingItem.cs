using UnityEngine;
using System.Collections;

public class FloatingItem : MonoBehaviour
{
	public Vector3 velocity;
	public Vector3 RestartRange;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += velocity;

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Restarter") {
			transform.position = transform.position + RestartRange;

		}
	}
}
