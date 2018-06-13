using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaPotMovement : MonoBehaviour
{
	[Range(2, 7)]public float	speedRotation = 5f;
	public float	MinYRot;
	public float	MaxYRot;
	
	void Start()
	{
		transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
	}

	void Update ()
	{
		float Vaxis = Input.GetAxis("Mouse X");
		if (Input.GetMouseButton(0))
			transform.Rotate(0, -1 * Vaxis * speedRotation, 0, Space.World);
		checkObjRotation();
	}

	void checkObjRotation()
	{
		if (transform.eulerAngles.y >= MinYRot && transform.eulerAngles.y <= MaxYRot)
		{
			Debug.Log("YOU WIN!");
			
		}
	}
}