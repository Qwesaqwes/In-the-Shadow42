using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
	[HideInInspector]public int		scene;

	//Level1 Button stuff
	public GameObject				level1TextObj;
	Text							_level1Text;

	//Level2 Button stuff
	public GameObject				level2ButtonObj;
	public GameObject				level2TextObj;
	Image							_level2Image;
	Button							_level2Button;
	Text							_level2Text;

	//Level3 Button stuff
	public GameObject				level3ButtonObj;
	public GameObject				level3TextObj;
	Image							_level3Image;
	Button							_level3Button;
	Text							_level3Text;


	bool							_Normal = false;

	void Start()
	{
		if (PlayerPrefs.GetInt("Mode") == 0)
		{
			//Normal Mode
			Debug.Log("You are in Normal MOde");
			_Normal = true;

			_level1Text = level1TextObj.GetComponent<Text>();

			_level2Image = level2ButtonObj.GetComponent<Image>();
			_level2Button = level2ButtonObj.GetComponent<Button>();
			_level2Text = level2TextObj.GetComponent<Text>();

			_level3Image = level3ButtonObj.GetComponent<Image>();
			_level3Button = level3ButtonObj.GetComponent<Button>();
			_level3Text = level3TextObj.GetComponent<Text>();
		}
		else
		{
			//Tester Mode
			Debug.Log("You are in TesterMode MOde");
			_Normal = false;
		}
	}

	void Update()
	{
		if (_Normal)
		{
			if (PlayerPrefs.GetInt("Level2") == 0)
			{
				//block level2Button
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

				//Level1 Clear
				_level1Text.color = Color.green;
			}

			if (PlayerPrefs.GetInt("Level3") == 0)
			{
				//Block level3Button
				_level3Image.enabled = false;
				_level3Button.enabled = false;
				_level3Text.color = Color.red;
			}
			else
			{
				//enable Button
				_level3Image.enabled = true;
				_level3Button.enabled = true;
				_level3Text.color = Color.white;

				//Level2 Clear
				_level2Text.color = Color.green;
			}
			if (PlayerPrefs.GetInt("LastLevelClear") == 1)
			{
				_level3Text.color = Color.green;
			}
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
