using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFade : MonoBehaviour
{
	public int		secondsToFade;
	public Animator	PanelAnimator;
	public Animator	TextAnimator;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(waitToFade(secondsToFade));
	}
	
	IEnumerator waitToFade(int secondsToFade)
	{
		yield return new WaitForSeconds(secondsToFade);
		PanelAnimator.SetTrigger("ControlFade");
		TextAnimator.SetTrigger("ControlFade");
	}

}
