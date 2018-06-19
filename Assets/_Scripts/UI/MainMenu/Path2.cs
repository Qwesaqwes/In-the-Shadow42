using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path2 : MonoBehaviour
{
	public GameObject	level3Obj;
	public GameObject	level3TextObj;
	public Material		Level3Material;
	
	public void ActivateLevel3()
	{
		level3Obj.SetActive(true);
		level3TextObj.SetActive(true);
		Level3Material.SetColor("_EmissionColor", Color.yellow);
	}
}
