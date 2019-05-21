using UnityEngine;
using System.Collections;

public class levelStarsDisplay : MonoBehaviour {

	// Use this for initialization
	public string levelname;
	public Texture[] starTexs;
	void Start () {

		levelname = transform.parent.name;
		int count = PlayerPrefs.GetInt (levelname, 0);
        GetComponent<Renderer>().material.mainTexture= starTexs[count];
			 
	
	}
	
 
}
