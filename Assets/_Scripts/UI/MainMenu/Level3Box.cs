using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Box : MonoBehaviour
{
	public GameObject	MainMenuFadeObj;
	public GameObject	LoadLevelsObj;

	MainMenuFade		_fade;
	LoadLevels			_loadLevels;

	void Start()
	{
		_fade = MainMenuFadeObj.GetComponent<MainMenuFade>();
		_loadLevels = LoadLevelsObj.GetComponent<LoadLevels>();
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_loadLevels.SelectedLevel(4);
			_fade.MainMenuFadeOut();
		}
	}
}
