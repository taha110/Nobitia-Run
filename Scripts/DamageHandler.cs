using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	public int health = 1;

	public float invulnPeriod = 0;
	float invulnTimer = 0f;
	int correctLayer;
	public float wait=0.5f;
	float timer=0f;

	SpriteRenderer spriteRend;

	Animator animator;

	void Start() {
		correctLayer = gameObject.layer;
		animator = transform.GetComponentInChildren<Animator>();

		// NOTE!  This only get the renderer on the parent object.
		// In other words, it doesn't work for children. I.E. "enemy01"
		spriteRend = GetComponent<SpriteRenderer>();

		if(spriteRend == null) {
			spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

			if(spriteRend==null) {
				Debug.LogError("Object '"+gameObject.name+"' has no sprite renderer.");
			}
		}
	}

	void OnTriggerEnter2D() {
		animator.SetTrigger("blastEnemyTrigger");
		health--;
	//	Debug.Log ("" + health);
		timer = 0;
		if(invulnPeriod > 0) {
			invulnTimer = invulnPeriod;
			gameObject.layer = 10;
		}



	}

	void Update() {
		timer += Time.deltaTime;
		if(invulnTimer > 0) {
			invulnTimer -= Time.deltaTime;

			if(invulnTimer <= 0) {
				gameObject.layer = correctLayer;
				if(spriteRend != null) {
					spriteRend.enabled = true;
				}
			}
			else {
				if(spriteRend != null) {
					spriteRend.enabled = !spriteRend.enabled;
				}
			}
		}

		if(health <= 0 && timer>=wait ) {
			Die();
		}
	}

	void Die() {
		Destroy(gameObject);
	}

}
