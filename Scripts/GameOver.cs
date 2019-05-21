using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{



	public string selectedTxt;
	public Camera GOCam;

	// Use this for initialization
	void Start ()
	{
	
	}

	RaycastHit hitObject;
	Ray rayObjLevels;


	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			selectedTxt = "";
			rayObjLevels = GOCam.ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast (rayObjLevels, out hitObject)) {
				selectedTxt = hitObject.collider.name;
			}
			
			//if(selectedTxt.Contains("Level")) Application.LoadLevel(selectedTxt);
			switch (selectedTxt) {
			case "play":
				Application.LoadLevel ("Home");
				break;
			case "exit":
				Application.Quit ();
				break;
			}
			
		}
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
