using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnetEffect : MonoBehaviour {

	public float minMagnetDistance;
	public float followSpeed; 
	public float offsetPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerFish._isMagnet){
			if(minMagnetDistance > Vector3.Distance(PlayerFish.NobitaPos , this.gameObject.transform.position)){

			if(PlayerFish.NobitaPos.x -offsetPos> this.gameObject.transform.position.x){
				this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + (followSpeed*Time.deltaTime) , this.gameObject.transform.position.y, this.gameObject.transform.position.z);
			}else if(PlayerFish.NobitaPos.x +offsetPos < this.gameObject.transform.position.x){
				this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - (followSpeed*Time.deltaTime) , this.gameObject.transform.position.y, this.gameObject.transform.position.z);
			}
			
			 if(PlayerFish.NobitaPos.y -offsetPos > this.gameObject.transform.position.y){
				this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x  , this.gameObject.transform.position.y + (followSpeed*Time.deltaTime), this.gameObject.transform.position.z);
			}else if(PlayerFish.NobitaPos.y +offsetPos < this.gameObject.transform.position.y){
				this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x  , this.gameObject.transform.position.y - (followSpeed*Time.deltaTime), this.gameObject.transform.position.z);
			}	

			}
		}
	}
}
