using UnityEngine;

public class TesterMode : MonoBehaviour
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
			_modeSelected.SelectedMode(1);
			_fade.ModeSelectFadeOut();
		}
	}
}
