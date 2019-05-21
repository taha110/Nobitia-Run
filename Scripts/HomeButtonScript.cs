using UnityEngine;
using System.Collections;

public class HomeButtonScript : MonoBehaviour
{

	
	public Texture btnTexture_play;
	public Texture btnTexture_quit;

	float W = Screen.width;
	float H = Screen.height;

	void OnGUI ()
	{
		if (!btnTexture_play || !btnTexture_quit) {
			Debug.LogError ("Please assign a MyTexturez Home Screen");
			//return;
		} 
		
		if (GUI.Button (new Rect (W / 2 - W / 10, H / 2, W / 5, W / 10), btnTexture_play)) {
			Debug.Log ("Clicked the button with an image");
			//Application.Quit ();
			Application.LoadLevel ("SkyIsland");
		}
		
		if (GUI.Button (new Rect (W / 2 - W / 10, H / 1.3f, W / 5, W / 10), btnTexture_quit)) {
			Debug.Log ("Clicked the button with an image");
			Application.Quit ();
		}

	}



}