using UnityEngine;
using System.Collections;

public class EnemyPrefebScript : MonoBehaviour
{

	
	public Vector3 velocity;
	public Vector3 respawn;
	
	Transform position;
	Animator animator;

	public AudioClip hurt_clip;
	AudioSource audio;

	
	//GameObject EnemyOneObj;
	GameObject PlayerObj ;
	public float Distance;
	// Use this for initialization
	
	void Start ()
	{
		respawn.x = Random.Range (4f, 10f);
		animator = transform.GetComponentInChildren<Animator> ();
		velocity.x = 0.02f;
		//EnemyOneObj = GameObject.Find ("enemy_One");
		PlayerObj = GameObject.FindGameObjectWithTag ("Player");
		this.gameObject.transform.position += respawn;


		audio = GetComponent<AudioSource> ();

	}
	
	
	void OnTriggerEnter2D (Collider2D other)
	{
		//respawn.x = 10f;
		
		//Debug.Log("Make it RE-SPAWN" );
		audio.PlayOneShot (hurt_clip, 0.8F);

		//EnemyOneObj.transform.position += respawn;
		Destroy (this.gameObject);

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		Distance = Vector2.Distance (PlayerObj.transform.position, this.gameObject.transform.position);
		//	Debug.Log ("width  : " + Screen.width); 
		
		respawn.x = 10f;
		if (Distance < 0.5) {
		}
		
		//cooldownTimer -= Time.deltaTime;	
		
		if (CameraMovement.boolPause == false) {
			transform.position -= velocity;
		}
	}

}
