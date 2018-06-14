using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
	[HideInInspector]public int		scene;

	//Level2 Button stuff
	public GameObject				level2ButtonObj;
	public GameObject				level2TextObj;
	Image							_level2Image;
	Button							_level2Button;
	Text							_level2Text;

	bool							_Normal = false;

	void Start()
	{
		if (PlayerPrefs.GetInt("Mode") == 0)
		{
			//Normal Mode
			Debug.Log("You are in Normal MOde");
			_Normal = true;
			_level2Image = level2ButtonObj.GetComponent<Image>();
			_level2Button = level2ButtonObj.GetComponent<Button>();
			_level2Text = level2TextObj.GetComponent<Text>();
		}
		else
		{
			//Tester Mode
			Debug.Log("You are in TesterMode MOde");
			_Normal = true;
		}
	}

	void Update()
	{
		if (_Normal)
		{
			if (PlayerPrefs.GetInt("Level2") == 0)
			{
				//block button
				_level2Image.enabled = false;
				_level2Button.enabled = false;
				_level2Text.color = Color.red;
			}
			else
			{
				//enable Button
				_level2Image.enabled = true;
				_level2Button.enabled = true;
				_level2Text.color = Color.white;
			}
		}
		else
		{
			//is tester
		}
	}

	public void SelectedLevel(int level)
	{
		scene = level;
	}

	public void ExitButton()
	{
		Application.Quit();
	}
}
