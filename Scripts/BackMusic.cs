
using UnityEngine;
using System.Collections;

public class BackMusic : MonoBehaviour
{
	
	public AudioClip myClip;
	//AudioSource mySound;
	
	// Use this for initialization
	void Start ()
	{
		//mySound.loop = true;
		//mySound.clip = myClip;
		//mySound.Play ();
		AudioSource.PlayClipAtPoint (myClip, new Vector3 (0, 0, 0));
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
