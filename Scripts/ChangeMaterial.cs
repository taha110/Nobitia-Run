using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {

	bool ChrLastInvisiblity;

	public Material simpleMat;
	public Material invisibleMat;

	// Use this for initialization
	void Start () {
		ChrLastInvisiblity = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(ChrLastInvisiblity != PlayerFish._isInvisible){

		if(PlayerFish._isInvisible){
			this.GetComponent<SkinnedMeshRenderer>().material = invisibleMat;
			print("dsadadada");
		}else
		{
			this.GetComponent<SkinnedMeshRenderer>().material = simpleMat;

		}
		ChrLastInvisiblity = PlayerFish._isInvisible;
		}
	}
}
