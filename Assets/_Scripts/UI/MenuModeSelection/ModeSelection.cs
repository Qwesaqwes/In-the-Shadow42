using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelection : MonoBehaviour
{

	void Start()
	{
		if (!PlayerPrefs.HasKey("Mode"))
			PlayerPrefs.SetInt("Mode", 0);
		if (!PlayerPrefs.HasKey("Level2"))
			PlayerPrefs.SetInt("Level2", 0);
		if (!PlayerPrefs.HasKey("Level3"))
			PlayerPrefs.SetInt("Level3", 0);
		if (!PlayerPrefs.HasKey("Level4"))
			PlayerPrefs.SetInt("Level4", 0);
		if (!PlayerPrefs.HasKey("LastLevelClear"))
			PlayerPrefs.SetInt("LastLevelClear", 0);

		FindObjectOfType<AudioManager>().Stop("MapSound");
		FindObjectOfType<AudioManager>().Play("IntroSound");

		//debug
			
		// PlayerPrefs.SetInt("Mode", 0);
		// PlayerPrefs.SetInt("Level2", 0);
		// PlayerPrefs.SetInt("Level3", 0);
		// PlayerPrefs.SetInt("Level4", 0);
		// PlayerPrefs.SetInt("LastLevelClear", 0);
	}

	//if mode 0 == Normal else Tester
	public void SelectedMode(int mode)
	{
		PlayerPrefs.SetInt("Mode", mode);
	}
}
