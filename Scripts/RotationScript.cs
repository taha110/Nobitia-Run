using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour
{
	public float rotationSpeed = 1.5f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*float tiltAroundZ = CFInput.GetAxis ("Horizontal") * tiltAngle;
		float tiltAroundX = CFInput.GetAxis ("Vertical") * tiltAngle;
		Quaternion target = Quaternion.Euler (tiltAroundX, 0, tiltAroundZ);
		transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * smooth);*/

		transform.Rotate (0, 0, rotationSpeed * Time.deltaTime);

	}
}
