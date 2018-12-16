using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PizzaHopController : MonoBehaviour {
	

	public GameObject touchAnimation;

	private AnimationManager m_AnimationManagerRef;

	private AudioManager m_AudioManagerRef;
	// Use this for initialization
	void Start () {

		m_AnimationManagerRef = GameObject.FindWithTag ("ANIMATION MANAGER").GetComponent<AnimationManager> ();

		m_AudioManagerRef = GameObject.FindWithTag ("AUDIO MANAGER").GetComponent<AudioManager> ();

	}


	void OnMouseOver(){



		if (Input.GetMouseButtonDown (0) && !GameManager.gameOver) {

			if (GameManager.gameStarted) {
				if (DataManager.LoadVibrationStatus() && VibrationManager.supportingHaptic) {
					VibrationManager.VibrationTableHit ();
				}


				m_AnimationManagerRef.PlayRandomPizzaHop ();
				m_AnimationManagerRef.PlayScreenShake ();
				m_AudioManagerRef.PlayDeskHit ();


				Destroy (Instantiate (touchAnimation, Camera.main.ScreenToWorldPoint (Input.mousePosition + new Vector3 (0, 0, 10F)), transform.rotation), 0.2F);


			} 
		}

		

	}


}
