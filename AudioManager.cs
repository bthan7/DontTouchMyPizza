using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip buttonTap;

	public AudioClip pizzaDrop;

	public AudioClip[] deskHits, slaps, screams;

	public AudioClip wilhelmScream;

	private int wilhelmScreamChance = 1;

	private int screamChance = 50;

	private const float noWaitTime = 0F;

	[Header("Audio Source Refferances")]

	public AudioSource sFXAudioSourceRef;

	public AudioSource bGMAudioSourceRef;



	// Use this for initialization
	void Start () {

		InitializeSounds ();

	}

	public void BGMTurnOn(){
	
		bGMAudioSourceRef.volume = 1;

	}
	public void BGMTurnOff(){

		bGMAudioSourceRef.volume = 0;

	}
	public void SFXTurnOn(){
	
		sFXAudioSourceRef.volume = 1;
	
	}
	public void SFXTurnOff(){

		sFXAudioSourceRef.volume = 0;

	}
		
	private void InitializeSounds(){
	
		if (DataManager.LoadBGMStatus ()) {
		
			bGMAudioSourceRef.volume = 1;
		} else {
		
			bGMAudioSourceRef.volume = 0;
		}


		if (DataManager.LoadSFXStatus ()) {
		
			sFXAudioSourceRef.volume = 1;
		} else {
		
			sFXAudioSourceRef.volume = 0;
		}
	
	}


	public void PlayButtonTap(){
	
		StartCoroutine (PlaySFX (buttonTap, noWaitTime));

	}

	public void PlayDeskHit(){


		StartCoroutine (PlaySFX (deskHits [Random.Range (0, deskHits.Length)], noWaitTime));

		PlayPizzaDrop (0.1F);

	}

	private void PlayPizzaDrop(float waitTime){

		StartCoroutine (PlaySFX (pizzaDrop, waitTime));
	
	}


	public void PlaySlap(){

		StartCoroutine (PlaySFX (slaps [Random.Range (0, slaps.Length)], noWaitTime));

		PlayScream (0.1F);


	}

	private void PlayScream(float waitTime){
	

		if (Random.Range (1, 101) <= screamChance) {

			if (Random.Range (1, 101) <= wilhelmScreamChance) {
		
				StartCoroutine (PlaySFX (wilhelmScream, 0.1F));

			} else {
		
				StartCoroutine (PlaySFX (screams [Random.Range (0, screams.Length)], 0.1F));
		
			}
		}
	}






	IEnumerator PlaySFX (AudioClip audioClip, float waitTime){

		yield return new WaitForSeconds (waitTime);

		sFXAudioSourceRef.PlayOneShot (audioClip);


	}


}
