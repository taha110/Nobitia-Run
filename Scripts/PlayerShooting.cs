using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	Animator animator;
	Transform position;

	void Start() {
		animator = transform.GetComponentInChildren<Animator>();
	}

	void OnTriggerEnter2D(Collider2D other) {
			//animator.SetTrigger("isDie");
		}

	void Update () {
		}
}
