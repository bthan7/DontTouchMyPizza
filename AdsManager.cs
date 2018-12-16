using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

	public class AdsManager: MonoBehaviour {

		public static bool adCalled;

		private GUIManager m_GuiManagerRef;



		void Start(){

		m_GuiManagerRef = GameObject.FindWithTag ("GUI MANAGER").GetComponent<GUIManager> ();

		}

		public void ShowAd (){
			if (Advertisement.IsReady ("video")) {
				adCalled = true;
				Advertisement.Show ("video", new ShowOptions (){ resultCallback = AdHandleResult});
				DataManager.SaveAdsCounter (0);

			}
		}
			
		public void ShowRewardedAd(){
			if (Advertisement.IsReady ("rewardedVideo"))
				Advertisement.Show ("rewardedVideo", new ShowOptions (){ resultCallback = RewardedAdHandleResult });
		}
			
	


		public  void AdHandleResult (ShowResult adResult)
		{
			switch (adResult) {
			case ShowResult.Finished:

				adCalled = false;
				break;
			case ShowResult.Skipped:

				adCalled = false;
				break;
			case ShowResult.Failed:

				adCalled = false;
				break;

			}
		}
		

		public  void RewardedAdHandleResult (ShowResult adResult)
		{
			switch (adResult) {
		case ShowResult.Finished:
			

			m_GuiManagerRef.ContinuePlaying ();

	

			break;
		case ShowResult.Skipped:
			break;
		case ShowResult.Failed:
			break;

			}
		}

		

		public static bool IsAdReady ()
		{

			if (Advertisement.IsReady ("rewardedVideo"))
				return true;
			else
				return false;
		}			
	}

