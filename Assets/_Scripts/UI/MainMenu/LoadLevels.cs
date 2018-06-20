using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevels : MonoBehaviour
{
	[HideInInspector]
	public int			scene;

	public Material		Level1Material;
	public Material		Level2Material;
	public Material		Level3Material;
	public Material		Level4Material;
	public Animator		Pathligh1Animation;
	public Animator		Pathligh2Animation;
	public Animator		Pathligh3Animation;

	bool				_Normal = false;

	void Start()
	{
		Time.timeScale = 1f;
		if (PlayerPrefs.GetInt("Mode") == 0)
		{
			//Normal Mode
			Debug.Log("You are in Normal MOde");
			_Normal = true;
		}
		else
		{
			//Tester Mode
			Debug.Log("You are in TesterMode MOde");
			_Normal = false;
		}
	}
	
	void Update ()
	{
		if (_Normal)
		{
			if (PlayerPrefs.GetInt("Level2") == 0)
			{
				//block level2Button
				Level1Material.SetColor("_EmissionColor", Color.yellow);
			}
			else
			{
				//enable Button
				Pathligh1Animation.SetTrigger("LevelClear");
				Level1Material.SetColor("_EmissionColor", Color.green);
			}

			if (PlayerPrefs.GetInt("Level3") == 0)
			{
				//Block level3Button
				Level2Material.SetColor("_EmissionColor", Color.yellow);
			}
			else
			{
				//enable Button
				Pathligh2Animation.SetTrigger("LevelClear");
				//Level2 Clear
				Level2Material.SetColor("_EmissionColor", Color.green);
			}

			if (PlayerPrefs.GetInt("Level4") == 0)
			{
				//Block Level4Button
				Level3Material.SetColor("_EmissionColor", Color.yellow);
			}
			else
			{
				Pathligh3Animation.SetTrigger("LevelClear");
				Level3Material.SetColor("_EmissionColor", Color.green);
			}

			if (PlayerPrefs.GetInt("LastLevelClear") == 1)
			{
				Level4Material.SetColor("_EmissionColor", Color.green);
			}
			else
			{
				Level4Material.SetColor("_EmissionColor", Color.yellow);
			}
		}
		else
		{
			Pathligh1Animation.SetTrigger("LevelClear");
			Pathligh2Animation.SetTrigger("LevelClear");
			Pathligh3Animation.SetTrigger("LevelClear");
			Level1Material.SetColor("_EmissionColor", Color.yellow);
			Level2Material.SetColor("_EmissionColor", Color.yellow);
			Level3Material.SetColor("_EmissionColor", Color.yellow);
			Level4Material.SetColor("_EmissionColor", Color.yellow);
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

	public void ResetButton()
	{
		PlayerPrefs.SetInt("Level2", 0);
		PlayerPrefs.SetInt("Level3", 0);
		PlayerPrefs.SetInt("Level4", 0);
		PlayerPrefs.SetInt("LastLevelClear", 0);
	}
}
