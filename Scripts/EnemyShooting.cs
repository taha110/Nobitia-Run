using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {
	
	public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
	public GameObject bulletPrefab;
	int bulletLayer;
	public float fireDelay = 0.25f;
	float cooldownTimer = 0;
	Transform position;
	Vector3 screenPos;
	public float hitTimeOne = 5;
	public float hitPointX = -180;
	public float hitPointY = -60;
	public static int deathCounter=0;


	void Start() {//][][[][][][][][][][][][][][][][[]
		bulletLayer = gameObject.layer;
	}

	void Update () {
		
		//Debug.Log("shoot time : " + hitTimeOne);
		hitTimeOne -= Time.deltaTime * 1;
		cooldownTimer -= Time.deltaTime;	
	}

	void FixedUpdate() {
		if(  hitTimeOne<=0) {
			hitTimeOne=5;
			// SHOOT!
			cooldownTimer = fireDelay;
			Vector3 bulletOffset1 = new Vector3(hitPointX, hitPointY, Input.mousePosition.z);
			bulletOffset1.Normalize();
			//	Debug.Log("X : " +Input.mousePosition.x +  "  Y : " + Input.mousePosition.y	);
			float zAngle = Mathf.Atan2(bulletOffset1.y, bulletOffset1.x) * Mathf.Rad2Deg +270;
			
			Quaternion desiredRot = Quaternion.Euler( 0, 0,zAngle );
			GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position, desiredRot);
			//bulletGO.layer = bulletLayer;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		deathCounter++;
		Debug.Log ("death counter : " + deathCounter);
		Destroy(gameObject,1);
	}

}