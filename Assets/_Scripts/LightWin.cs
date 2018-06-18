using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWin : MonoBehaviour {

	public GameObject			blurObj;
	public void WinEvent()
	{
		Time.timeScale = 1f;
		blurObj.SetActive(true);
	}
}
