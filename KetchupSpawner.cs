using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetchupSpawner : MonoBehaviour {

	public GameObject ketchup;

	public Sprite[] ketchupSprites;

	private GameObject lastSpawnedKetchup;

	// Use this for initialization
	void Start () {

		StartCoroutine (SpawnKetchup ());
	}

	IEnumerator SpawnKetchup(){
	
		yield return new WaitForSeconds (0.2F);

		lastSpawnedKetchup = Instantiate (ketchup,transform.position,transform.rotation);
	
		lastSpawnedKetchup.GetComponent<SpriteRenderer> ().sprite = ketchupSprites [Random.Range (0, ketchupSprites.Length)];
		Destroy (lastSpawnedKetchup, 9F);

		StartCoroutine (SpawnKetchup());
	}
}

