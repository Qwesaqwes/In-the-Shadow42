using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path3 : MonoBehaviour
{
	public GameObject	level4Obj;
	public GameObject	level4TextObj;
	public Material		Level4Material;
	
	public void ActivateLevel4()
	{
		level4Obj.SetActive(true);
		level4TextObj.SetActive(true);
		Level4Material.SetColor("_EmissionColor", Color.yellow);
	}
}
