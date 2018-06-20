using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TesterMode : MonoBehaviour
{
	public GameObject	FadeObj;
	public GameObject	ModeSelectionObj;

	Fade				_fade;
	ModeSelection		_modeSelected;
	AudioManager		_audio;

	void Start()
	{
		_fade = FadeObj.GetComponent<Fade>();
		_modeSelected = ModeSelectionObj.GetComponent<ModeSelection>();
		_audio = FindObjectOfType<AudioManager>();
	}
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_modeSelected.SelectedMode(1);
			_fade.ModeSelectFadeOut();
			_audio.Stop("IntroSound");
			_audio.Play("SelectedMode");
			StartCoroutine(waitNextLevel());
		}
	}
	
	void OnMouseEnter()
	{
		transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
	}

	void OnMouseExit()
	{
		transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
	}

	IEnumerator waitNextLevel()
	{
		yield return new WaitForSeconds(1);
		_audio.Play("MapSound");
	}
}
