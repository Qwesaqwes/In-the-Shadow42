using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
	public Animator	animator;

	public void ModeSelectFadeOut()
	{
		animator.SetTrigger("MainMenuFadeOut");
	}

	public void LoadScene()
	{
		SceneManager.LoadScene(1);
	}
}
