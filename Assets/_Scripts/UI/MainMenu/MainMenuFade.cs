using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFade : MonoBehaviour
{
	public Animator animator;
	public GameObject	LoadLevelObj;

	LoadLevel			_loadlevel;

	// Use this for initialization
	void Start ()
	{
		_loadlevel = LoadLevelObj.GetComponent<LoadLevel>();
	}

	public void MainMenuFadeOut()
	{
		animator.SetTrigger("MainMenuFadeOut");
	}

	public void LoadScene()
	{
		SceneManager.LoadScene(_loadlevel.scene);
	}
}
