using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

	public Animator pizzaAnimator, gameAnimator, optionsAnimator, socialMediaAnimator, screenShake;

	// Use this for initialization
	void Start () {

		pizzaAnimator.SetTrigger("Pizza Start");

	}

	public void PlayRandomPizzaHop(){

	
		switch (Random.Range(1,6)) {
		case 1:
			
			pizzaAnimator.SetTrigger ("Pizza Hop 1");
		break;
	
		case 2:
			
			pizzaAnimator.SetTrigger("Pizza Hop 2");
		break;
		
		case 3:
		
			pizzaAnimator.SetTrigger("Pizza Hop 3");
		break;
		
		case 4:
		
			pizzaAnimator.SetTrigger("Pizza Hop 4");
		break;
		
		case 5:
		
			pizzaAnimator.SetTrigger("Pizza Hop 5");
		break;
		
		}
	


	}


	public void PlayScreenShake (){
	
		screenShake.SetTrigger ("Screen Shake");
	
	}

	public void OptionsOpen (){

		optionsAnimator.SetBool ("Options Opened", true);


	}

	public void OptionsClose (){
	
		optionsAnimator.SetBool ("Options Opened", false);
	
	}

	public void SocialMediaOpen(){

		socialMediaAnimator.SetBool ("Social Media Opened", true);

	}

	public void SocialMediaClose(){

		socialMediaAnimator.SetBool ("Social Media Opened", false);

	}

	public void MainMenuClose(){
	
		gameAnimator.SetTrigger ("Close Main Menu");

	}

	public void GameOver(){

		gameAnimator.SetTrigger ("Game Over");

	}

	public void ContinuePlaying(){

		gameAnimator.SetTrigger("Continue Playing");

	}






}
