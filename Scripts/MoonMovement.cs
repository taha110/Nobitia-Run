using UnityEngine;
using System.Collections;

public class MoonMovement : MonoBehaviour
{
	
	public Vector3 velocity;
	public Vector3 restarter;
	public Vector3 limit;
	
	Transform position;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (transform.position.x >= limit.x) {
			transform.position = new Vector3 (restarter.x, transform.position.y, transform.position.z);
		}
		
		transform.position += velocity;
	}
}
