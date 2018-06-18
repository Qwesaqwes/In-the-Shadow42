using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFade : MonoBehaviour
{
	public Animator animator;
	// public GameObject	LoadLevelObj;

	// LoadLevel			_loadlevel;
	public GameObject	LoadLevelsObj;

	LoadLevels			_loadlevels;

	// Use this for initialization
	void Start ()
	{
		// _loadlevel = LoadLevelObj.GetComponent<LoadLevel>();
		_loadlevels = LoadLevelsObj.GetComponent<LoadLevels>();
	}

	public void MainMenuFadeOut()
	{
		animator.SetTrigger("MainMenuFadeOut");
	}

	public void LoadScene()
	{
		SceneManager.LoadScene(_loadlevels.scene);
	}
}
