using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

public float backgroundSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		

		


		if(PlayerPrefs.HasKey("FishSide")){
			if(PlayerPrefs.GetInt("FishSide") == 0){
				transform.Translate(Vector3.right * Time.deltaTime * backgroundSpeed);

				if(this.gameObject.transform.position.x > 76.5){
				this.gameObject.transform.position = new Vector3(-76.5f , 1f , 10f);
				}
			}else{
						transform.Translate(Vector3.right * Time.deltaTime * (backgroundSpeed * -1));

				if(this.gameObject.transform.position.x < -76.5){
				this.gameObject.transform.position = new Vector3(76.5f , 1f , 10f);
				}
			}
		}

	}
}
