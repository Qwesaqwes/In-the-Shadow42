using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelInTestMode : MonoBehaviour
{
	public GameObject	level2Obj;
	public GameObject	level2TextObj;
	public GameObject	level3Obj;
	public GameObject	level3TextObj;
	public GameObject	level4Obj;
	public GameObject	level4TextObj;
	
	// Use this for initialization
	void Start ()
	{
		if (PlayerPrefs.GetInt("Mode") == 1)
		{
			level2Obj.SetActive(true);
			level2TextObj.SetActive(true);
			level3Obj.SetActive(true);
			level3TextObj.SetActive(true);
			level4Obj.SetActive(true);
			level4TextObj.SetActive(true);
		}
	}
}
