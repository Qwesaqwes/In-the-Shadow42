using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelection : MonoBehaviour
{

	void Start()
	{
		PlayerPrefs.SetInt("Mode", 0);
		PlayerPrefs.SetInt("Level2", 0);
		PlayerPrefs.SetInt("Level3", 0);
	}

	//if mode 0 == Normal else Tester
	public void SelectedMode(int mode)
	{
		PlayerPrefs.SetInt("Mode", mode);
	}
}
