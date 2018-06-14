using UnityEngine;
using UnityEngine.SceneManagement;

public class LeverChanger : MonoBehaviour
{
	public Animator		animator;
	public GameObject	UimanagerObj;

	UIManager			mUimanager;
	
	void Start()
	{
		mUimanager = UimanagerObj.GetComponent<UIManager>();
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	public void fadeToNextScene()
	{
		animator.SetTrigger("FadeOut");
	}

	public void OnFadeComplete()
	{
		SceneManager.LoadScene(mUimanager._SceneToLoad);
	}

}
