using UnityEngine;
using System.Collections;

public class TouchLogic : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		//is there a touch on screen?
		if (Input.touches.Length <= 0) {
						//if no touches then execute this code
				} else { //if there is a touch
						//loop through all the the touches on screen
						for (int i = 0; i < Input.touchCount; i++) {
								//executes this code for current touch (i) on screen
								if (this.GetComponent<GUITexture>() != null && (this.GetComponent<GUITexture>().HitTest (Input.GetTouch (i).position))) {
										//if current touch hits our guitexture, run this code
										if (Input.GetTouch (i).phase == TouchPhase.Began) {
												//need to send message b/c function is not present in this script
												//OnTouchBegan();
												this.SendMessage ("MyOnTouchBegan");
										}
										if (Input.GetTouch (i).phase == TouchPhase.Ended) {
												//OnTouchEnded();
												this.SendMessage ("MyOnTouchEnded");
										}
								}
						}
				}

	}
}
