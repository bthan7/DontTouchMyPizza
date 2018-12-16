using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetchupFadeoutRandomizer : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine (Sleep ());

	}

	IEnumerator Sleep(){

		yield return new WaitForSeconds (Random.Range (0F, 1F));

		GetComponent<Animator>().Play("Ketchup Fadeout");

	}
}
