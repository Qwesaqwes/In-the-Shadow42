using UnityEngine;

public class NormalMode : MonoBehaviour
{
	public GameObject	FadeObj;
	public GameObject	ModeSelectionObj;

	Fade				_fade;
	ModeSelection		_modeSelected;

	void Start()
	{
		_fade = FadeObj.GetComponent<Fade>();
		_modeSelected = ModeSelectionObj.GetComponent<ModeSelection>();
	}
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_modeSelected.SelectedMode(0);
			_fade.ModeSelectFadeOut();
		}
	}
}
