using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {


	void Awake(){

		if (IsGameStartFirstTime()) {

			InitializeDefaultSettings ();
			SaveGameFirstStart ();
		}

	}

	/// <summary>
	/// Background Music is on if status is True
	/// </summary>
	public static void SaveBGMStatus (bool status){
	
		if (status)
			PlayerPrefs.SetInt ("BGMStatus", 1);
		else
			PlayerPrefs.SetInt ("BGMStatus", 0);

	}

	/// <summary>
	/// Returns True if background music is on
	/// </summary>
	public static bool LoadBGMStatus(){

		if (PlayerPrefs.GetInt ("BGMStatus") == 1)
			return true;
		else
			return false;
			
	}

	/// <summary>
	/// Sound Effects are on if status is True
	/// </summary>
	public static void SaveSFXStatus (bool status){

		if (status)
			PlayerPrefs.SetInt ("SFXStatus", 1);
		else
			PlayerPrefs.SetInt ("SFXStatus", 0);

	}

	/// <summary>
	/// Returns True if Sound Effects are on
	/// </summary>
	public static bool LoadSFXStatus(){

		if (PlayerPrefs.GetInt ("SFXStatus") == 1)
			return true;
		else
			return false;

	}
		
	/// <summary>
	/// Vibration is on if status is True
	/// </summary>
	public static void SaveVibrationStatus (bool status){

		if (status)
			PlayerPrefs.SetInt ("VibrationStatus", 1);
		else
			PlayerPrefs.SetInt ("VibrationStatus", 0);

	}

	/// <summary>
	/// Returns True if Vibration is on
	/// </summary>
	public static bool LoadVibrationStatus(){

		if (PlayerPrefs.GetInt ("VibrationStatus") == 1)
			return true;
		else
			return false;

	}
		
	/// <summary>
	/// Saves the best score.
	/// </summary>
	public static void SaveBestScore(float score){

		PlayerPrefs.SetFloat ("BestScore", score);

	}

	/// <summary>
	/// Returns the best score.
	/// </summary>
	/// <returns>The best score.</returns>
	public static float LoadBestScore(){
	
		return PlayerPrefs.GetFloat ("BestScore");
	}


	/// <summary>
	/// Saves the ads counter.
	/// </summary>
	public static void SaveAdsCounter (int counter){
	
		PlayerPrefs.SetInt ("AdsCounter", counter);

	
	}

	/// <summary>
	/// Returns the ads counter.
	/// </summary>
	public static int LoadAdsCounter(){
		
		return PlayerPrefs.GetInt ("AdsCounter");
	
	}

	/// <summary>
	/// Saves the no ads purchase.
	/// </summary>
	public static void SaveNoAdsPurchase(){
	
	
		PlayerPrefs.SetInt ("NoAdsPurchase", 1);

	}

	/// <summary>
	/// Returns true if no ads purchased.
	/// </summary>
	public static bool LoadNoAdsPurchase(){
	
		if (PlayerPrefs.GetInt ("NoAdsPurchase") == 1) {
		
			return true;
		} else {
		
			return false;
		}

	
	}


	/// <summary>
	/// Deletes all game data.
	/// </summary>
	public static void DeleteAllGameData(){
	
		PlayerPrefs.DeleteAll ();

	}



	private void SaveGameFirstStart(){
	
		PlayerPrefs.SetInt ("StartingFirtsTime", 1);
	}

	private bool IsGameStartFirstTime(){
	
		if (PlayerPrefs.GetInt ("StartingFirtsTime") == 0) {
			return true;
		} else {
		
			return false;
		}

	}

	private void InitializeDefaultSettings(){
	
		SaveBGMStatus (true);
		SaveSFXStatus (true);
		SaveVibrationStatus (true);

	}




}
