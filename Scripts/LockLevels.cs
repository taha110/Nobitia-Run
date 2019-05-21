using UnityEngine;
using System.Collections;

public class LockLevels : MonoBehaviour {

	// Use this for initialization
	public string levelName;

	void Start () {

		if (PlayerPrefs.GetInt (levelName, 0) != 0) {
			Destroy(gameObject);
				}
			
	}


}
