using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSpawner : MonoBehaviour {

	public GameObject arm;

	public Transform[] horizontalSpawnPoints;

	public Transform[] verticalSpawnPoints;

	private GameManager m_GameManagerRef;

	// Use this for initialization
	void Start () {

		m_GameManagerRef = GameObject.FindWithTag ("GAME MANAGER").GetComponent<GameManager> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.gameOver) {
		
			StopAllCoroutines ();
		}

	}

	public void StartArmSpawn(){

		Instantiate (arm, verticalSpawnPoints [0].position, transform.rotation).GetComponent<ArmMovement>().speed = 1.5F;


		StartCoroutine (SpawnArm ());

	}



	IEnumerator SpawnArm(){

		yield return new WaitForSeconds (Random.Range (0, m_GameManagerRef.difficulty));

		if (!GameManager.gameOver) {
			if (Random.Range (0, 2) == 0) {
				Instantiate (arm, horizontalSpawnPoints [Random.Range (0, horizontalSpawnPoints.Length)].position, transform.rotation);
			} else {
				Instantiate (arm, verticalSpawnPoints [Random.Range (0, verticalSpawnPoints.Length)].position, transform.rotation);
			}

			StartCoroutine (SpawnArm ());
		}

	}


}