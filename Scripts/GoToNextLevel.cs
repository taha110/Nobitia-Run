using UnityEngine;
using System.Collections;

public class GoToNextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	/*void OnTriggerStay(Collider other) {

		Debug.Log( "collide (name) : " + other.name );
		Debug.Log( "collide (tag) : " + other.tag );
	}*/

	void OnTriggerEnter2D(Collider2D other) {
		//Application.LoadLevel("AOGTprototype");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
