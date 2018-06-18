using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWin : MonoBehaviour {

	public GameObject			blurObj;
	public void WinEvent()
	{
		blurObj.SetActive(true);
	}
}
