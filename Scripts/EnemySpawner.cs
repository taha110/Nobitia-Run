using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

	float counter = 0;
	float checker = 0;
	public GameObject EnemyOneObj;
	public GameObject EnemyTwoObj;
	public GameObject EnemyThreeObj;

	int enemyNumber;

	// Use this for initialization
	void Start ()
	{
		enemyNumber = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (checker >= counter) {

			if (enemyNumber == 0) {
				GameObject cubeSpawn = (GameObject)Instantiate (EnemyOneObj, new Vector3 (0f, -1f, -12f), transform.rotation);

			} else if (enemyNumber == 1) {
				GameObject cubeSpawn = (GameObject)Instantiate (EnemyTwoObj, new Vector3 (0f, -2.2f, -12f), transform.rotation);

			} else if (enemyNumber == 2) {
				GameObject cubeSpawn = (GameObject)Instantiate (EnemyOneObj, new Vector3 (0f, -1.7f, -12f), transform.rotation);

			}

			counter += Random.Range (3f, 6f);
		}
		enemyNumber = Random.Range (0, 3);
		checker += Time.deltaTime;

		Debug.Log ("enemy num  : " + enemyNumber);
	}
}
