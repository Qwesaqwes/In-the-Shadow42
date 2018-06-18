using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	// public GameObject	fadeObj;
	public GameObject	blurObj;
	[HideInInspector]public int			_SceneToLoad;

	// LoadLevel			_fade;
	
	// Use this for initialization
	void Start ()
	{
		// _fade = fadeObj.GetComponent<LoadLevel>();	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (blurObj.activeSelf)
			{
				//close
				blurObj.SetActive(false);
			}
			else if (!blurObj.activeSelf)
			{
				//open
				blurObj.SetActive(true);
			}
		}
	}

	public void RestartButton()
	{
		_SceneToLoad = SceneManager.GetActiveScene().buildIndex;
	}

	public void ExitButton()
	{
		Application.Quit();
	}

	public void MenuButton()
	{
		_SceneToLoad = 1;
	}
}
