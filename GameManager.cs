using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


	public static bool gameOver = false;

	public static bool gameStarted = false;

	public int health = 6;

	public float currentScore;

	public float difficulty;

	private bool m_GameOverCalled = false;

	private bool m_DifficultyLoopStarted = false;

	private GUIManager m_GUIManagerRef;

	private ArmSpawner m_ArmSpawnerRef;

	private AdsManager m_AdsManagerRef;

	void Awake(){
	
		ResetGame ();
	}

	// Use this for initialization
	void Start () {

		m_GUIManagerRef = GameObject.FindWithTag ("GUI MANAGER").GetComponent<GUIManager> ();

		m_ArmSpawnerRef = GameObject.FindWithTag ("ARM SPAWNER").GetComponent<ArmSpawner> ();

		m_AdsManagerRef = GameObject.FindWithTag ("ADS MANAGER").GetComponent<AdsManager> ();

		Application.targetFrameRate = 60;

	}

	void Update(){

		if (health <= 0 && !m_GameOverCalled) {

			GameOver ();
			m_GameOverCalled = true;
		}

		if (gameStarted && !m_DifficultyLoopStarted) {

			StartCoroutine (IncreaseDifficulty ());
			m_DifficultyLoopStarted = true;
		}

	}

	
	// Update is called once per frame
	void FixedUpdate () {

		if(gameStarted && !gameOver)
			currentScore += 0.01F;


	}

	public void StartGame(){
	
		gameStarted = true;
		m_ArmSpawnerRef.StartArmSpawn ();


	
	}


	public void ContinuePlaying(){
	

		health = 3;
		gameOver = false;
		m_GameOverCalled = false;
		m_ArmSpawnerRef.StartArmSpawn ();
	
	}


	public void GameOver (){

		gameOver = true;


		if(DataManager.LoadVibrationStatus() && VibrationManager.supportingHaptic){
			VibrationManager.VibrationGameOver ();
		}

		if (!DataManager.LoadNoAdsPurchase ()) {
			if (DataManager.LoadAdsCounter () > 2) {
		
				m_AdsManagerRef.ShowAd ();
				DataManager.SaveAdsCounter (0);
		
			} else {

				DataManager.SaveAdsCounter (DataManager.LoadAdsCounter () + 1);

			}
		}

		if (DataManager.LoadBestScore () < currentScore) {

			DataManager.SaveBestScore (currentScore);
		}

		m_GUIManagerRef.GameOver ();


	}


	public void ResetGame(){

		gameStarted = false;
		gameOver = false;
		currentScore = 0;
		difficulty = 3F;
		health = 6;

	}
		
	IEnumerator IncreaseDifficulty(){
	
	
		yield return new WaitForSeconds (5F);

		if(difficulty > 1F){

			difficulty -= 0.2F;


		}



		StartCoroutine (IncreaseDifficulty ());
	}




}
