using UnityEngine;
using System.Collections;

public class levelIndicator : MonoBehaviour {

	// Use this for initialization
	public TextMesh levelIndicatorTxt;
	void Start () {
		levelIndicatorTxt.text = Application.loadedLevelName;
	
	}
}
