using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path1 : MonoBehaviour
{
	public GameObject	level2Obj;
	public Material		Level2Material;
	
	public void ActivateLevel2()
	{
		level2Obj.SetActive(true);
		Level2Material.SetColor("_EmissionColor", Color.yellow);
	}
}
