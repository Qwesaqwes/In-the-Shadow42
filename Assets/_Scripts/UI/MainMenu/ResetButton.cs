using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		if (PlayerPrefs.GetInt("Mode") == 1)
		{
			gameObject.SetActive(false);
		}
	}
}
