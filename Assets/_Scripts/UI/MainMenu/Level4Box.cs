using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Box : MonoBehaviour
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
			_loadLevels.SelectedLevel(5);
			_fade.MainMenuFadeOut();
			FindObjectOfType<AudioManager>().Play("SelectedLevel");
		}
	}

	void OnMouseEnter()
	{
		transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
	}

	void OnMouseExit()
	{
		transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
	}
}
