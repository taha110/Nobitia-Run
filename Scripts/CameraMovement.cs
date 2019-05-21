using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

	public Vector3 velocity;
	public static bool boolPause ;




	// Use this for initialization
	void Start ()
	{
		
		boolPause = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

		transform.position += velocity;


		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}


	}

	void LateUpdate ()
	{

	}
}
