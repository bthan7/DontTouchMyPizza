using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {

	public Text timeText , bestTimeText;

	[Space]
	[Header("Button Sprites")]
	public Sprite BGMOn;
	public Sprite BGMOff;
	public Sprite sfxOn;
	public Sprite sfxOff;
	public Sprite vibrationOn;
	public Sprite vibrationOff;


	[Space]
	[Header("Button Referances")]
	public Image BGMToggleButton; 
	public Image sFXToggleButton;
	public Image vibrationToggleButton;

	[Space]
	public Button continueButton;
	public Button noAdsButton;
	public GameObject continueButtonGlow;
	public GameObject tapToPlayButton;
	public GameObject restorePurchasesButton;


	private bool m_SocialMediaOpened = false;

	private bool m_OptionsOpened = false;

	private bool m_ContinueUsed = false;

	// Manager Referances

	private GameManager m_GameManagerRef; 
	private AnimationManager m_AnimationManagerRef;
	private AudioManager m_AudioManagerRef;
	private AdsManager m_AdsManagerRef;

	// Use this for initialization
	void Start () {

		m_GameManagerRef = GameObject.FindWithTag ("GAME MANAGER").GetComponent<GameManager> ();
		m_AnimationManagerRef = GameObject.FindWithTag ("ANIMATION MANAGER").GetComponent<AnimationManager> ();
		m_AudioManagerRef = GameObject.FindWithTag ("AUDIO MANAGER").GetComponent<AudioManager> ();
		m_AdsManagerRef = GameObject.FindWithTag ("ADS MANAGER").GetComponent<AdsManager> ();

		#if UNITY_ANDROID

		restorePurchasesButton.SetActive(false);

		#endif


		InitializeButtons ();

	}
	
	// Update is called once per frame
	void Update () {


		timeText.text = m_GameManagerRef.currentScore.ToString ("00.00");
		bestTimeText.text = DataManager.LoadBestScore ().ToString("00.00");
	

		if (AdsManager.IsAdReady () && !m_ContinueUsed) {

			continueButton.interactable = true;
			continueButtonGlow.SetActive (true);
		
		} else {
		
			continueButton.interactable = false;
			continueButtonGlow.SetActive (false);


		}
		

	}
		

	public void StartGame(){
	

		m_AnimationManagerRef.MainMenuClose ();
		m_GameManagerRef.StartGame ();
		tapToPlayButton.SetActive (false);

		if (m_OptionsOpened) {
		
			m_AnimationManagerRef.OptionsClose ();
			m_OptionsOpened = false;
		}
			
		if (m_SocialMediaOpened) {
		
			m_AnimationManagerRef.SocialMediaClose ();
			m_SocialMediaOpened = false;

		}

		
	}

	public void Retry(){
	
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}

	public void ContinuePlayindAdRequest(){
	
		m_AdsManagerRef.ShowRewardedAd ();
	

	}

	public void ContinuePlaying(){
	
		m_GameManagerRef.ContinuePlaying ();
		m_AnimationManagerRef.ContinuePlaying ();
		m_ContinueUsed = true;

	
	}

	public void GameOver(){
	
		m_AnimationManagerRef.GameOver ();


	

	}


	public void ToggleOptions(){

		m_AudioManagerRef.PlayButtonTap ();

		if (!m_OptionsOpened) {
			m_OptionsOpened = true;
			m_AnimationManagerRef.OptionsOpen ();
	
		}else {
			m_OptionsOpened = false;
			m_AnimationManagerRef.OptionsClose ();
		
		}
	}

	public void ToggleSocialMedia(){

		m_AudioManagerRef.PlayButtonTap ();

		if (!m_SocialMediaOpened) {
		
			m_SocialMediaOpened = true;
			m_AnimationManagerRef.SocialMediaOpen ();
		
		} else {
		
			m_SocialMediaOpened = false;
			m_AnimationManagerRef.SocialMediaClose ();
		
		}
	}

	public void ToggleBGM(){

		m_AudioManagerRef.PlayButtonTap ();

		if (DataManager.LoadBGMStatus()) {

			m_AudioManagerRef.BGMTurnOff ();
			BGMToggleButton.sprite = BGMOff;
			DataManager.SaveBGMStatus (false);

		} else {
		
			m_AudioManagerRef.BGMTurnOn ();
			BGMToggleButton.sprite = BGMOn;
			DataManager.SaveBGMStatus (true);
		}


	}

	public void ToggleSFX(){

		m_AudioManagerRef.PlayButtonTap ();

		if (DataManager.LoadSFXStatus()) {
		
			m_AudioManagerRef.SFXTurnOff ();
			sFXToggleButton.sprite = sfxOff;
			DataManager.SaveSFXStatus (false);
		} else {
		
			m_AudioManagerRef.SFXTurnOn ();
			sFXToggleButton.sprite = sfxOn;
			DataManager.SaveSFXStatus (true);
		}

	}

	public void ToggleVibration(){

		m_AudioManagerRef.PlayButtonTap ();

		if (DataManager.LoadVibrationStatus ()) {
		
			vibrationToggleButton.sprite = vibrationOff;
			DataManager.SaveVibrationStatus (false);

		}else{

			vibrationToggleButton.sprite = vibrationOn;
			DataManager.SaveVibrationStatus(true);

			VibrationManager.VibrationToggle ();
		}



	}


	public void FacebookButtonClick(){
	
		m_AudioManagerRef.PlayButtonTap ();
		Application.OpenURL("https://www.facebook.com/dgrgames");

	}

	public void TwitterButtonClick(){
	
		m_AudioManagerRef.PlayButtonTap ();
		Application.OpenURL("https://twitter.com/DgrGamess");

	}

	public void InstagramButtonClick(){
	
		m_AudioManagerRef.PlayButtonTap ();
		Application.OpenURL("https://www.instagram.com/dgrgames");

	}

	public void YoutubeButtonClick(){
	
		m_AudioManagerRef.PlayButtonTap ();
		Application.OpenURL("https://www.youtube.com/channel/UCOrTnFi8LSV113HHBDRD15g");

	}

	public void DgrButtonClick(){
	
		m_AudioManagerRef.PlayButtonTap ();
		Application.OpenURL("https://www.dgrgames.com");

	}



	private void InitializeButtons(){

		if (!DataManager.LoadBGMStatus ()) {
		
			BGMToggleButton.sprite = BGMOff;
		}

		if (!DataManager.LoadSFXStatus ()) {
		
			sFXToggleButton.sprite = sfxOff;
		}

		if (!VibrationManager.supportingHaptic) {

			vibrationToggleButton.GetComponent<Button> ().interactable = false;

		}else if (!DataManager.LoadVibrationStatus ()) {
		
			vibrationToggleButton.sprite = vibrationOff;
		}

		if (DataManager.LoadNoAdsPurchase ()) {
		
			noAdsButton.interactable = false;

		}

	}
}
