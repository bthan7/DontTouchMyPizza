using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class VibrationManager : MonoBehaviour {

	public static bool supportingHaptic;

	protected virtual void Awake()
	{
		MMVibrationManager.iOSInitializeHaptics ();

		Debug.Log("Vibrations Initialized");

		supportingHaptic = MMVibrationManager.HapticsSupported ();
	
	}

	protected virtual void OnDisable()
	{
		MMVibrationManager.iOSReleaseHaptics ();
	
	}
		

	public static void VibrationFail (){

		MMVibrationManager.Haptic (HapticTypes.Failure);

		Debug.Log("Vibration Fail");
	}

	public static void VibrationTableHit (){

		MMVibrationManager.Haptic (HapticTypes.HeavyImpact);

		Debug.Log("Vibration Tabe Hit");
	}

	public static void VibrationGameOver (){

		Handheld.Vibrate ();

		Debug.Log("Vibration Game Over");
	}

	public static void VibrationToggle (){

		Handheld.Vibrate ();

		Debug.Log("Vibration Toggle");
	}

	public static void VibrationArmHit (){

		MMVibrationManager.Haptic (HapticTypes.LightImpact);

		Debug.Log("Vibration Arm Hit");

	}
}
